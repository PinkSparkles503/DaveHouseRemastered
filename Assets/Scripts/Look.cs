using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public Transform player;

    public float mouseSens;

    float x = 0;
    float y = 0;

    public bool lockRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        mouseSens = PlayerPrefs.GetFloat("Sensitivity");
    }

    // Update is called once per frame
    void Update()
    {
        if (!lockRot)
        {
            x += -Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
            y += Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        }
        //Clamp camera

        y = y % 360;
        x = Mathf.Clamp(x, -90, 90);

        //Rotate camera to axis
        transform.localRotation = Quaternion.Euler(x, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, y, 0);
    }
}
