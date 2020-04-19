using UnityEngine;
using System.Collections;

public class BGScrollerTime : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;

    public GameControllerTime gameControllerTime;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        scrollSpeed = -1;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;



        if (gameControllerTime.timeLeft <= 0)
        {
            scrollSpeed = -70;
        }
    }


}

