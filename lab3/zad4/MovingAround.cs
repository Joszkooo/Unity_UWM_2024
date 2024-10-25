using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAround : MonoBehaviour
{
    
    public float speed = 5f;
    private float planeSize = 10f; // Since the plane scale is 10, the full size is 20x20 units

    // The current target position to move toward
    private Vector3 targetPosition;

    void Start()
    {
        SetRandomTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();

        // If the player reaches the target position, set a new random target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    private void MoveTowardsTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-planeSize, planeSize);
        float randomZ = Random.Range(-planeSize, planeSize);

        // Set the new target position, keeping the Y position at 0.5f (above the plane)
        targetPosition = new Vector3(randomX, 0.5f, randomZ);
    }
}
