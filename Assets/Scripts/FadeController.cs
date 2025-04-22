using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    private FadeInOut fade;

    void Start()
    {
        fade = GetComponent<FadeInOut>();

        fade.FadeOut();
    }
}
