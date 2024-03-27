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
    }

    private void OnEnable()
    {
        Player.Instance.PlayerEventsHandler.EnteredGrannysHome += PlayGrannysHomeMusic;
        Player.Instance.PlayerEventsHandler.ExitGrannysHome += PlayRoadMusic;

        Player.Instance.PlayerEventsHandler.EnteredTheForest += PlayForestMusic;

        Player.Instance.PlayerEventsHandler.EnteredSafeZone += PlaySafeZoneMusic;
        Player.Instance.PlayerEventsHandler.ExitSafeZone += PlayRoadMusic;

        Player.Instance.PlayerEventsHandler.EnteredVillage += PlayVilageMusic;
        Player.Instance.PlayerEventsHandler.ExitVillage += PlayRoadMusic;
    }

    private void OnDisable()
    {
        Player.Instance.PlayerEventsHandler.EnteredGrannysHome -= PlayGrannysHomeMusic;
        Player.Instance.PlayerEventsHandler.ExitGrannysHome -= PlayRoadMusic;

        Player.Instance.PlayerEventsHandler.EnteredTheForest -= PlayForestMusic;

        Player.Instance.PlayerEventsHandler.EnteredSafeZone -= PlaySafeZoneMusic;
        Player.Instance.PlayerEventsHandler.ExitSafeZone -= PlayRoadMusic;

        Player.Instance.PlayerEventsHandler.EnteredVillage -= PlayVilageMusic;
        Player.Instance.PlayerEventsHandler.ExitVillage -= PlayRoadMusic;
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
