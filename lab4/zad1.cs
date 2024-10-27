using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int numberOfObjects = 10;
    public GameObject block;
    public List<Material> materials = new List<Material>();
    int objectCounter = 0;

    // obiekt do generowania

    void Start()
    {
        GeneratePositions();

        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    void GeneratePositions()
    {
        // Get the bounds of the platform this script is attached to
        Bounds platformBounds = GetComponent<Renderer>().bounds;

        // Define ranges for x and z based on platform bounds
        float minX = platformBounds.min.x;
        float maxX = platformBounds.max.x;
        float minZ = platformBounds.min.z;
        float maxZ = platformBounds.max.z;

        // Generate random unique x and z positions
        List<float> posX = new List<float>(Enumerable.Range(0, (int)(maxX - minX)).OrderBy(x => UnityEngine.Random.value).Take(numberOfObjects).Select(x => minX + x));
        List<float> posZ = new List<float>(Enumerable.Range(0, (int)(maxZ - minZ)).OrderBy(x => UnityEngine.Random.value).Take(numberOfObjects).Select(z => minZ + z));

        for (int i = 0; i < numberOfObjects; i++)
        {
            float yPosition = 5.0f; // Set y-position as 5 for now; adjust as needed
            positions.Add(new Vector3(posX[i], yPosition, posZ[i]));
        }
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");

        foreach(Vector3 pos in positions)
        {
            GameObject newObject = Instantiate(block, pos, Quaternion.identity);

            if (materials.Count > 0)
            {
                Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Count)];
                newObject.GetComponent<Renderer>().material = randomMaterial;
            }
            objectCounter++;

            yield return new WaitForSeconds(delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}