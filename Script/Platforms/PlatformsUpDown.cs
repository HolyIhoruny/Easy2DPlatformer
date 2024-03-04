using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsUpDown : MonoBehaviour
{
    [SerializeField] private float positionUpY;
    [SerializeField] private float positionDownY;

    [SerializeField] private float speed;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rigidbody.position.y >= positionUpY)
        {
            GoDown();   // body over positionUpY => GoDown
        }

        if (rigidbody.position.y <= positionDownY)
        {
            GoUp();    // body under positionDownY => GoUp
        }

    }

    private void GoDown()
    {
        rigidbody.velocity = new Vector2(0, -speed);
    }

    private void GoUp()
    {
        rigidbody.velocity = new Vector2(0, speed);
    }
}
