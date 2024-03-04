using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsLeftRight : MonoBehaviour
{
    [SerializeField] private float positionLeftX;
    [SerializeField] private float positionRightX;
    [Space]
    [SerializeField] private float speed;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rigidbody.position.x <= positionLeftX)
        {
            GoRight();    // body righter positionRightX => GoRight
        }

        if (rigidbody.position.x >= positionRightX)
        {
            GoLeft();   // body lefter positionLeftX => GoLeft
        }

    }

    private void GoLeft()
    {
        rigidbody.velocity = new Vector2(-speed, 0);
    }

    private void GoRight()
    {
        rigidbody.velocity = new Vector2(speed, 0);
    }
}
