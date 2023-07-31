using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiecleAndRectangule : MonoBehaviour
{

    public bool isColliding;
    public float Radius;

    public Cube Rectangle;

    private SpriteRenderer Circle;

    void Start()
    {
        Circle = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 circlePosition = transform.position;
        Vector3 RectanglePosition = Rectangle.transform.position;

        float rectangleHalfX = Rectangle.HalfSide.x;
        float rectangleHalfY = Rectangle.HalfSide.y;

           float XLeft;
           float XRight;
           float YUp;
           float YDown;

        float closestX = Mathf.Clamp(circlePosition.x, RectanglePosition.x - rectangleHalfX, RectanglePosition.x + rectangleHalfX);
        float closestY = Mathf.Clamp(circlePosition.y, RectanglePosition.y - rectangleHalfY, RectanglePosition.y + rectangleHalfY);

        float distance = Vector2.Distance(circlePosition, new Vector2(closestX, closestY));

        if (distance<=Radius)
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }

        if (isColliding)
        {
            Circle.material.color = Color.red;
        }
        else
        {
            Circle.material.color = Color.white;
        }
    }
}
