using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DiaryGrab : MonoBehaviour
{
    private XRBaseInteractor interactor;
    private XRGrabInteractable grabInteractable;

    public GameObject diary;
    public GameObject backButton;
    public GameObject keyButton;
    public GameObject diaryDialogue;
    public float dialogueTime = 5f;

    void Start()
    {
        diary.SetActive(false);
        backButton.SetActive(false);
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        diary.SetActive(true);
        backButton.SetActive(true);
        keyButton.SetActive(false);

        interactor = args.interactorObject as XRBaseInteractor;
    }

    public void Back()
    {
        backButton.SetActive(false);
        diary.SetActive(false);
        keyButton.SetActive(true);

        //trigger dialogue
        StartCoroutine(PutDiaryDown());
    }

    IEnumerator PutDiaryDown()
    {
        yield return new WaitForSeconds(1f);
        diaryDialogue.SetActive(true);
        yield return new WaitForSeconds(dialogueTime);
        diaryDialogue.SetActive(false);
    }
}
