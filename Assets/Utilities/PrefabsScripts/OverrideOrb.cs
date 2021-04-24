using UnityEngine;
using UnityEngine.Assertions;

public class OverrideOrb : MonoBehaviour
{
#pragma warning disable 0649
    /**
     * throwSpeed é a velocidade a que a bola move-se.
     * collisionStallTime é o tempo que existe antes de se destruir automaticamente a orb, após esta collidir com o que quer que seja.
     * stallTime é a quantidade de tempo que queremos que a orb sobreviva caso nao tenha colisão, ou seja, se for atirada só para o ar.
     */
    [SerializeField]
    private float throwSpeed = 30.0f, collisionStallTime = 0.5f, stallTime = 5.0f;

    //Efeitos sonoros para melhorar a experiência de jogo.
    [SerializeField]
    private AudioClip dropSound, successSound, throwSound;
#pragma warning restore 0649

    /**
     * lastX é a a ultima posição X do jogador
     * lastY é a ultima posição Y do jogador
     */
    private float lastX, lastY;
    /**
     * released confirma se o utilizador lançou a orb.
     * holding confirma se o utilizador mantém a orb consigo, tanto parada como a arrastar esta pelo ecrâ.
     * trackingCollision evita o ressalto da orb, ou seja, se esta for parar ao chão mas em seguida bater no droid não conta.
     */
    private bool released, holding, trackingCollisions = false;

    private new Rigidbody rigidbody;
    private AudioSource audioSource;
    private InputStatus inputStatus;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(audioSource);
        Assert.IsNotNull(rigidbody);
        Assert.IsNotNull(dropSound);
        Assert.IsNotNull(successSound);
        Assert.IsNotNull(throwSound);
    }

    private void Update()
    {
        if (released)
        {
            return;
        }
        if (holding)
        {
            FollowInput();
        }
        UpdateInputStatus();

        switch (inputStatus)
        {
            case InputStatus.Grabbing: Grab(); break;
            case InputStatus.Holding: Drag(); break;
            case InputStatus.Releasing: Release(); break;
            case InputStatus.None: return;
            default: return;
        }
    }

    private void Release()
    {
        if (lastY < GetInputPosition().y)
        {
            Throw(GetInputPosition());
        }
    }

    private void Throw(Vector2 targetPos)
    {
        rigidbody.useGravity = true;
        trackingCollisions = true;
        float yDiff = (targetPos.y - lastY) / Screen.height * 100;
        float speed = throwSpeed * yDiff;
        float x = (targetPos.x / Screen.width) - (lastX / Screen.width);
        x = Mathf.Abs(GetInputPosition().x - lastX) / Screen.width * 100 * x;
        Vector3 direction = new Vector3(x, 0.0f, 1.0f);
        direction = Camera.main.transform.TransformDirection(direction);
        rigidbody.AddForce((direction * speed / 2.0f) + Vector3.up * speed);
        audioSource.PlayOneShot(throwSound);
        released = true;
        holding = false;
        Invoke("PowerDown", stallTime);
    }

    private void Drag()
    {
        lastX = GetInputPosition().x;
        lastY = GetInputPosition().y;
    }

    private void Grab()
    {
        Ray ray = Camera.main.ScreenPointToRay(GetInputPosition());
        RaycastHit point;
        if (Physics.Raycast(ray, out point, 100.0f) && point.transform == transform)
        {
            holding = true;
            transform.parent = null;
        }
    }

    private void UpdateInputStatus()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            inputStatus = InputStatus.Grabbing;
        }
        else if (Input.GetMouseButton(0))
        {
            inputStatus = InputStatus.Holding;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            inputStatus = InputStatus.Releasing;
        }
        else
        {
            inputStatus = InputStatus.None;
        }
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
//#if NOT_UNITY_EDITOR
        if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            inputStatus = InputStatus.Grabbing;
        } else if(Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            inputStatus = InputStatus.Releasing;
        } else if(Input.touchCount == 1)
        {
            inputStatus = InputStatus.Holding;
        }
        else
        {
            inputStatus = InputStatus.None;
        }
#endif
    }

    private void FollowInput()
    {
        Vector3 inputPos = GetInputPosition();
        inputPos.z = Camera.main.nearClipPlane * 7.5f;
        Vector3 pos = Camera.main.ScreenToWorldPoint(inputPos);
        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, 50.0f * Time.deltaTime);
    }

    private Vector2 GetInputPosition()
    {
        Vector2 result = new Vector2();
#if UNITY_EDITOR
        result = Input.mousePosition;
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
//#if NOT_UNITY_EDITOR
        result = Input.GetTouch(0).position;
#endif
        return result;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!trackingCollisions)
        {
            return;
        }
        trackingCollisions = false;
        if (other.gameObject.CompareTag(SquadUpConstants.TAG_DROID))
        {
            audioSource.PlayOneShot(successSound);
            print("'twas a droid");
        }
        else
        {
            audioSource.PlayOneShot(dropSound);
            //Invoke("PowerDown", 0.0f);
            print("'twasn't a droid");
        }
        Invoke("PowerDown", 0.0f);
    }

    private void PowerDown()
    {
        CaptureSceneManager manager = FindObjectOfType<CaptureSceneManager>();
        if (manager != null)
        {
            manager.OrbDestroyed();
        }
        Destroy(gameObject);
    }
}

