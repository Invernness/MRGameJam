using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] GameObject[] windows;
    [SerializeField] GameObject[] brokenWindows;
    [SerializeField] Collider[] col;
    [SerializeField] Animator anim;

    [SerializeField] float Health;
    bool timer;
    // Start is called before the first frame update
    void Start()
    {
        Health = 100f;
        timer = true;

        //Invoke("Die", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("CameraHolder").GetComponent<Animator>().GetBool("Strangling") == true)
        {
            Strangle();
        }

        if(Health <= 0)
        {
            Health = 0f;
            Die();
        }



    }

    void Die()
    {
        //GameObject.Destroy(this.gameObject);
        foreach (Collider collid in col)
        {
            //collid.enabled = true;
        }
        //anim.enabled = false;

    }

    void Strangle()
    {
        if (timer)
        {
            Health = Health - 10f;
            timer = false;
            Invoke("SetTimer", 1f);
        }
    }

    void SetTimer()
    {
        timer = true;
    }

    public void Throw(Transform forceDir, float force)
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Window1")
        {
            windows[0].gameObject.SetActive(false);
            brokenWindows[0].gameObject.SetActive(true);
        }

        if (collision.collider.tag == "Window2")
        {
            windows[1].gameObject.SetActive(false);
            brokenWindows[1].gameObject.SetActive(true);
        }

        if (collision.collider.tag == "Window3")
        {
            windows[2].gameObject.SetActive(false);
            brokenWindows[2].gameObject.SetActive(true);
        }

    }


}
