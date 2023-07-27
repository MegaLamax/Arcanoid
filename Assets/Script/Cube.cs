using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool isCollinding;

    public Vector2 HalfSide;

    public Cube OtherCube;

    public float XLeft;
    public float XRight;
    public float YUp;
    public float YDown;

    private SpriteRenderer CubeRender;
        
    
    void Start()
    {
        CubeRender = gameObject.GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        isCollinding = CheckCollision();
    }

    bool CheckCollision()
    {

        XLeft = transform.position.x - HalfSide.x;
        XRight = transform.position.x + HalfSide.x;
        YUp = transform.position.y + HalfSide.y;
        YDown = transform.position.y - HalfSide.y;

        bool Ovelap = XLeft < OtherCube.XRight 
                      && XRight > OtherCube.XLeft 
                      && YDown < OtherCube.YUp 
                      && YUp > OtherCube.YDown;

        if(Ovelap)
        {
            CubeRender.material.color = Color.red;
        }
        else
        {
            CubeRender.material.color = Color.white;
        }
        return Ovelap;
    }

}
