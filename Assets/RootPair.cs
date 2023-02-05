using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RootPair : MonoBehaviour
{
    [SerializeField]
    Image male;
    [SerializeField]
    Image female;

    [SerializeField]
    float fadeDuration = 0.5f;

    public void display() {
            StartCoroutine(fadeIn(fadeDuration));
        }
    IEnumerator fadeIn(float duration){
        float elapsedTime = 0;
        float ratio = elapsedTime / duration;
        while (ratio < 1f)
        {
            elapsedTime += Time.deltaTime;
            ratio = elapsedTime / fadeDuration;
            male.color = Color.Lerp(new Color32(0,0,0,255), new Color32(0,0,0,0), ratio);
            female.color = Color.Lerp(new Color32(0,0,0,255), new Color32(0,0,0,0), ratio);
            yield return null;
        }
    }
}

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Enter;
    public bool Exit;
    public float duration;
    UnityEngine.UI.Image image;
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();

        if(Enter){
            StartCoroutine(fadeIn(duration));
        }
    }

    public void startExit(){
        StartCoroutine(fadeOut(duration));
    }

    IEnumerator fadeOut(float d){
        float elapsedTime = 0;
        float ratio = elapsedTime / d;
        while (ratio < 1f)
        {
            elapsedTime += Time.deltaTime;
            ratio = elapsedTime / duration;
            image.color = Color.Lerp( new Color32(0, 0, 0, 0), new Color32(0, 0, 0, 255), ratio);
            yield return null;
        }
    }

    IEnumerator fadeIn(float d){
        float elapsedTime = 0;
        float ratio = elapsedTime / d;
        while (ratio < 1f)
        {
            elapsedTime += Time.deltaTime;
            ratio = elapsedTime / duration;
            image.color = Color.Lerp(new Color32(0,0,0,255), new Color32(0,0,0,0), ratio);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
