using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateKey : MonoBehaviour
{
    public GameObject key;
    public Transform dropPosition;

    private GameObject currentKey;
    private bool keyDropped = false; 

    public void DropKey()
    {

        if (!keyDropped)
        {
            keyDropped = true;
            Debug.Log("Key Dropped");
            currentKey = Instantiate(key, dropPosition.position, dropPosition.rotation);
        } else
        {
            keyDropped = false;

            if (currentKey != null)
            {
                Debug.Log("Put Key Away");
                Destroy(currentKey);
                currentKey = null;
            }
        }
        
    }

}
