using System.Collections;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //CREDIT TO MKs Unity https://youtu.be/pSEYdnAHIKg

    public Camera mainCamera;

    public float zoomSpeed = 5f;
    public float maxZoomFOV = 50f;
    public float normalFOV = 70f;
    public float zoomSmoothness = 0.1f;

    private bool isZooming = false;
    private bool inputsEnabled = true;

    //CREDIT TO 'DAVE / GAMEDEVELOPMENT' (https://www.youtube.com/watch?v=f473C43s8nE)

    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inputsEnabled) return;

        // Zoom in smoothly when right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(ZoomCoroutine(maxZoomFOV));
        }

        // Zoom out smoothly when right mouse button is released
        if (Input.GetMouseButtonUp(1))
        {
            StartCoroutine(ZoomCoroutine(normalFOV));
        }

        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //handles rotation
        yRotation += mouseX;

        xRotation -= mouseY;

        //limit looking up/down to 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        //rotate player along y axis
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    IEnumerator ZoomCoroutine(float targetFOV)
    {
        float startFOV = mainCamera.fieldOfView;
        float timer = 0;

        while (timer < zoomSmoothness)
        {
            mainCamera.fieldOfView = Mathf.Lerp(startFOV, targetFOV, timer / zoomSmoothness);
            timer += Time.deltaTime;
            yield return null;
        }

        mainCamera.fieldOfView = targetFOV;
    }

    public void EnableInputs()
    {
        inputsEnabled = true;
    }

    public void DisableInputs()
    {
        inputsEnabled = false;
    }
}
