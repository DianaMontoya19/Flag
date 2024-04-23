using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageCameras : MonoBehaviour
{
    [SerializeField] GameObject Cam;
    [SerializeField] GameObject Altcam;

    bool MainCam = true;
    bool AltCam = false;

    public void ChangeMainCamera()
    {
        if (Input.GetKeyDown(KeyCode.Space) && MainCam)
        {
            Cam.SetActive(false);
            Altcam.SetActive(true);
        }
    }

    public void ChangeAltCamera()
    {
        if (Input.GetKeyDown(KeyCode.Space) && AltCam)
        {
            Altcam.SetActive(false);
            Cam.SetActive(true);            
        }
    }
}