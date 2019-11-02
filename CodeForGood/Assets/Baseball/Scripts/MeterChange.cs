using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeterChange : MonoBehaviour
{
    private Slider slider;
    private int speed = 1;
    private bool increasing = true;
    private float powerBar = 0;
    // Start is called befores the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
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

    public bool checkIfBallIsHit()
    {
        if (slider.value > 0.4 && slider.value < 0.6)
        {
            return true;
        }
        return false;
    }

    void change(int speed)
    {
        this.speed = speed;
    }
}
