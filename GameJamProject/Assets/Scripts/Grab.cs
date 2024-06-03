using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] bool nextToBoss;
    [SerializeField] GameObject Boss;
    [SerializeField] Transform GrabLocation;
    [SerializeField] bool bossGrabbed;
    [SerializeField] Transform lookAt;
    bool timer;
    [SerializeField] Transform forceDir;
    float force;

    // Start is called before the first frame update
    void Start()
    {
        nextToBoss = false;
        bossGrabbed = false;
        timer = true;
        force = -200f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && nextToBoss && !bossGrabbed && timer)
        {
            bossGrabbed = true;
            timer = false;
            Invoke("SetTimer", 0.2f);
        }
        if (Input.GetMouseButtonDown(0) && bossGrabbed && timer)
        {
            bossGrabbed = false;
            timer = false;
            Invoke("SetTimer", 0.2f);
            Boss.GetComponent<CapsuleCollider>().enabled = true;
        }

        if (bossGrabbed)
        {
            Boss.transform.position = GrabLocation.position;
            Boss.transform.LookAt(lookAt);
            Boss.GetComponent<CapsuleCollider>().enabled = false;
        }

        if(bossGrabbed && Input.GetMouseButtonDown(1))
        {
            bossGrabbed = false;
            Boss.GetComponent<BossScript>().Throw(forceDir, force);
            Boss.GetComponent<CapsuleCollider>().enabled = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boss")
        {
            nextToBoss = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boss")
        {
            nextToBoss = false;
        }
    }

    void SetTimer()
    {
        timer = true;
    }

}
