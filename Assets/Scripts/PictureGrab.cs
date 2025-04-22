using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PictureGrab : MonoBehaviour
{
    private XRBaseInteractor interactor;
    private XRGrabInteractable grabInteractable;

    public GameObject pictureDialogue;
    public float dialogueTime = 5f;

    void Start()
    {
        pictureDialogue.SetActive(false);
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        //trigger dialogue
        StartCoroutine(PictureDialogue());

        interactor = args.interactorObject as XRBaseInteractor;
    }

    IEnumerator PictureDialogue()
    {
        yield return new WaitForSeconds(1f);
        pictureDialogue.SetActive(true);
        yield return new WaitForSeconds(dialogueTime);
        pictureDialogue.SetActive(false);
    }
}
