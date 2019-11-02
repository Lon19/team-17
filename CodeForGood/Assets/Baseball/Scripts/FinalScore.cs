using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    private Text txt;
    private int finalScore;
    // Start is called before the first frame update
    void Start()
    {
        finalScore = PlayerPrefs.GetInt("finalScore", finalScore);
        txt = gameObject.GetComponent<Text>();
        txt.text = finalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
