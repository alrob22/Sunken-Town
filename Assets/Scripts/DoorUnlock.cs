using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorUnlock : MonoBehaviour
{
    public Transform doorPivot;
    private float doorSpeed = 5f;
    public GameObject dialogueBox;
    public float dialogueTime = 5f;

    private bool isUnlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Key"))
        {
            Debug.Log("Door unlocked!");
            isUnlocked = true;
        } else
        {
            dialogueBox.SetActive(true);
            StartCoroutine(WaitBeforeDestroy());
        }
    }

    private void Start()
    {
        dialogueBox.SetActive(false);
    }
    void Update()
    {
        if (isUnlocked)
        {
            doorPivot.rotation = Quaternion.Lerp(doorPivot.rotation, Quaternion.Euler(0f, -90f, 0f), Time.deltaTime * doorSpeed);
        }
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(dialogueTime);
        dialogueBox.SetActive(false);
    }
}