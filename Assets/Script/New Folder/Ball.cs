using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 2f;
    public float radius = 0.08f;

    public float wallLimitX;
    public float wallLimitY;

    public Vector3 initialDirection;

    public PlayerShip playerShip;

    private Vector3 _currentDirection;
    
    private void Start()
    {
        _currentDirection = initialDirection;
    }

    private void Update()
    {
        _currentDirection.Normalize();
        
        Vector3 movement = _currentDirection * (speed * Time.deltaTime);

        Vector3 newPosition = transform.position + movement;
        
        newPosition.x = Mathf.Clamp(newPosition.x, -wallLimitX, wallLimitX);

        if (newPosition.y + radius >= wallLimitY)
        {
            newPosition.y = wallLimitY - radius;
            _currentDirection.y *= -1f;
        }

        if (newPosition.y - radius <= -wallLimitY)
        {
            newPosition.y = -wallLimitY + radius;
            _currentDirection.y *= -1f;
        }

        if (newPosition.x + radius >= wallLimitX)
        {
            newPosition.x = wallLimitX - radius;
            _currentDirection.x *= -1f;
        }
        if (newPosition.x - radius <= -wallLimitX)
        {
            newPosition.x = -wallLimitX + radius;
            _currentDirection.x *= -1f;
        }
        
        
        transform.position = newPosition;
    }
}
