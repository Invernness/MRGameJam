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

    // Start is called before the first frame update
    void Start()
    {
        nextToBoss = false;
        bossGrabbed = false;
        timer = true;
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
        }

        if (bossGrabbed)
        {
            Boss.transform.position = GrabLocation.position;
            Boss.transform.LookAt(lookAt);
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
