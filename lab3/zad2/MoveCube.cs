using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 startPosition;
    private bool movingForward = true;

    public float distanceToMove = 10f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        
        float currentDistance = transform.position.x - startPosition.x;

        if (movingForward && currentDistance < distanceToMove)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        else if (movingForward && currentDistance >= distanceToMove)
        {
            movingForward = false;
        }

        else if (!movingForward && currentDistance > 0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        else if (!movingForward && currentDistance <= 0)
        {
            movingForward = true;
        }
    }
}
