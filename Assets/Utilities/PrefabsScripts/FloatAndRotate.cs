using UnityEngine;

public class FloatAndRotate : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 50, floatAmplitude = 2.0f, floatFrequency = 0.5f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 6, transform.position.z);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFrequency * floatAmplitude);
        transform.position = tempPos;
    }
}
