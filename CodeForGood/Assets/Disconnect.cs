using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;


public class Disconnect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leaveRoom()
    {
        NetworkManager NetManager = NetworkManager.singleton;
        NetManager.matchMaker.DropConnection(NetManager.matchInfo.networkId, NetManager.matchInfo.nodeId, 0, NetManager.OnDropConnection);
        NetManager.StopHost();
        SceneManager.LoadScene(1);
    }
}
