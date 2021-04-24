using UnityEngine;

public class PlayerPrefabManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
#pragma warning restore 0649
    // Start is called before the first frame update
    void Start() => Instantiate(player1, this.transform.position, this.transform.rotation);
}
