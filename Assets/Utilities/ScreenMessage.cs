using UnityEngine;
using UnityEngine.UI;

public class ScreenMessage : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text Message;
    [SerializeField]
    private Animator MessageAnimation;
    [SerializeField]
    private Color[] Colors;
#pragma warning restore 0649
    private Image messageBackgroundColor;
    private float duration = 0.0f, timer;
    private bool isActivated, messageShown = false;
    public static ScreenMessage Instance;
    public void Awake() => Instance = this;
    // Start is called before the first frame update
    void Start() => messageBackgroundColor = GetComponent<Image>();
    // Update is called once per frame
    void Update() => CheckMessageState();
    private void CheckMessageState()
    {
        if (isActivated)
        {
            if (!messageShown)
            {
                ActivateMessage(true);
                messageShown = true;
            }
            timer += Time.deltaTime;
            if(timer >= duration)
            {
                timer = 0.0f;
                messageShown = isActivated = false;
                ActivateMessage(false);                
            }
        }
    }
    public void ShowMessage(MessageColor color = MessageColor.None, string message = null, float duration = -1.0f)
    {
        messageBackgroundColor.color = Colors[(int)color];
        Message.text = message == null ? "" : message;
        this.duration = duration == -1.0f ? 1f : duration;
        timer = 0.0f;
        isActivated = true;
    }
    private void ActivateMessage(bool onOff) => MessageAnimation.SetBool("isMessageActivated", onOff);
}
