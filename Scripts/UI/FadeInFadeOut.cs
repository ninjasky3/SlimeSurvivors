using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FadeInFadeOut : MonoBehaviour
{
    public List<Image> imagere;
    public TextMeshProUGUI textmeshimg;

    void Awake()
    {

    }
    private void OnEnable()
    {
        Invoke(nameof(EnableFade), 2f);

        Invoke(nameof(Deactivateme), 7f);


    }
    public void EnableFade()
    {

        if (imagere != null)
        {
            foreach (var item in imagere)
            {
                StartCoroutine(FadeInMaterial(1f,item));
            }
            
        }
        if (textmeshimg != null)
        {
            Debug.Log("textfound");
            StartCoroutine(FadeInMaterialText(1f));
        }
    }
    void Deactivateme()
    {
        this.gameObject.SetActive(false);
    }
    void Start()
    {

    }

    IEnumerator FadeInMaterial(float fadeSpeed,Image item)
    {

            Color matColor = item.color;
            float alphaValue = 0f;

            while (item.color.a < 1f)
            {
                alphaValue += Time.deltaTime / fadeSpeed;
                item.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
                yield return null;
            }
            item.color = new Color(matColor.r, matColor.g, matColor.b, 1f);

            // Wait for 2 seconds before fading out
            yield return new WaitForSeconds(2f);

        foreach (var imageitem in imagere)
        {
            StartCoroutine(FadeOutMaterial(fadeSpeed,item));
        }
       
        
        
    }

    IEnumerator FadeInMaterialText(float fadeSpeed)
    {

        Color matColor = textmeshimg.color;
        float alphaValue = 0f;

        while (textmeshimg.color.a < 1f)
        {
            alphaValue += Time.deltaTime / fadeSpeed;
            textmeshimg.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
        textmeshimg.color = new Color(matColor.r, matColor.g, matColor.b, 1f);

        // Wait for 2 seconds before fading out
        yield return new WaitForSeconds(2f);

        StartCoroutine(FadeOutMaterialText(fadeSpeed));
    }

    IEnumerator FadeOutMaterial(float fadeSpeed,Image item)
    {


            Color matColor = item.color;
            float alphaValue = item.color.a;

            while (item.color.a > 0f)
            {
                alphaValue -= Time.deltaTime / fadeSpeed;
                item.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
                yield return null;
            }
            item.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
        
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
