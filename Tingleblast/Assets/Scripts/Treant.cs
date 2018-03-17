using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TreantMovement))]
public class Treant : MonoBehaviour
{
    float gravity = -20.0f;
    float moveSpeed = 6.0f;
    Vector3 velocity;

    TreantMovement treantMovement;

    void Start()
    {
        treantMovement = GetComponent<TreantMovement>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));

        velocity.x = input.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        treantMovement.Move(velocity * Time.deltaTime);
    }
}
