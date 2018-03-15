using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 velocity = Vector2.zero;
    [SerializeField] private float maxSpeed = 5.0f;
    [SerializeField] private float mass = 30.0f;

    // Distance to adjust the magnitude of the velocity.
    [SerializeField] private float currentDist = 0.0f;
    [SerializeField] private float minDist = 0.5f;
    [SerializeField] private float maxDist = 3.0f;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        //transform.position += new Vector3(velocity.x, velocity.y, 0.0f);
        rb2d.position += velocity;
    }

    public void Move()
    {
        Vector2 direction = target.position - transform.position;
        AddForce2D(direction.magnitude, direction.normalized);
    }

    public void AddForce2D(float magnitude, Vector2 direction)
    {
        direction.Normalize();
        
        velocity = direction * CheckDistance(magnitude) / mass;
    }

    public float CheckDistance(float magnitude)
    {
        currentDist = Vector2.Distance(transform.position, target.position);

        if (currentDist >= maxDist)
        {
            return magnitude = maxSpeed;
        }
        else if (currentDist <= minDist)
        {
            return magnitude = 0.0f;
        }
        else
        {
            return magnitude;
        }
    }
}
