using UnityEngine;

public class TargetFollowCamera : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject character;
    [SerializeField] private float speed = 1;
#pragma warning restore 0649

    // Use this for initialization
    void Start() { }
    // Update is called once per frame
    void Update() { }
    void LateUpdate() => transform.position = Vector3.Lerp(transform.position, character.transform.position, Time.deltaTime * speed);
}
