using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customiser : MonoBehaviour
{

    public Button m_HairLeft, m_HairRight;
    private enum Direction {LEFT, RIGHT };

    void Start()
    {
        m_HairLeft.onClick.AddListener(delegate() { TaskOnClick(Direction.LEFT); });
        m_HairRight.onClick.AddListener(delegate () { TaskOnClick(Direction.RIGHT); });
    }

    void TaskOnClick(Direction direction)
    {
        Debug.Log("You have clicked the " + direction.ToString() + " button!");
    }

}
