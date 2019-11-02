using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private Text txt;
    private int highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        txt = gameObject.GetComponent<Text>();
        txt.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
