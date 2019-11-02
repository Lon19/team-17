using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    [SerializeField]
    private GameObject roomPrefab;

    [SerializeField]
    private Transform scrollView;

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
            SceneManager.LoadScene(4);
        }
    }
    public void ReFreshRoomList()
    {
        ClearRoomList();
        netManager.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
        status.text = "Loading...";
    }

    public override void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        if (LogFilter.logDebug) { Debug.LogFormat("NetworkManager OnMatchList Success:{0}, ExtendedInfo:{1}, matchList.Count:{2}", success, extendedInfo, matchList.Count); }
        matches = matchList;
        status.text = "";
        if (matches == null)
        {
            status.text = "Couldn't get room List";
            return;
        }
        ClearRoomList();
        foreach (MatchInfoSnapshot match in matches)
        {
            GameObject roomListItemGo = Instantiate(roomPrefab);
            roomListItemGo.transform.SetParent(scrollView);

            RoomList newRoomlist = roomListItemGo.GetComponent<RoomList>();
            newRoomlist.setup(match);
            roomList.Add(roomListItemGo);
        }

        if (matches.Count == 0)
        {
            status.text = "No rooms Available";
        }
    }

    void ClearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }
        roomList.Clear();
    }

    public override void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (LogFilter.logDebug) { Debug.LogFormat("NetworkManager OnMatchCreate Success:{0}, ExtendedInfo:{1}, matchInfo:{2}", success, extendedInfo, matchInfo); }
        if (success)
            StartHost(matchInfo);
    }

    public override void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (LogFilter.logDebug) { Debug.LogFormat("NetworkManager OnMatchJoined Success:{0}, ExtendedInfo:{1}, matchInfo:{2}", success, extendedInfo, matchInfo); }
        if (success)
            StartClient(matchInfo);
    }
}
