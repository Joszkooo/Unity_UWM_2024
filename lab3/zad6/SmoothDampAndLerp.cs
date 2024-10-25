using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDampAndLerp : MonoBehaviour
{
    public Transform target;  // The object to follow (Target)
    public bool useSmoothDamp = true; // Toggle between SmoothDamp and Lerp
    public float smoothTime = 0.3f;   // Smoothing time for SmoothDamp
    public float lerpSpeed = 5f;      // Speed factor for Lerp

    private Vector3 velocity = Vector3.zero; // Used by SmoothDamp

    void Start()
    {

    }
    
    void Update()
    {
        if (useSmoothDamp)
        {
            // SmoothDamp follows the target's position smoothly
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        }
        else
        {
            // Lerp smoothly interpolates the follower's position towards the target
            transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed * Time.deltaTime);
        }
    }
}
