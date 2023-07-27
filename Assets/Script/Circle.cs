using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public bool isColliding;

    public float Radius;

    public Circle otherCircle;

    private SpriteRenderer MadSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        MadSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float Distan = Vector3.Distance(transform.position, otherCircle.transform.position);
        float SumofRadius = Radius + otherCircle.Radius;

        if (SumofRadius >= Distan)
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }

        if (isColliding)
        {
            MadSpriteRenderer.material.color = Color.red;
        }
        else
        {
            MadSpriteRenderer.material.color = Color.white;
        }
    }
}
