using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour
{




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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hurt")
        {
            GetComponentInParent<BossScript>().Health = GetComponentInParent<BossScript>().Health - 20f;


        }
    }



}
