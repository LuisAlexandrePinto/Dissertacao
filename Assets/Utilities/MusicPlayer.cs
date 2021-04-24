using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource MusicTrackI, MusicTrackII, MusicTrackIII;
    private void Awake() => PlayTracks();
    private void PlayTracks()
    {
        switch (MathConts.RandomInt(1, 4))
        {
            case 1: MusicTrackI.Play(); break;
            case 2: MusicTrackII.Play(); break;
            case 3: MusicTrackIII.Play(); break;
        }
    }
}
