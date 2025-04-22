using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TicketGrab : MonoBehaviour
{
    private XRBaseInteractor interactor;
    private XRGrabInteractable grabInteractable;

    public GameObject ticketDialogue;
    public GameObject ticketDialogue2;

    public GameObject ticketUI;

    public float dialogueTime = 5f;

    void Start()
    {
        ticketDialogue.SetActive(false);
        ticketDialogue2.SetActive(false);
        ticketUI.SetActive(false);

        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        ticketUI.SetActive(true);
        //trigger dialogue
        StartCoroutine(TicketDialogue());

        interactor = args.interactorObject as XRBaseInteractor;
    }

    IEnumerator TicketDialogue()
    {
        yield return new WaitForSeconds(1f);
        ticketDialogue.SetActive(true);
        yield return new WaitForSeconds(dialogueTime);
        ticketDialogue.SetActive(false);
        ticketDialogue2.SetActive(true);
        yield return new WaitForSeconds(dialogueTime);
        ticketDialogue.SetActive(false);
        ticketDialogue2.SetActive(false);
        ticketUI.SetActive(false);
    }


}
