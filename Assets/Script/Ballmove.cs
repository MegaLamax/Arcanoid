using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmove : MonoBehaviour
{
    public float Speed = 2f;

    public float WallLimitX;
    public float WallLimitY;

    public Vector3 InitalDirectionMove;
    private Vector3 CurrentDirectionMove;

    public float Radius = 0.2f;

    public PlayerShip playerShip;
    
    void Start()
    {

        CurrentDirectionMove = InitalDirectionMove;

    }
    
    void Update()
    {

        MoveDirectionBall();

    }


    private void MoveDirectionBall()
    {
        CurrentDirectionMove.Normalize();

        Vector3 movement = CurrentDirectionMove * Speed * Time.deltaTime;

        Vector3 newPosition = transform.position + movement;

        newPosition.x = Mathf.Clamp(newPosition.x, -WallLimitX, WallLimitX);

        if (newPosition.y + Radius >= WallLimitY)
        {
            newPosition.y = WallLimitY - Radius;
            CurrentDirectionMove.y *= -1f;
        }

        if (newPosition.y - Radius <= -WallLimitY)
        {
            newPosition.y = -WallLimitY + Radius;
            CurrentDirectionMove.y *= -1f;
        }

        if (newPosition.x + Radius >= WallLimitX)
        {
            newPosition.x = WallLimitX - Radius;
            CurrentDirectionMove.x *= -1f;
        }

        if (newPosition.x - Radius <= -WallLimitX)
        {
            newPosition.x = -WallLimitX + Radius;
            CurrentDirectionMove.x *= -1f;
        }

        
        Vector3 ToPlayerShip = playerShip.transform.position - newPosition;

        float DistancePlayerShip = ToPlayerShip.magnitude;

        if (DistancePlayerShip<=Radius+ playerShip.Side)
        {
            CurrentDirectionMove = ToPlayerShip.normalized;
        }

        transform.position = newPosition;
    }

}
