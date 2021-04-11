using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sceneManager : MonoBehaviour
{
    public Image fadeImage;
    private GameObject dialogue;
    public AudioClip[] sound;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        dialogue = GameObject.Find("DialogManager");
        if (SceneManager.GetActiveScene().name == "1")
        {
            StartCoroutine(FadeIn(4f));
            StartCoroutine(StartDialogueWithDelay(0, 7f));
        }
        else if (SceneManager.GetActiveScene().name == "6")
        {
            StartCoroutine(StartDialogueWithDelay(11, 1.5f));
        }
        else if (SceneManager.GetActiveScene().name == "12")
        {
            source.clip = sound[0];
            source.Play();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartDialogueWithDelay(int dialogueNumber, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dialogue.GetComponent<dialog>().StartDialogueInteraction(dialogueNumber);
    }
    public IEnumerator FadeIn(float fadeInTime)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(1.0f);

        fadeImage.CrossFadeAlpha(0, fadeInTime, false);
        yield return new WaitForSeconds(fadeInTime);
        

    }
    public IEnumerator FadeOut(float fadeOutTime)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);

        fadeImage.CrossFadeAlpha(1, fadeOutTime, false);
        yield return new WaitForSeconds(fadeOutTime);


    }
    public IEnumerator Fade(float fadeInTime, float fadeOutTime)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.CrossFadeAlpha(1, fadeInTime, false);
        yield return new WaitForSeconds(fadeInTime);
        fadeImage.CrossFadeAlpha(0, fadeOutTime, false);
    }

}
