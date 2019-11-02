using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chatInput : MonoBehaviour
{
    public c4gChatManage chatManger;
    public InputField inputField;

    public void Start()
    {
        
    }

    public void valueChanged()
    {
        chatManger.writeMessage(inputField);
    }
}
