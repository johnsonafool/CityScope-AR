using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARTrackedImageManager))]
public class image_tracking : MonoBehaviour
{
    // //public static MultiTrackedImageManager Instance { get { return instance; } }
    // //private static MultiTrackedImageManager instance;

    // private ARTrackedImageManager m_TrackedImageManager;
    // private GameObject curobject;
    // private string PREFABFOLDER = "Prefabs/";
    // private ARSessionOrigin aRSessionOrigin;

    // #region PlaneDetectionNecessities
    // [SerializeField]
    // private ARPlaneManager aRPlaneManager;

    // private ARPlane aRPlane;
    // #endregion

    // //public List<MultiTrackedImage> Images = new List<MultiTrackedImage>();

    // private void Awake()
    // {
    //     if (instance != null) { Destroy(instance); }
    //     instance = this;
    //     m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
    //     aRSessionOrigin = GetComponent<ARSessionOrigin>();
    //     curobject = null;
    //     aRPlaneManager = GetComponent<ARPlaneManager>();
    // }

    // private void PlanesChanged(ARPlanesChangedEventArgs args)
    // {
    //     if (args.added != null)
    //     {
    //     aRPlane = args.added[0];
    //     }
    // }

    // void OnEnable()
    // {
    //     m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    //     aRPlaneManager.planesChanged += PlanesChanged;
    // }
    // void OnDisable()
    // {
    //     m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    // }

    // void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    // {

    //     foreach (var trackedImage in eventArgs.updated)
    //     {
    //         OnImageUpdated(trackedImage.referenceImage.texture.name, trackedImage.name, trackedImage);
    //     }

    //     foreach (var trackedImage in eventArgs.added)
    //     {
    //         OnImageAdded(trackedImage.referenceImage.texture.name, trackedImage.name, trackedImage);
    //     }
    // }

    // public void OnImageUpdated(string textureName, string name, ARTrackedImage m_ARTrackedImage)
    // {

    //     for (int i = 0; i < Images.Count; i++)
    //     {
    //         //if we have a match for the object and we have regained tracking and the current object is not the one for the trigger we just found
    //         if (m_ARTrackedImage.trackingState == TrackingState.Tracking)
    //         {

    //             //this checks to make sure we are tracking the right image target
    //             if (!string.Equals(Images[i].target.name, textureName)) { continue; }

    //             //this checks to see if our current object is equal to the name of the image target so we don't delete and duplicate
    //             if (string.Equals(curobject.name, Images[i].target.name)) { continue; }

    //             //for some reason we are getting updates from non visible targets
    //             if (curobject != null) { Destroy(curobject); }

    //             GameObject go = GameObject.Find(name);
                
    //             GameObject prefab = Resources.Load($"{PREFABFOLDER}{Images[i].path}") as GameObject;

    //             GameObject target = Instantiate(prefab, arPlane.transform.position, Quaternion.identity);

    //             curobject = target;
    //             curobject.name = Images[i].target.name;

    //             Images[i].go = go;
    //             target.transform.Rotate(Vector3.up, 180);
    //             target.transform.SetParent(go.transform);
    //             target.transform.localPosition = Vector3.zero;
    //         }
    //     }
    // }

    // public void OnImageAdded(string textureName, string name, ARTrackedImage m_ARTrackedImage)
    // {

    //     //PrefabManager.s.ClearPrefabs();
    //     for (int i = 0; i < Images.Count; i++)
    //     {
    //         if (string.Equals(Images[i].target.name, textureName) && Images[i].go == null)
    //         {
    //             //Destroy the existing AR Animation
    //             if (curobject != null) { Destroy(curobject); }

    //             GameObject go = GameObject.Find(name);
                
    //             GameObject prefab = Resources.Load($"{PREFABFOLDER}{Images[i].path}") as GameObject;

    //             //Instantiate the prefab with the position of arPlane
    //             GameObject target = Instantiate(prefab, arPlane.transform.position, Quaternion.identity);

    //             curobject = target;
    //             curobject.name = Images[i].target.name;

    //             Images[i].go = go;
    //             target.transform.Rotate(Vector3.up, 180);
    //             target.transform.SetParent(go.transform);
    //             target.transform.localPosition = Vector3.zero;
    //         }
    //     }
    // }
}
