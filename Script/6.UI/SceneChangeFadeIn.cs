using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangeFadeIn : MonoBehaviour

{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
   
    }


    IEnumerator FadeIn()
    {
        float alpha = 1.0f;
        while (alpha > 0.0f)
        {
            alpha -= 0.05f;
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        image.gameObject.SetActive(false);
    }
}
