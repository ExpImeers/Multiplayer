using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using static System.String;
using Photon.Realtime;
//using Button = UnityEngine.UI.Button;
public class PhotonManager : MonoBehaviourPunCallbacks
{

   [SerializeField] private TMP_InputField userNameText;
   [SerializeField] private GameObject PlayerNamePanel;
   [SerializeField] private GameObject LobbyPanel;
   [SerializeField] private GameObject RoomCreatePanel;
   [SerializeField] private GameObject ConnectingPanel;
   [SerializeField] private TMP_InputField roomNameText;
   [SerializeField] private TMP_InputField maxPlayerText;
   [SerializeField] private GameObject RoomListPanel;
   private Dictionary<string, RoomInfo> roomListData;
    [SerializeField] private GameObject roomListPrefab;
    [SerializeField] private GameObject roomListParent;
   private Dictionary<string, GameObject> roomListGameObject;
   private Dictionary<int, GameObject> playerListGameObject;

    // Start is called before the first frame update
    [Header("Inside Room Planel")]
     [SerializeField] private GameObject InsideRoomPanel;
     [SerializeField] private GameObject playerPrefab;
     [SerializeField] private GameObject playerParent;
     [SerializeField] private GameObject PlayButton;
    private string  regionString ;
    void Start()
    {
        regionString = "in";
        ActivateMyPanel(PlayerNamePanel.name);
        PhotonNetwork.ConnectUsingSettings();
      //  PhotonNetwork.ConnectToRegionMaster(regionString);

        roomListData = new Dictionary<string ,RoomInfo>();
        roomListGameObject = new Dictionary<string ,GameObject>();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Network State:"+ PhotonNetwork.NetworkClientState);
    }



    public void OnLoginClick()
    {
       string Name =  userNameText.text;
       if(!IsNullOrEmpty(Name))
        {
       PhotonNetwork.LocalPlayer.NickName = Name;
       PhotonNetwork.ConnectUsingSettings();
       ActivateMyPanel(ConnectingPanel.name);
       Debug.Log("test");
       PhotonNetwork.JoinLobby();
        }
        else
        {
           Debug.Log("Empty name");
        }
    }

    public override void OnConnected()	
    {
    //Debug.Log("Connected to internet ");
    }
    public override void OnConnectedToMaster()
    {
        //Debug.Log(PhotonNetwork.LocalPlayer.NickName+" is Connected to photon ");
        // ActivateMyPanel(LobbyPanel.name);
          
    }

    public void ActivateMyPanel(string panelName) 
    {
        LobbyPanel.SetActive(panelName.Equals(LobbyPanel.name));
        PlayerNamePanel.SetActive(panelName.Equals(PlayerNamePanel.name));
        RoomCreatePanel.SetActive(panelName.Equals(RoomCreatePanel.name));
        ConnectingPanel.SetActive(panelName.Equals(ConnectingPanel.name));
        RoomListPanel.SetActive(panelName.Equals(RoomListPanel.name));
        InsideRoomPanel.SetActive(panelName.Equals(InsideRoomPanel.name));
    }

    // public void OnClickRoomCreate()
    // {
    // string roomName = roomNameText.text;
    // if(string.IsNullOrEmpty(roomName))
    // {
    // roomName = roomName+ Random.Range(0,1000);
    // }
    // string maxPlayer = maxPlayerText.text;
    // PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = (byte)int.Parse(maxPlayer), IsVisible = true });
    // }

    public override void OnCreatedRoom()
    {
    Debug.Log(PhotonNetwork.CurrentRoom.Name+ " 1 ---------is created");
   // base.OnCreatedRoom;
    }
/*
   public override void OnJoinedRoom ()
   {
         Debug.Log(PhotonNetwork.LocalPlayer.NickName+"Room joined");
         ActivateMyPanel(InsideRoomPanel.name);

         if(playerListGameObject == null)
         {
         playerListGameObject = new Dictionary<int ,GameObject>();
         }
         if(PhotonNetwork.IsMasterClient)
         {
         PlayButton.SetActive(true);
         }
         else{
           PlayButton.SetActive(false);
         }
         foreach(Player p in PhotonNetwork.PlayerList)
         {
          GameObject  playerListItemObject = Instantiate(playerPrefab);
          playerListItemObject.transform.SetParent(playerParent.transform);
          playerListItemObject.transform.localScale = Vector3.one;
          playerListItemObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "" + p.NickName ;
          if(p.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
          {
           playerListItemObject.transform.GetChild(1).gameObject.SetActive(true);
          }
          else{
          playerListItemObject.transform.GetChild(1).gameObject.SetActive(false);
          }
          playerListGameObject.Add(p.ActorNumber,playerListItemObject);
         }
         

   }
   */
   /*
   public void OnCancelClick ()
   {
   ActivateMyPanel(LobbyPanel.name);
   }
   public void RoomListClick()
   {
  // if(PhotonNetwork.InLobby)
  // {
   PhotonNetwork.JoinLobby();

  // }

    ActivateMyPanel(RoomListPanel.name);
   }
 
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
       ClearRoomList();
        //base.OnRoomListUpdate(roomList);
        Debug.Log(" function enter ");
         foreach (RoomInfo rooms in roomList)
        {
            Debug.Log(" room list name "+ rooms.Name);
            if(!rooms.IsOpen || !rooms.IsVisible )
            {
            if(roomListData.ContainsKey(rooms.Name))
            {
              roomListData.Remove(rooms.Name);
            }
            
            }
            else{
             if(roomListData.ContainsKey(rooms.Name))
            {
              roomListData[rooms.Name] = rooms;
            }
            else
            {
             roomListData.Add(rooms.Name,rooms);
            }
            }
            
            
        }
                 foreach (RoomInfo roomItem in roomListData.Values)
        {
              GameObject  roomListItemObject = Instantiate(roomListPrefab);
              roomListItemObject.transform.SetParent(roomListParent.transform);
              roomListItemObject.transform.localScale = Vector3.one;
              
              roomListItemObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "" + roomItem.Name ;
              roomListItemObject.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = roomItem.PlayerCount + "/"+ roomItem.MaxPlayers;
              roomListItemObject.transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(()=> RoomJoinFromList(roomItem.Name));
              roomListGameObject.Add(roomItem.Name,roomListItemObject);
        }
    }

    public void RoomJoinFromList(string roomName)
    {
       if(PhotonNetwork.InLobby)
   {
   PhotonNetwork.LeaveLobby(); 
   }
    PhotonNetwork.JoinRoom(roomName);
    }

    public void ClearRoomList()
    {
    if(roomListGameObject.Count > 0)
    {
    foreach(var v in roomListGameObject.Values)
    {
    Destroy(v);
    }
    roomListGameObject.Clear();
    }
    }

    public void BackFromRoomList(){
    if(PhotonNetwork.InLobby)
   {
   PhotonNetwork.LeaveLobby(); 
   Debug.Log("test is done now deploy");
   }
    ActivateMyPanel(LobbyPanel.name);
    }

    public void BackFromPlayerList(){
         if(PhotonNetwork.InRoom)
   {
   PhotonNetwork.LeaveRoom(); 
   Debug.Log("test is done now deploy");
   }
    ActivateMyPanel(LobbyPanel.name);
    }
     public override void OnLeftLobby()
     {
          ClearRoomList();
          roomListData.Clear();
     }

     public override void OnPlayerEnteredRoom(Player newPlayer)
{
          GameObject  playerListItemObject = Instantiate(playerPrefab);
          playerListItemObject.transform.SetParent(playerParent.transform);
          playerListItemObject.transform.localScale = Vector3.one;
          playerListItemObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "" + newPlayer.NickName ;
          if(newPlayer.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
          {
           playerListItemObject.transform.GetChild(1).gameObject.SetActive(true);
          }
          else{
          playerListItemObject.transform.GetChild(1).gameObject.SetActive(false);
          }
          playerListGameObject.Add(newPlayer.ActorNumber,playerListItemObject);
}


public override void OnPlayerLeftRoom(Player otherPlayer)
{
Destroy(playerListGameObject[otherPlayer.ActorNumber]);
playerListGameObject.Remove(otherPlayer.ActorNumber);
         if(PhotonNetwork.IsMasterClient)
         {
         PlayButton.SetActive(true);
         }
         else{
           PlayButton.SetActive(false);
         }
}
public override void OnLeftRoom()
{
ActivateMyPanel(LobbyPanel.name);
foreach(GameObject obj in playerListGameObject.Values)
{
Destroy(obj);
}
}
public void OnClickPlayButton()
{
    //SceneManagerLoadScene();
    if(PhotonNetwork.IsMasterClient)
    {
        PhotonNetwork.LoadLevel("DemoScene");
    }

}
   */
    public override void OnJoinedLobby()
    {
        Debug.Log("2 ------------------------OnJoinedLobby");
        CreateOrJoinRoom();
     
    }
        public override void OnJoinedRoom()
    {
        print("3 -------------------------------------I joined");
        // Spawn.SetActive(true);
        PhotonNetwork.LoadLevel("School_1");
    }

      public void CreateOrJoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.JoinOrCreateRoom("School_1", roomOptions, TypedLobby.Default);
    }
}
