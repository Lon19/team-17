using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class RoomList : MonoBehaviour


{

    [SerializeField]
    private Text roomNameText;


    private MatchInfoSnapshot match;

    public void setup( MatchInfoSnapshot newmatch)
    {
        match = newmatch;
        Debug.Log(match.name + " Size (" + match.currentSize + "/" + match.maxSize + ")");

        roomNameText.text = match.name + " Size (" + match.currentSize + "/" + match.maxSize +")";
    }

    public void JoinRoom()
    {
        NetworkManager netManager = NetworkManager.singleton;
        netManager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, netManager.OnMatchJoined);

    }
}
