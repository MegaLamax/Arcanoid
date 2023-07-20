using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmove : MonoBehaviour
{

    public float forceMagnitude = 5f;
    public float Max = 3f;
    public float Min = 1f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        MoveBall();

    }

    private void MoveBall()
    {
        Vector2 randomForce = Random.insideUnitCircle * forceMagnitude * Time.deltaTime;
        rb.AddForce(randomForce, ForceMode2D.Impulse);

        float interval = Random.Range(Min, Max);

        Invoke("MoveBall",interval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
