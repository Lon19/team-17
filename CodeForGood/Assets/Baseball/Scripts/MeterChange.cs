using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeterChange : MonoBehaviour
{
    [SerializeField]
    private Image greenArea;
    [SerializeField]
    private Slider slider;
    private int speed = 1;
    private bool increasing = true;
    private float powerBar = 0;
    [SerializeField]
    RectTransform greenAreaRectTransform;
    // Start is called befores the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        greenArea = slider.GetComponentsInChildren<Image>()[2];
        greenAreaRectTransform = greenArea.transform as RectTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if (increasing)
        {
            //increases and prevents slider value from going outside of 0 and 1
            powerBar += Time.deltaTime * speed;
            slider.value = Mathf.Clamp(powerBar, 0, 1);
            if (powerBar >= 1) increasing = false;
        }
        else
        {
            //decreases and prevents slider value from going outside of 0 and 1
            powerBar -= Time.deltaTime * speed;
            slider.value = Mathf.Clamp(powerBar, 0, 1);
            if (powerBar <= 0) increasing = true;
        }
    }

    public bool checkIfBallIsHit(float difficulty, int speed)
    {
        //changes the scale of the green bar based on float received
        greenAreaRectTransform.localScale = new Vector3(difficulty, 1, 1);
        setSpeed(speed);

        //calculates the edges of the green bar
        float edge = 0.5f - (difficulty/2);

        //calculates the true value zone
        if (slider.value >= (0 + edge) && slider.value <= (1 - edge))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void setSpeed(int speed)
    {
        this.speed = speed;
    }

    public void init(float difficulty, int speed)
    {
        checkIfBallIsHit(difficulty, speed);
    }
}
