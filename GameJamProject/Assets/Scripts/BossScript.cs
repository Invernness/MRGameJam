using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject[] windows;
    public GameObject[] brokenWindows;
    [SerializeField] Collider[] col;
    [SerializeField] Animator anim;
    [SerializeField] GameObject hipsCol;
    public AudioClip strangleSound;
    public AudioClip death;
    bool playing = false;
    public float Health;
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

        if (GameObject.Find("Player").GetComponent<Grab>().bossGrabbed)
        {
            Ragdoll();
        }

        
        if (GameObject.Find("CameraHolder").GetComponent<Animator>().GetBool("Strangling") == true && playing == false)
        {
            print("Playing SFX");
            GetComponent<AudioSource>().PlayOneShot(strangleSound);
            playing = true;
        }
        if (GameObject.Find("CameraHolder").GetComponent<Animator>().GetBool("Strangling") == false)
        {
            print("Stop");
            GetComponent<AudioSource>().Stop();
            playing = false;
        }

    }

    void Die()
    {
        //GameObject.Destroy(this.gameObject);
        foreach (Collider collid in col)
        {
            collid.enabled = true;
        }
        anim.enabled = false;

        GetComponent<AudioSource>().Stop();

        GetComponent<AudioSource>().PlayOneShot(death);

    }

    public void Ragdoll()
    {
        foreach (Collider collid in col)
        {
            collid.enabled = true;
        }
        anim.enabled = false;
        hipsCol.GetComponent<CapsuleCollider>().enabled = false;
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
        hipsCol.GetComponent<Rigidbody>().AddForce(forceDir.transform.position * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
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
        */



    }


}
