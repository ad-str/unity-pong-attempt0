using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundsScript : MonoBehaviour
{
    public Camera sceneCamera;
    public GameObject topBound;
    public GameObject bottomBound;
    public GameObject rightBound;
    public GameObject leftBound;

    // Start is called before the first frame update
    void Start()
    {
        // get aspect ratio of screen
        float aspect = sceneCamera.aspect;

        // get width and height of camera
        float orthoSize = sceneCamera.orthographicSize; // height from y=0 (center of screen)
        float orthoWidth = aspect * orthoSize; // width from x=0 (center of screen)

        // set the offset
        topBound.transform.position = new Vector2(0, orthoSize);
        bottomBound.transform.position = new Vector2(0, -orthoSize);
        rightBound.transform.position = new Vector2(orthoWidth, 0);
        leftBound.transform.position = new Vector2(-orthoWidth, 0);

        // set the size of bounds to the same as camera
        // *2 bc orthographic size is size of half the screen (from the center)
        topBound.transform.localScale = new Vector2(orthoWidth * 2, .5f);
        bottomBound.transform.localScale = new Vector2(orthoWidth * 2, .5f);
        rightBound.transform.localScale = new Vector2(.5f, orthoSize * 2);
        leftBound.transform.localScale = new Vector2(.5f, orthoSize * 2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
