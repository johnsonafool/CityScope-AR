using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PinFaceMe : MonoBehaviour
{
    // private ARCameraManager arCameraManager;
    [SerializeField] Camera ARCam;

    private void Awake()
    {
        // arCameraManager = FindObjectOfType<ARCameraManager>();
    }

    private void Update()
    {
        transform.LookAt(ARCam.transform);
    }
}
