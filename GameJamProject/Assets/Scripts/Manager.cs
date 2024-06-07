using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public AudioClip GetOut;
    public AudioClip crying;
    public GameObject darren;
    public AudioClip Next;

    public GameObject door;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSequence());
    }
    

    IEnumerator StartSequence()
    {
        yield return new WaitForSeconds(3);


        GetComponent<AudioSource>().PlayOneShot(GetOut);

        yield return new WaitForSeconds(11);

        door.GetComponent<Animator>().SetTrigger("Open");

        yield return new WaitForSeconds(1);

        darren.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        darren.GetComponent<AudioSource>().PlayOneShot(crying);

        yield return new WaitForSeconds(7);

        GetComponent<AudioSource>().PlayOneShot(Next);

        yield return new WaitForSeconds(2);

        GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("Trigger");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(2);




        yield return null;
    }



}
