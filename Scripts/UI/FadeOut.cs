using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    Image imagere;
    TextMeshProUGUI textmeshimg;
    void Awake()
    {
        imagere = GetComponent<Image>();
        textmeshimg = GetComponent<TextMeshProUGUI>();
        Debug.Log(textmeshimg);

    }
    void Start()
    {
       
        if (imagere != null)
        {
            StartCoroutine(FadeOutMaterial(5f));
        }
        if(textmeshimg != null) 
        {
            Debug.Log("textfound");
            StartCoroutine(FadeOutMaterialText(5f));
        }

  
    }

    IEnumerator FadeOutMaterial(float fadeSpeed)
    {
 
        Color matColor = imagere.color;
        float alphaValue = imagere.color.a;

        while (imagere.color.a > 0f)
        {
            alphaValue -= Time.deltaTime / fadeSpeed;
            imagere.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
        imagere.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
    }

    IEnumerator FadeOutMaterialText(float fadeSpeed)
    {

        Color matColor = textmeshimg.color;
        float alphaValue = textmeshimg.color.a;

        while (textmeshimg.color.a > 0f)
        {
            alphaValue -= Time.deltaTime / fadeSpeed;
            textmeshimg.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
        textmeshimg.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
    }
}
