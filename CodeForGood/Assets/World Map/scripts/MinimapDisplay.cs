using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float width = Screen.width / 200.0f;
        float height = Screen.height / 400.0f;
        float depth = transform.localScale.z;
        transform.localScale = new Vector3(width, height, depth);

        float x = Screen.width / 6.0f;
        float y = Screen.height / 2.5f;
        float z = transform.localPosition.z;
        transform.localPosition = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
