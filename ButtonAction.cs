using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using static System.String;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviourPunCallbacks
{
    [DllImport("__Internal")]
    public static extern void ChangeRoom(string roomName);
    private bool is_switch = false;
    public GameObject[] players;

    private PhotonView photonViewDetails;
    public static string sceneName;
    private static string Name;
    public int numberOfScenes = 6;
    public String[] sceneNames;
    [SerializeField] private GameObject ConnectingPanel;
    void Start()
    {
        //sceneNames = new String[numberOfScenes];
        //for (int i = 0; i < numberOfScenes; i++)
        //{
        //    sceneNames[i] = Application.GetLevelNameByIndex(i);
        //}

    }

    public void OnLoginClick(string param)
    {
        Name = PhotonNetwork.LocalPlayer.NickName;
        if (!IsNullOrEmpty(Name))
        {
            int myID = PhotonNetwork.LocalPlayer.ActorNumber;
            object[] Cams = GameObject.FindObjectsOfType(typeof(Camera));
            foreach (Camera C in Cams)
            {
                C.enabled = true;
            }
            sceneName = param;
            setRoomName(sceneName);
            Debug.Log("Scene Name ----------------------" + sceneName);
            PhotonNetwork.LeaveRoom();
            Debug.Log("User successuflly Left the room");
            StartCoroutine(waiter());


        }
        else
        {
            Debug.Log("Empty name");
        }
    }
    public void ConnectToAnotherRoom()
    {
        is_switch = true;
        // PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LocalPlayer.NickName = Name;
        players = GameObject.FindGameObjectsWithTag("Player");
        PhotonNetwork.AutomaticallySyncScene = false;
        Debug.Log("test want to change another room");
        PhotonNetwork.JoinLobby();

    }

    public override void OnLeftRoom()
    {
        Debug.Log("89999999 ----------------Connected to internet");
        StartCoroutine(waiter());
        Debug.Log("sceneName check" + sceneName);
        Debug.Log("sceneName check" + getRoomName());
        //ConnectToAnotherRoom();
    }
    public override void OnConnected()
    {
        Debug.Log("11 ----------------Connected to internet ");
    }

    public override void OnCreatedRoom()
    {
        if (is_switch)
        {
            Debug.Log(PhotonNetwork.CurrentRoom.Name + " 22 ---------------------------is created");
        }

        // base.OnCreatedRoom;
    }

    public override void OnJoinedLobby()
    {
        if (is_switch)
        {
            CreateOrJoinRoom();
            Debug.Log("33 -------------------------on joined romm");
        }


    }
    public override void OnJoinedRoom()
    {
        if (is_switch)
        {
            print("44 ------------------------------------I joined");
            // Spawn.SetActive(true);
            PhotonNetwork.LoadLevel(sceneName);
        }

    }

    public void CreateOrJoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.JoinOrCreateRoom(sceneName, roomOptions, TypedLobby.Default);
        ChangeRoom(sceneName);
    }



    IEnumerator waiter()
    {
        //Rotate 90 deg
        Debug.Log("2----*********************");
        Debug.Log("start --- ");
        Debug.Log("Scene name " + sceneName);
        //Wait for 2 seconds
        ActivateMyPanel(ConnectingPanel.name);
        yield return new WaitForSeconds(1);
        Debug.Log("start --- 1 seconds");
        yield return new WaitForSeconds(2);
        Debug.Log("start --- 2 seconds");
        yield return new WaitForSeconds(3);
        Debug.Log("start --- 3 seconds");
        yield return new WaitForSeconds(4);
        Debug.Log("start --- 4 seconds");
        yield return new WaitForSeconds(5);

        ConnectToAnotherRoom();

    }
    public void ActivateMyPanel(string panelName)
    {
        ConnectingPanel.SetActive(panelName.Equals(ConnectingPanel.name));
    }

    public void setRoomName(string param)
    {
        sceneName = param;
    }
    public string getRoomName()
    {
        return sceneName;
    }

    //public int GetSceneIndex(String sceneName)
    //{
    //    for (int i = 0; i < sceneNames.length; i++)
    //    {
    //        if (sceneName == sceneNames[i])
    //        {
    //            return i;
    //        }
    //    }
    //}
}
