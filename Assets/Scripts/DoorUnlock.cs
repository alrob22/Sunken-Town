using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorUnlock : MonoBehaviour
{
    public Transform doorPivot;
    private float doorSpeed = 5f;

    private bool isUnlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            isUnlocked = true;
        }
    }

    private void Update()
    {
        if (isUnlocked)
        {
            doorPivot.rotation = Quaternion.Lerp(doorPivot.rotation, Quaternion.Euler(0f, -90f, 0f), Time.deltaTime * doorSpeed);
        }
    }
}
