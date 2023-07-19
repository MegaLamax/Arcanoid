using System;
using System.Collections;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float speed = 3f  ;
    public float wallDistanceX = 7f;
    public float wallDistanceY = 4f;
    public int frameRate;

    private Vector3 _lastFramePosition;
    
    private void Start()
    {
        Application.runInBackground = true;
        Application.targetFrameRate = frameRate;
    }

    private void Update()
    {
        Vector2 input = new Vector2();
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        
        Vector3 currentPos = transform.position;

        currentPos.x += input.x * speed;
        currentPos.y += input.y * speed;

        if (currentPos.x < -wallDistanceX)
            currentPos.x = -wallDistanceX;
        
        if (currentPos.x > wallDistanceX)
            currentPos.x = wallDistanceX;

        if (currentPos.y > wallDistanceY)
            currentPos.y = wallDistanceY;
        
        if (currentPos.y < -wallDistanceY)
            currentPos.y = -wallDistanceY;

        transform.position = currentPos;

        float distanceThisFrame = Vector3.Distance(transform.position, _lastFramePosition);

        if (distanceThisFrame > 0)
        {
            Debug.LogError($"distance this frame: {distanceThisFrame.ToString("f3")}");    
        }

        _lastFramePosition = transform.position;
    }
}
