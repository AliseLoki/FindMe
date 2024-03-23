using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private AudioClip _forestMusic;
    [SerializeField] private AudioClip _safeZoneMusic;
    [SerializeField] private AudioClip _roadMusic;

    private bool _isForestMusicPlaying;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayRoadMusic();
    }

    private void OnEnable()
    {
        _player.EnteredSafeZone += PlaySafeZoneMusic;
        _player.EnteredTheForest += PlayForestMusic;
        _player.ExitSafeZone += PlayRoadMusic;
    }

    private void OnDisable()
    {
        _player.EnteredSafeZone -= PlaySafeZoneMusic;
        _player.EnteredTheForest -= PlayForestMusic;
        _player.ExitSafeZone -= PlayRoadMusic;
    }

    private void PlayForestMusic()
    {
        if (!_isForestMusicPlaying)
        {
            PlayMusic(_forestMusic);
            _isForestMusicPlaying = true;
        }
    }

    private void PlaySafeZoneMusic()
    {
        PlayMusic(_safeZoneMusic);
    }

    private void PlayRoadMusic()
    {
        PlayMusic(_roadMusic);
    }

    private void PlayMusic(AudioClip audioClip)
    {
        _audioSource.Stop();
        _audioSource.clip = audioClip;
        _audioSource.Play();
        _isForestMusicPlaying = false;
    }
}
