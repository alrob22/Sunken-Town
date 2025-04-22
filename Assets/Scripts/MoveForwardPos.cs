using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardPos : MonoBehaviour
{
    [Tooltip("Movement speed in units per second")]
    public float speed = 5f;

    [Tooltip("Optional: assign a specific Camera here; if null, Camera.main will be used")]
    public Camera playerCamera;

    void Start()
    {
        // Cache the main camera if none assigned in Inspector :contentReference[oaicite:5]{index=5}
        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    void Update()
    {
        // When the backquote/tilde key is held down :contentReference[oaicite:6]{index=6}
        if (Input.GetKey(KeyCode.BackQuote))
        {
            // Get the camera's forward vector, project onto XZ plane to ignore Y tilt, then normalize
            Vector3 direction = Vector3.ProjectOnPlane(
                playerCamera.transform.forward,  // Camera's forward direction :contentReference[oaicite:7]{index=7}
                Vector3.up                       // Project onto horizontal (Y=0) plane :contentReference[oaicite:8]{index=8}
            ).normalized;                       // Ensure unit length :contentReference[oaicite:9]{index=9}

            // Move the player in that direction, scaled by speed and frame time :contentReference[oaicite:10]{index=10}
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
