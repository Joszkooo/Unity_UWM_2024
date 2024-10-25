using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundSquare : MonoBehaviour
{

    public float speed = 5f;
    public float sideLength = 10f;

    private Vector3 startPosition;
    private int currentDirection = 0; // 0: right, 1: up, 2: left, 3: down
    private float distanceMoved = 0f;
    private bool isRotating = false;

    // Rotation variables
    private Quaternion targetRotation;
    private float rotationSpeed = 200f;

    void Start()
    {
        startPosition = transform.position;

        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                isRotating = false;
            }
            return;
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        distanceMoved += speed * Time.deltaTime;

        if (distanceMoved >= sideLength)
        {
            distanceMoved = 0f;
            currentDirection = (currentDirection + 1) % 4;

            targetRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
            isRotating = true;
        }
    }
}
