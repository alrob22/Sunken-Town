using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string sceneName;

    private FadeInOut fade;

    private void Start()
    {
        fade = GetComponent<FadeInOut>();
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("MainCamera"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ToScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToOceanBottom()
    {
        StartCoroutine(ToOceanBottomHelper());
    }

    public IEnumerator ToOceanBottomHelper()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("ocean_bottom");
    }
}
