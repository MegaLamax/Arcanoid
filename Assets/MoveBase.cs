using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    public float speed = 0.1f;

    public float limitH = 8f;

    public float limitV = 4f;
    void Update()
    {
        //Rigt, Left and limits
        float RigtLeftValue = Input.GetAxis("Horizontal");

        Vector3 currentPosH = transform.position;

        float move = RigtLeftValue * speed * Time.deltaTime;

        currentPosH.x += move;

        if (currentPosH.x < -limitH)
        {
            currentPosH.x = -limitH;
        }

        if (currentPosH.x > limitH)
        {
            currentPosH.x = limitH;
        }

        transform.position = currentPosH;

        //Up, Down and limits

        float UpDownValue = Input.GetAxis("Vertical");

        Vector3 currentPosV = transform.position;

        float movement = UpDownValue * speed * Time.deltaTime;

        currentPosV.y += movement;

        if (currentPosV.y < -limitV)
        {
            currentPosV.y = -limitV;
        }

        if (currentPosV.y > limitV)
        {
            currentPosV.y = limitV;
        }

        transform.position = currentPosV;

        /* if (inputValue == -1f && currentPos.x > -limit)
         {
             currentPos.x -= speed;

             if (currentPos.x < -limit)
             {
                 currentPos.x = -limit;
             }
         }
         else if(inputValue == 1f && currentPos.x > limit)
         {
             currentPos.x = speed;

             if (currentPos.x > limit)
             {
                 currentPos.x = limit;
             }
         }*/

    }
}
