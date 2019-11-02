using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text txt;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore()
    {
        score++;
        txt.text = score.ToString();
    }

    public int getScore()
    {
        return score;
    }
}
