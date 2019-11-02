using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    [SerializeField]
    private GameObject meter;
    [SerializeField]
    private Transform canvas;
    [SerializeField]
    private GameObject strikes;
    [SerializeField]
    private GameObject score;
    private GameObject meterObject;
    private GameObject strikesObject;
    private GameObject scoreObject;
    public float difficulty = 0.1f;
    public int speed = 1;
    public int highscore;
    public int finalScore;

    // Start is called before the first frame update
    void Start()
    {
        meterObject = Instantiate(meter);
        meterObject.transform.SetParent(canvas);
        meterObject.transform.Translate(150, 450, 0);
        strikesObject = Instantiate(strikes);
        strikesObject.transform.SetParent(canvas);
        strikesObject.transform.Translate(95, 465, 0);
        scoreObject = Instantiate(score);
        scoreObject.transform.SetParent(canvas);
        scoreObject.transform.Translate(335, 465, 0);
        meterObject.GetComponent<MeterChange>().checkIfBallIsHit(difficulty, speed);
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (meterObject.GetComponent<MeterChange>().checkIfBallIsHit(difficulty, speed))
            {
                scoreObject.GetComponent<Score>().setScore();
            }
            else
            {
                strikesObject.GetComponent<StrikesLeft>().setStrikesLeft();
                if (strikesObject.GetComponent<StrikesLeft>().getStrikesLeft() == 0)
                {
                    finalScore = scoreObject.GetComponent<Score>().getScore();
                    PlayerPrefs.SetInt("finalScore", finalScore);
                    if (finalScore > highscore)
                    {
                        highscore = finalScore;
                        PlayerPrefs.SetInt("highscore", highscore);
                    }
                    SceneManager.LoadScene(6);
                }
            }
        }

        /*
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                if (meterObject.GetComponent<MeterChange>().checkIfBallIsHit(difficulty, speed))
                {
                    scoreObject.GetComponent<Score>().setScore();
                }
                else
                {
                    strikesObject.GetComponent<StrikesLeft>().setStrikesLeft();
                    if (strikesObject.GetComponent<StrikesLeft>().getStrikesLeft() == 0)
                    {
                        //Go to high score scene
                    }
                }
            }
        }
        */
    }


}
