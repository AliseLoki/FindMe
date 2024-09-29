using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    [SerializeField] private MusicSO _musicSO;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Player _player;
    [SerializeField] private Saver _saver;

    private bool _isForestMusicPlaying;
    private AudioSource _audioSource;
   
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _musicVolumeSlider.value = _saver.LoadMusicVolume();
        ChangeVolume();
        PlayStartMusic();
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

        _player.PlayerEventsHandler.EnteredPentagramZone += PlayPentagramMusic;
        _player.PlayerEventsHandler.ExitPentagramZone += PlayRoadMusic;

        _player.PlayerEventsHandler.PlayerHasDied += PlayGameOverMusic;
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

        _player.PlayerEventsHandler.EnteredPentagramZone -= PlayPentagramMusic;
        _player.PlayerEventsHandler.ExitPentagramZone -= PlayRoadMusic;

        _player.PlayerEventsHandler.PlayerHasDied -= PlayGameOverMusic;

    }

    public void ChangeMusicVolume()
    {
        ChangeVolume();
        _saver.SaveMusicVolume(_musicVolumeSlider.value);
    }

    public void PlayWitchAppearMusic()
    {
        PlayMusic(_musicSO.WitchAppearMusic);
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

    private void PlayStartMusic()
    {
        PlayMusic(_musicSO.StartMusic);
    }

    private void PlayGameOverMusic()
    {
        PlayMusic(_musicSO.GameOverMusic);
    }

    private void PlayPentagramMusic()
    {
        PlayMusic(_musicSO.PentagramMusic);
    }

    private void PlayMusic(AudioClip audioClip)
    {
        _audioSource.Stop();
        _audioSource.clip = audioClip;
        _audioSource.Play();
        _isForestMusicPlaying = false;
    }
}
