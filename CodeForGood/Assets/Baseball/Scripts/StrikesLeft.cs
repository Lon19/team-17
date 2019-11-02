using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikesLeft : MonoBehaviour
{
    Text txt;
    private int strikesLeft = 3;

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = strikesLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setStrikesLeft()
    {
        strikesLeft--;
        txt.text = strikesLeft.ToString();
    }

    public int getStrikesLeft()
    {
        return strikesLeft;
    }
}
