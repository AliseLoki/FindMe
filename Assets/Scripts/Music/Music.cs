using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    [SerializeField] private MusicSO _musicSO;

    private bool _isForestMusicPlaying;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayGrannysHomeMusic();
    }

    private void OnEnable()
    {
        Player.Instance.EnteredSafeZone += PlaySafeZoneMusic;
        Player.Instance.EnteredTheForest += PlayForestMusic;
        Player.Instance.ExitSafeZone += PlayRoadMusic;
    }

    private void OnDisable()
    {
        Player.Instance.EnteredSafeZone -= PlaySafeZoneMusic;
        Player.Instance.EnteredTheForest -= PlayForestMusic;
        Player.Instance.ExitSafeZone -= PlayRoadMusic;
    }

    private void PlayForestMusic()
    {
        if (!_isForestMusicPlaying)
        {
            PlayMusic(_musicSO.ForestMusic);
            _isForestMusicPlaying = true;
        }
    }

    private void PlaySafeZoneMusic()
    {
        PlayMusic(_musicSO.SafeZoneMusic);
    }

    private void PlayRoadMusic()
    {
        PlayMusic(_musicSO.RoadMusic);
    }

    private void PlayGrannysHomeMusic()
    {
        PlayMusic(_musicSO.GrannysHomeMusic);
    }

    private void PlayMusic(AudioClip audioClip)
    {
        _audioSource.Stop();
        _audioSource.clip = audioClip;
        _audioSource.Play();
        _isForestMusicPlaying = false;
    }
}
