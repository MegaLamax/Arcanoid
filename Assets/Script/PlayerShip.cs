using System;
using System.Collections;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float speed = 3f;
    public float Side = 0.5f;
    public float wallDistanceX;
    //public float wallDistanceY;
    public int frameRate;
    
    private void Start()
    {
        Application.runInBackground = true;
        Application.targetFrameRate = frameRate;
    }

    private void Update()
    {
        Vector2 input = new Vector2();
        input.x = Input.GetAxis("Horizontal");
        //input.y = Input.GetAxis("Vertical");

        Vector2 inputV = input.normalized;
        
        Vector2 currentPos = transform.position;

        currentPos += inputV * speed * Time.deltaTime;

        currentPos.x = Mathf.Clamp(currentPos.x, -wallDistanceX, wallDistanceX);

        if (currentPos.x + Side >= wallDistanceX)
        {
            currentPos.x = wallDistanceX - Side;
        }

        if (currentPos.x - Side <= -wallDistanceX)
        {
            currentPos.x = -wallDistanceX + Side;
        }
        
        transform.position = currentPos;

        //currentPos.y = Mathf.Clamp(currentPos.y, -wallDistanceY, wallDistanceY);

  
    }
}
