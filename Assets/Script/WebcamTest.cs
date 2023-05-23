using UnityEngine;
using System.Linq;
using UI = UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class WebcamTest : MonoBehaviour
{
    [SerializeField] Vector2Int _resolution = new Vector2Int(1280,  720);
    [SerializeField] int _decimation = 4;
    [SerializeField] float _tagSize = 0.05f;
    [SerializeField] Material _tagMaterial = null;
    [SerializeField] public UI.RawImage _webcamPreview = null;
    [SerializeField] UI.Text _debugText = null;
    [SerializeField] public Camera cameraA;
    [SerializeField] public Camera cameraB;
    [SerializeField] public ARSessionOrigin arOrigin;
    [SerializeField] public ARSession aRSession;

    // Webcam input and buffer
    public WebCamTexture _webcamRaw;
    RenderTexture _webcamBuffer;
    Color32 [] _readBuffer;
    // public SpawnableManager _spawnableManager;
    

    // AprilTag detector and drawer
    AprilTag.TagDetector _detector;
    TagDrawer _drawer;
    [SerializeField] List<GameObject> tagObjList = new List<GameObject>();
    [SerializeField] List<GameObject> positionList = new List<GameObject>();
    [SerializeField] GameObject Taiwan = null;
    [SerializeField] public GameObject Tagdetection = null;

    private Dictionary<int, GameObject> tagObjDict = new Dictionary<int, GameObject>();
    public Vector3 tag_position = Vector3.zero;
    public Quaternion tag_rotation;

    public bool position_set = false;

    void Start()
    {
        /*foreach (var v in tagObjList) 
        {
            //tagObjDict.Add(tagObjDict.Count, v);
            toggle.isOn = v.activeSelf;
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }*/

        // Webcam initialization
        _webcamRaw = new WebCamTexture(_resolution.x, _resolution.y, 60);
        _webcamBuffer = new RenderTexture(_resolution.x, _resolution.y, 0);
        _readBuffer = new Color32 [_resolution.x * _resolution.y];

        _webcamRaw.Play();
        _webcamPreview.texture = _webcamBuffer;

        // Detector and drawer
        _detector = new AprilTag.TagDetector(_resolution.x, _resolution.y, _decimation);
        _drawer = new TagDrawer(_tagMaterial);
    }

    void OnDestroy()
    {
        Destroy(_webcamRaw);
        Destroy(_webcamBuffer);

        _detector.Dispose();
        _drawer.Dispose();
    }

    int last_obj;

    void Update()
    {
        // Check if the webcam is ready (needed for macOS support)
        if (_webcamRaw.width <= 16) return;

        // Check if the webcam is flipped (needed for iOS support)
        if (_webcamRaw.videoVerticallyMirrored)
            _webcamPreview.transform.localScale = new Vector3(1, -1, 1);

        // Webcam image buffering
        _webcamRaw.GetPixels32(_readBuffer);
        Graphics.Blit(_webcamRaw, _webcamBuffer);

        // AprilTag detection
        var fov = GetComponent<Camera>().fieldOfView * Mathf.Deg2Rad;

        _detector.ProcessImage(_readBuffer, fov, _tagSize);

        // Detected tag visualization
        Vector3 tag_Pos = Vector3.zero;
        Quaternion tag_Rotation = Quaternion.identity;

        int tag_middle = 10;
        int Sphere_count = 0;
        string tagpo;
        string set;

        foreach (var tag in _detector.DetectedTags)
        {
            tag_Pos += tag.Position;
            tag_Rotation = tag.Rotation;

            if(tag.ID==0 && tag_position==Vector3.zero)
            {
                tag_position = tag.Position;
                tag_rotation = tag.Rotation;
                Debug.Log($"{tag.ID} ,{tag_position} ,{tag.Rotation}");

                position_set = true;
                tagpo = tag_position.ToString();
                if(position_set==true)
                {
                    set = "true";
                    set = tagpo + set;
                    _debugText.text = set;
                }else if(position_set==false)
                {
                    set = "false";
                    set = tagpo + set;
                    _debugText.text = set;
                }
            }            
            _drawer.Draw(tag.ID, tag.Position, tag.Rotation, _tagSize);  // change tag.Position
            tagObjList[tag.ID].transform.position = tag.Position;
            tagObjList[tag.ID].transform.rotation = tag.Rotation;
        }
    }
}
