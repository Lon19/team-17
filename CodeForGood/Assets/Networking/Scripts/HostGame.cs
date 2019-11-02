using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class HostGame : NetworkManager
{
    [SerializeField]
    private uint roomSize = 6;
    private string roomName;
    private NetworkManager netManager;

    [SerializeField]
    private List<GameObject> roomList = new List<GameObject>();

    [SerializeField]
    private Text status;

    public void Start()
    {
        netManager = NetworkManager.singleton;
        if (netManager.matchMaker == null)
        {
            netManager.StartMatchMaker();
        }

        ReFreshRoomList();
    }
    public void giveRoomName(string newRoomName)
    {
        roomName = newRoomName;
    }

    public void createRoom()
    {
        if (roomName != "" && roomName != null)
        {
            Debug.Log("Creating Room: " + roomName + "Size" + roomSize);

            netManager.matchMaker.CreateMatch(roomName,roomSize,true,"","","",0,0,OnMatchCreate);
        }
    }
    public void ReFreshRoomList()
    {
        netManager.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
        status.text = "Loading...";
    }

    public override void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        if (LogFilter.logDebug) { Debug.LogFormat("NetworkManager OnMatchList Success:{0}, ExtendedInfo:{1}, matchList.Count:{2}", success, extendedInfo, matchList.Count); }
        matches = matchList;
        Debug.Log("");
    }

    public override void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (LogFilter.logDebug) { Debug.LogFormat("NetworkManager OnMatchCreate Success:{0}, ExtendedInfo:{1}, matchInfo:{2}", success, extendedInfo, matchInfo); }
        if (success)
            StartHost(matchInfo);
    }
}
