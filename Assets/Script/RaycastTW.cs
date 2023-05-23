using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RaycastTW : MonoBehaviour
{
    public Text RaycastPosition;
    public GameObject spawnPrefab;
    GameObject spawnedObject;
    public bool TaiwanSetted;
    DetectionTest Detection;
    ARRaycastManager arrayman;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public Vector2 PosXY;
    public Vector3 PosXYZ;
    public Quaternion Rotate;

    public void Start()
    {
        PosXYZ = spawnPrefab.transform.position;
        Rotate = spawnPrefab.transform.rotation;

        TaiwanSetted = false;
        arrayman = GetComponent<ARRaycastManager>();
    }

    public void SetObject()
    {
        //if(Input.touchCount > 0)
        //{
            if (arrayman.Raycast(PosXY, hits, TrackableType.PlaneWithinPolygon))
            {

            }

            if (arrayman.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitpose = hits[0].pose;

                if(!TaiwanSetted)
                {
                    spawnPrefab.SetActive(true);

                    spawnPrefab.transform.position = PosXYZ;
                    spawnPrefab.transform.rotation = Rotate;

                    RaycastPosition.text = "Raycast" + "\nPos: " + PosXYZ + "\nRotate: " + Rotate;
                    
                    TaiwanSetted = true;
                }
            }
        //}
    }
}
