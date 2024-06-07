using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour
{

    public AudioClip[] gruntArray;
    AudioClip grunt;
    public AudioClip[] thumpArray;
    AudioClip thump;

    public AudioClip falling;

    bool timer = true;
    bool thumpTimer = true;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Window1")
        {
            GetComponentInParent<BossScript>().windows[0].gameObject.SetActive(false);
            GetComponentInParent<BossScript>().brokenWindows[0].gameObject.SetActive(true);
        }

        if (collision.collider.tag == "Window2")
        {
            GetComponentInParent<BossScript>().windows[1].gameObject.SetActive(false);
            GetComponentInParent<BossScript>().brokenWindows[1].gameObject.SetActive(true);
        }

        if (collision.collider.tag == "Window3")
        {
            GetComponentInParent<BossScript>().windows[2].gameObject.SetActive(false);
            GetComponentInParent<BossScript>().brokenWindows[2].gameObject.SetActive(true);
        }
        if (collision.collider.tag == "Hurt")
        {
            GetComponentInParent<BossScript>().Health = GetComponentInParent<BossScript>().Health - 20f;


        }

        Grunt();

        if (collision.collider.tag != "Window1" || collision.collider.tag != "Window2" || collision.collider.tag != "Window3")
        {
            Thump();
        }


    }
    
    void Thump()
    {
        if (thumpTimer)
        {
            thump = thumpArray[Random.Range(0, thumpArray.Length)];
            GetComponent<AudioSource>().PlayOneShot(thump);
            thumpTimer = false;
            Invoke("ResetTimer", 0.75f);
        }
    }

    void Grunt()
    {
        if(timer)
        {
            grunt = gruntArray[Random.Range(0, gruntArray.Length)];
            GetComponent<AudioSource>().PlayOneShot(grunt);
            timer = false;
            Invoke("ResetTimer", 0.75f);
        }



    }

    void ResetTimer()
    {
        timer = true;
        thumpTimer = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hurt")
        {
            GetComponentInParent<BossScript>().Health = GetComponentInParent<BossScript>().Health - 20f;


        }
        if (other.tag == "Falling")
        {
            GetComponent<AudioSource>().PlayOneShot(falling);


        }


    }



}
