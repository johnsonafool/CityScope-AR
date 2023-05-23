using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI = UnityEngine.UI;
using Klak.TestTools;
using UnityEngine.XR.ARFoundation;

sealed class DetectionManager : MonoBehaviour
{
    [SerializeField] Vector2Int _resolution = new Vector2Int(1280,  720);
    [SerializeField] int _decimation = 4;
    [SerializeField] float _tagSize = 0.05f;
    [SerializeField] Material _tagMaterial = null;
    [SerializeField] public UI.RawImage _webcamPreview = null;
    [SerializeField] UI.Text _debugText = null;
    [SerializeField] public Camera cameraA, cameraB;
    [SerializeField] public ARSessionOrigin arOrigin;
    [SerializeField] public ARSession aRSession;

    AprilTag.TagDetector _detector;
    TagDrawer _drawer;
    Vector3 temp;
    public WebCamTexture _webcamRaw;
    RenderTexture _webcamBuffer;
    Color32 [] _readBuffer;
    Vector3 tag_Pos = Vector3.zero;
    Quaternion tag_Rotation = Quaternion.identity;

    string tagpo, set;
    public List<AprilTag.TagPose> TagList = new List<AprilTag.TagPose>();
    public Vector3 tag_position = Vector3.zero;
    public Quaternion tag_rotation;
    public bool position_set = false;

    void Start()
    {
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
        var fov = Camera.main.fieldOfView * Mathf.Deg2Rad;
        _detector.ProcessImage(_readBuffer, fov, _tagSize);

        // Detected tag visualization
        DetectTag();

        if (TagList.Count > 0)
        {
            temp = TagList[0].Position;
            //temp[0] += 0.05f;
            float x = TagList[0].Rotation[0];
            float y = TagList[0].Rotation[1];
            float z = TagList[0].Rotation[2];
            float w = TagList[0].Rotation[3];
            float t = 2 * (w * y - z * w);

            if (Mathf.Abs(t) > 1.0) t = t / Mathf.Abs(t);

            double x_angle = Mathf.Atan2((2 * (w * x + y * z)), (1 - 2 * (x * x + y * y)));
            double y_angle = Mathf.Asin(t);
            double z_angle = Mathf.Atan2((2 * (w * z + x * y)), (1 - 2 * (z * z + y * y)));

            temp[0] += 0.05f * Mathf.Cos(120 * Mathf.Deg2Rad) * Mathf.Cos(-40 * Mathf.Deg2Rad);
            temp[1] += 0.05f * Mathf.Cos(120 * Mathf.Deg2Rad) * Mathf.Sin(-40 * Mathf.Deg2Rad);
            temp[2] += 0.05f * Mathf.Sin(120 * Mathf.Deg2Rad);

            _drawer.Draw(TagList[0].ID, TagList[0].Position, TagList[0].Rotation, _tagSize);

            Debug.Log(TagList[0].Position);
            Debug.Log(TagList[0].Rotation);
        }

        TagList.Clear();
        // Profile data output (with 30 frame interval)
        if (Time.frameCount % 30 == 0)
        {
            _debugText.text = _detector.ProfileData.Aggregate
            ("Profile (usec)", (c, n) => $"{c}\n{n.name} : {n.time}");
        }
    }
    void DetectTag()
    {
        foreach (var tag in _detector.DetectedTags)
        {
            TagList.Add(tag);
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

                }
                else if(position_set==false)
                {
                    set = "false";
                    set = tagpo + set;
                    _debugText.text = set;
                }
            }
        }
    }
}