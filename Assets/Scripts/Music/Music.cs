using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    private const string PlayerPrefsMusicVolume = nameof(PlayerPrefsMusicVolume);

    [SerializeField] private MusicSO _musicSO;
    [SerializeField] private Slider _musicVolumeSlider;

    private float _defaultMusicVolumeValue = 0.3f;
    private bool _isForestMusicPlaying;
    private AudioSource _audioSource;
    private Player _player;

    private void Awake()
    {
        _player = GameManager.Instance.GameEntryPoint.InitPlayer();
        _audioSource = GetComponent<AudioSource>();
        _musicVolumeSlider.value = PlayerPrefs.GetFloat(PlayerPrefsMusicVolume, _defaultMusicVolumeValue);
        ChangeVolume();
        PlayForestMusic();
    }

    private void OnEnable()
    {
        _player.PlayerEventsHandler.EnteredGrannysHome += PlayGrannysHomeMusic;
        _player.PlayerEventsHandler.ExitGrannysHome += PlayRoadMusic;

        _player.PlayerEventsHandler.EnteredTheForest += PlayForestMusic;

        _player.PlayerEventsHandler.EnteredSafeZone += PlaySafeZoneMusic;
        _player.PlayerEventsHandler.ExitSafeZone += PlayRoadMusic;

        _player.PlayerEventsHandler.EnteredVillage += PlayVilageMusic;
        _player.PlayerEventsHandler.ExitVillage += PlayRoadMusic;
    }

    private void OnDisable()
    {
        _player.PlayerEventsHandler.EnteredGrannysHome -= PlayGrannysHomeMusic;
        _player.PlayerEventsHandler.ExitGrannysHome -= PlayRoadMusic;

        _player.PlayerEventsHandler.EnteredTheForest -= PlayForestMusic;

        _player.PlayerEventsHandler.EnteredSafeZone -= PlaySafeZoneMusic;
        _player.PlayerEventsHandler.ExitSafeZone -= PlayRoadMusic;

        _player.PlayerEventsHandler.EnteredVillage -= PlayVilageMusic;
        _player.PlayerEventsHandler.ExitVillage -= PlayRoadMusic;
    }

    public void ChangeMusicVolume()
    {
        ChangeVolume();
        PlayerPrefs.SetFloat(PlayerPrefsMusicVolume, _musicVolumeSlider.value);
        PlayerPrefs.Save();
    }

    private void ChangeVolume()
    {
        _audioSource.volume = _musicVolumeSlider.value;
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

    private void PlayVilageMusic()
    {
        PlayMusic(_musicSO.VillageMusic);
    }

    private void PlayMusic(AudioClip audioClip)
    {
        _audioSource.Stop();
        _audioSource.clip = audioClip;
        _audioSource.Play();
        _isForestMusicPlaying = false;
    }
}
