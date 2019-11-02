using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {

        meterObject = Instantiate(meter);
        meterObject.transform.SetParent(canvas);
        meterObject.transform.Translate(115, 200, 0);
        strikesObject = Instantiate(strikes);
        strikesObject.transform.SetParent(canvas);
        strikesObject.transform.Translate(90, 365, 0);
        scoreObject = Instantiate(score);
        scoreObject.transform.SetParent(canvas);
        scoreObject.transform.Translate(285, 365, 0);
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
                    // End game
                }
            }
        }

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
    }


}
