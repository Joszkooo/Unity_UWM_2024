using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class RandomCubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab of the cube
    public int numberOfCubes = 10; // Number of cubes to generate
    private float planeSize = 5f; // Since we scaled the plane by 5, the plane size is 10x10 units

    private HashSet<Vector2> usedPositions = new HashSet<Vector2>(); // To track occupied positions

    void Start()
    {
        // Generate cubes at random positions on the plane
        SpawnCubes();
    }

    void SpawnCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = GetRandomPosition();

            // Instantiate the cube at the random position
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector2 randomGridPos;
        
        // Keep generating positions until we find one that isn't already used
        do
        {
            // Random X and Z values between -5 and 5 (since plane is scaled by 5, which gives us a 10x10 unit area)
            float randomX = Random.Range(-planeSize, planeSize);
            float randomZ = Random.Range(-planeSize, planeSize);

            // Round the positions to the nearest integer for grid-based placement
            randomGridPos = new Vector2(Mathf.Round(randomX), Mathf.Round(randomZ));

        } while (usedPositions.Contains(randomGridPos)); // Ensure no overlap

        // Mark this position as used
        usedPositions.Add(randomGridPos);

        // Return the position in 3D (Y is set to 0.5f to place cubes slightly above the plane)
        return new Vector3(randomGridPos.x, 0.5f, randomGridPos.y);
    }
}
