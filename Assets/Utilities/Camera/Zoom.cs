using UnityEngine;

public class Zoom : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float perspectiveZoomSpeed = 0.2f; // The rate of change of the field of view in perspective mode.
    [SerializeField] private float orthoZoomSpeed = 0.2f; // The rate of change of the orthographic size in orthographic mode.
    [SerializeField] private float orthographicSizeMin = 0.2f;
    [SerializeField] private float fovMin = 30.0f;
    [SerializeField] private float fovMax = 100.0f;
#pragma warning restore 0649


    private Camera camera;
    // Use this for initialization
    void Start() => camera = Camera.main;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        { // If two touches are detected.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrevPosition = touchZero.position - touchZero.deltaPosition; // Find the position in the previous frame of touch(0).
            Vector2 touchOnePrevPosition = touchOne.position - touchOne.deltaPosition;// Find the position in the previous frame of touch(1).
            float prevTouchDeltaMagnitude = (touchZeroPrevPosition - touchOnePrevPosition).magnitude;
            float touchDeltaMagnitude = (touchZero.position - touchOne.position).magnitude;
            float deltaMagnitudeDifference = prevTouchDeltaMagnitude - touchDeltaMagnitude; // Find the difference in the distances between the frames.
            if (camera.orthographic)
            { // If the camera view is orthographic.
                camera.orthographicSize += deltaMagnitudeDifference * orthoZoomSpeed;
                camera.orthographicSize = Mathf.Max(camera.orthographicSize, orthographicSizeMin); // Make sure the ortohgraphic size does not goes below 0.2.
            }
            else
            { // Else the camera view is perspective.
                camera.fieldOfView += deltaMagnitudeDifference * perspectiveZoomSpeed;
                camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, fovMin, fovMax); // Set the camera's field of view between 30 and 100.
            }
        }
    }
}
