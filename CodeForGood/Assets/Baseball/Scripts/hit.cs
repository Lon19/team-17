using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    private MeterChange meter;
    private StrikesLeft strikes;
    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                if (meter.checkIfBallIsHit())
                {
                    score.setScore();
                }
                else
                {
                    strikes.setStrikesLeft();
                    if (strikes.getStrikesLeft() == 0)
                    {
                        // End game
                    }
                }
            }
        }
    }


}
