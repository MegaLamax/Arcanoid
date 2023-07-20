using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmove : MonoBehaviour
{

    //public float forceMagnitude = 5f;
    public float Speed = 5f;
    public float Max = 3f;
    public float Min = 1f;

    private Vector2 DirectionMove;
    private float NextMoveTime;

    //private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        NextMoveTime = Time.time + Random.Range(Min,Max);
        MoveDirectionBall();
        //rb = GetComponent<Rigidbody2D>();
        //MoveBall();

    }

    private void MoveDirectionBall()
    {
        float randomAngle = Random.Range(0f, 360f);
        DirectionMove = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
    }
    //private void MoveBall()
    //{
    //    Vector2 randomForce = Random.insideUnitCircle * forceMagnitude * Time.deltaTime;
    //    rb.AddForce(randomForce, ForceMode2D.Impulse);

    //    float interval = Random.Range(Min, Max);

    //    Invoke("MoveBall",interval);

    //}

    // Update is called once per frame
    void Update()
    {
        if (Time.time>=NextMoveTime)
        {
            MoveDirectionBall();
            NextMoveTime = Time.time + Random.Range(Min, Max);
        }

        transform.Translate(DirectionMove * Speed * Time.deltaTime);
    }
}
