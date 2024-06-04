using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] GameObject[] windows;
    [SerializeField] GameObject[] brokenWindows;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
