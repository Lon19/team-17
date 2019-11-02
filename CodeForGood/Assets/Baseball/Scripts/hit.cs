using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MeterChange;

public class hit : MonoBehaviour
{
   // private MeterChange meter;

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
              //  if (meter.checkIfBallIsHit())
              //  {
              //      hitBall();
              //  }
            }
        }
    }


}
