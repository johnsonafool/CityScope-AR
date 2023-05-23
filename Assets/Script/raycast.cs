using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class raycast : MonoBehaviour
{
    [SerializeField] ARRaycastManager m_RaycastManager;
    [SerializeField] GameObject spawnedObject;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit> ();
    public Text DebugText;
    Camera arCam;

    public Vector3 webcamtest_tag_position;
    public Quaternion webcamtest_tag_rotation;
    public bool webcamtest_position_set;
    DetectionManager detect;
    bool object_spawned;
    bool change;

    void Start()
    {
        object_spawned = false;
        change = false;

        GameObject script1GO = GameObject.Find("Main Camera");
        detect = script1GO.GetComponent<DetectionManager>();
        
        if(detect.tag_position == Vector3.zero)
            Debug.Log($"{detect.tag_position}");
    }

    void Update()
    {
        if(detect.tag_position != Vector3.zero && change != true && detect.position_set == true)
        {
            Debug.Log($"{detect.tag_position}");

            webcamtest_tag_position = detect.tag_position;
            webcamtest_tag_rotation = detect.tag_rotation;
            webcamtest_position_set = detect.position_set;

            detect._webcamPreview.gameObject.SetActive(!detect._webcamPreview.gameObject.activeSelf);
            detect.arOrigin.gameObject.SetActive(!detect.arOrigin.gameObject.activeSelf);
            detect.aRSession.gameObject.SetActive(!detect.aRSession.gameObject.activeSelf);
            detect.cameraB.gameObject.SetActive(!detect.cameraB.gameObject.activeSelf);
            arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
            change = true;
        }
        
        if (webcamtest_position_set == false)
        {
            DebugText.text = "no inside";
            return;
        }
        else if (webcamtest_position_set == true)
        {
            Ray ray = new Ray(arCam.transform.position, webcamtest_tag_position - arCam.transform.position);

            if(m_RaycastManager.Raycast(ray, m_Hits,  TrackableType.PlaneWithinPolygon))
            {
                var hitpose = m_Hits[0].pose;

                if(!object_spawned)
                {
                    //Test
                    spawnedObject.SetActive(true);
                    spawnedObject.transform.position = webcamtest_tag_position;
                    spawnedObject.transform.rotation = hitpose.rotation;
                    
                    object_spawned = true;
                    DebugText.text = hitpose.position.ToString() + "\nRotation: " + hitpose.rotation.ToString();
                }
            }
        }
    }
}

