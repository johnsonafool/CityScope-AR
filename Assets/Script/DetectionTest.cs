using UnityEngine;
using System.Linq;
using UI = UnityEngine.UI;
using Klak.TestTools;

public class DetectionTest : MonoBehaviour
{
    [SerializeField] ImageSource _source = null;
    [SerializeField] int _decimation = 4;
    [SerializeField] float _tagSize = 0.05f;
    [SerializeField] Material _tagMaterial = null;
    [SerializeField] UI.RawImage _webcamPreview = null;
    [SerializeField] UI.Text _debugText = null, AprilTagPos;
    [SerializeField] public Vector3 PositionofTag;
    [SerializeField] public Quaternion RotationofTag;

    AprilTag.TagDetector _detector;
    TagDrawer _drawer;

    void Start()
    {
        var dims = _source.OutputResolution;

        _detector = new AprilTag.TagDetector(dims.x, dims.y, _decimation);
        _drawer = new TagDrawer(_tagMaterial);
    }

    void OnDestroy()
    {
        _detector.Dispose();
        _drawer.Dispose();
    }

    void LateUpdate()
    {
        _webcamPreview.texture = _source.Texture;

        // Source image acquisition
        var image = _source.Texture.AsSpan();
        if (image.IsEmpty) return;

        // AprilTag detection
        var fov = Camera.main.fieldOfView * Mathf.Deg2Rad;
        _detector.ProcessImage(image, fov, _tagSize);

        foreach (var tag in _detector.DetectedTags)
        {
            _drawer.Draw(tag.ID, tag.Position, tag.Rotation, _tagSize);

            PositionofTag = tag.Position;
            RotationofTag = tag.Rotation;
            GetPos(tag.Position, tag.Rotation);

            AprilTagPos.text = "Tagpos: " + PositionofTag + "\n" + "Tag Rotate: " + RotationofTag;
        }
        
        // Profile data output (with 30 frame interval)
        if (Time.frameCount % 30 == 0)
            _debugText.text = _detector.ProfileData.Aggregate
            ("Profile (usec)", (c, n) => $"{c}\n{n.name} : {n.time}");
    }
    public void GetPos(Vector3 Pos, Quaternion Rotate)
    {
            PositionofTag = Pos;
            RotationofTag = Rotate;
    }
}
