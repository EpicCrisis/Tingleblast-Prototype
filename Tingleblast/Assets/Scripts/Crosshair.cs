using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Vector3 target;
    [SerializeField] private SpriteRenderer sRend;

    void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            FollowMouse();
        }
    }

    void FollowMouse()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(target.x, target.y, 0.0f);
    }
}
