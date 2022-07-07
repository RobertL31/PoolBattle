using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Target;
    private Camera Camera;

    [SerializeField]
    private float _size = 5;

    public float Size
    {
        get => _size;
        set
        {
            _size = value;
            Camera.orthographicSize = _size;
        }
    }

    public float MinSize = 3;
    public float MaxSize = 8;

    public float ZoomSpeed = 0.5f;

    void Start()
    {
        Camera = transform.GetComponent<Camera>();
        MatchTransformWithTarget();
        // updates camera size at initialization
        Size = _size;

    }

    // Update is called once per frame
    void Update()
    {
        MatchTransformWithTarget();

        // Backward increases, so negative
        float scrollValue = -Input.mouseScrollDelta.y;
        float targetSize = _size + scrollValue * ZoomSpeed;
        targetSize = Mathf.Clamp(targetSize, MinSize, MaxSize);
        Size = targetSize;
    }

    void MatchTransformWithTarget()
    {
        Vector3 position = transform.position;
        position = Target.transform.position;
        position.z = -10;
        transform.position = position;
    }
}
