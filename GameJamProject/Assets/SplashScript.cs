using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    public GameObject text;
    public GameObject image;
    public GameObject Title;
    public AudioClip Sound;

    bool FadeIn = false;

    bool FadeOut = false;

    bool timer = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sequence());

        

    }

    private void Update()
    {
        /*
        if (FadeIn && timer)
        {
            text.GetComponent<TextMeshProUGUI>().alpha = text.GetComponent<TextMeshProUGUI>().alpha + 0.05f;

            timer = false;
            Invoke("Timer", 0.1f);
            print("fading in");
        }

        if (FadeOut && timer)
        {
            text.GetComponent<TextMeshProUGUI>().alpha = text.GetComponent<TextMeshProUGUI>().alpha - 0.05f;

            timer = false;
            Invoke("Timer", 0.1f);
            print("fading out");
        }
        */
    }

    void Timer()
    {
        timer = true;
    }


    IEnumerator Sequence()
    {
        
        yield return new WaitForSeconds(3);

        GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("Trigger");


        yield return new WaitForSeconds(3);
        text.SetActive(false);
        image.SetActive(false);
        Title.SetActive(true);
        Invoke("SFX", 0.4f);

        GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("FadeAgain");

        yield return new WaitForSeconds(3);

        GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("Trigger");

        yield return new WaitForSeconds(3);


        SceneManager.LoadScene(1);


        yield return null;
    }

    void SFX()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(Sound);
    }

}
