using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // prefab for instantiating apples
    public GameObject applePrefab;
    // speed at which the AppleTree moves
    public float speed = 1f;

    // distance where the AppleTree turns around
    public float leftAndRightEdge = 10f;
    // chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between Apples instatiations
    public float appleDropDelay = 1f;



    // Start is called before the first frame update
    void Start()
    {
        // Start dropping apples
        Invoke("DropApple", 2f);    
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Change Direction
        // handle hitting the edges of the screen
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // move right 
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // move left
        }// else if (Random.value < changeDirChance)
       // {
       //     speed *= -1; // change direction
       // }

    }
    private void FixedUpdate()
    {
      
        // runs at a fixed interval, independent of frame rate (50-60 fps)
        if (Random.value < changeDirChance)
        {
            speed *= -1; // change direction
        }
    }
}
