using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private static readonly float speed = 5f;
    private static readonly float lowerX = -18.8f;
    private static readonly float upperX = 17.5f;
    private static readonly float lowerY = -6.6f;
    private static readonly float upperY = 6.5f;


    private Camera cam;

    private Vector3 lastPanPosition;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastPanPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            PanCamera(Input.mousePosition);
        }
    }

    void PanCamera(Vector3 newPanPosition)
    {
        Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - newPanPosition);
        Vector3 move = new Vector3(offset.x * speed, offset.y * speed, 0);
    
        transform.Translate(move, Space.World);

        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(transform.position.x, lowerX, upperX);
        clampedPos.y = Mathf.Clamp(transform.position.y, lowerY, upperY);
        transform.position = clampedPos;

        lastPanPosition = newPanPosition;
    }
}
