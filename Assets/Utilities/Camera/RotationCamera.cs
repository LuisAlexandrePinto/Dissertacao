using UnityEngine;

public class RotationCamera : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private Transform character;
#pragma warning restore 0649

    private float angle = 0.0f;
    // Use this for initialization
    void Start() { }
    // Update is called once per frame
    void Update()
    {
        // Check count touches.
        if (Input.touchCount == 1)
        {
            // Move finger across screen.
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Touch touchZero = Input.GetTouch(0);
                // Find the position in the previous frame of touch(0).
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                // Find the difference in the distances between the frames.
                float deltaMagnitudeDiff = (touchZeroPrevPos - touchZero.position).magnitude;
                // Set the polarity of the delta position 
                Vector2 deltaPos = new Vector2();
                if (touchZero.position.x > Screen.width / 2)
                {
                    if (touchZero.deltaPosition.y < 0f)
                    {
                        deltaPos.y = touchZero.deltaPosition.y;
                    }
                    else if (touchZero.deltaPosition.y > 0f)
                    {
                        deltaPos.y = touchZero.deltaPosition.y;
                    }
                }
                else if (touchZero.position.x < Screen.width / 2)
                {
                    if (touchZero.deltaPosition.y < 0f)
                    {
                        deltaPos.y = -touchZero.deltaPosition.y;
                    }
                    else if (touchZero.deltaPosition.y > 0f)
                    {
                        deltaPos.y = -touchZero.deltaPosition.y;
                    }
                }

                if (touchZero.position.y > Screen.height / 2)
                {
                    if (touchZero.deltaPosition.x < 0f)
                    {
                        deltaPos.x = -touchZero.deltaPosition.x;
                    }
                    else if (touchZero.deltaPosition.x > 0f)
                    {
                        deltaPos.x = -touchZero.deltaPosition.x;
                    }
                }
                else if (touchZero.position.y < Screen.height / 2)
                {
                    if (touchZero.deltaPosition.x < 0f)
                    {
                        deltaPos.x = touchZero.deltaPosition.x;
                    }
                    else if (touchZero.deltaPosition.x > 0f)
                    {
                        deltaPos.x = touchZero.deltaPosition.x;
                    }
                }
                angle = ((deltaPos.x / Screen.width) + (deltaPos.y / Screen.height)) * 270.0f;
                // Rotate the camera around the character.
                transform.RotateAround(character.position, Vector3.up, angle);
            }
        }
    }
}
