using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Runtime.InteropServices;
public class GameManager : MonoBehaviour
{
 [DllImport("__Internal")]
    //public static extern void CallFunction();
    public static extern void CallFunction(string roomName);

    //[DllImport("__Internal")]
    //public static extern void test(string param);
    [DllImport("__Internal")]
    public static extern void DisconnectCall(string roomName);
    // Importing "PassTextParam"
    private GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        /* if(PhotonNetwork.IsConnectedAndReady)
         {
         playerPrefab = GameObject.FindWithTag("Player");
         Debug.Log("Player",playerPrefab);
         int randomNumber = Random.Range(-10,10);
         PhotonNetwork.Instantiate(playerPrefab.name,new Vector3(randomNumber,0.84f,randomNumber),Quaternion.identity);
         }
         */
        //CallFunction();
        Debug.Log("First Scene---------------------------------"+ PlayerPrefs.GetInt("firstScene"));
        if (PlayerPrefs.GetInt("firstScene") == 0)
        {
            string s = "School_1";
            Debug.Log("Audioroom created successfully");
            //test(s);
            //DisconnectCall(s);
            PlayerPrefs.SetInt("firstScene", 1);
            Debug.Log("First Scene Change ---------------------------------" + PlayerPrefs.GetInt("firstScene"));
            CallFunction(s);
            
            //PlayerPrefs.SetInt("firstScene", 1);
            

        }
        //Make it off while building in local.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
