using UnityEngine;

namespace Assets.CodeBase.GameConfigs
{
    [CreateAssetMenu(fileName = "My SO", menuName = "ConfigsSO")]
    public class Configs : ScriptableObject
    {
        [Header("Player")]
        [SerializeField] private float _speed;
        [SerializeField] private float _rotSpeed;
        [SerializeField] private float _minStep;

        public float Speed => _speed;
        public float RotSpeed => _rotSpeed;
        public float MinStep => _minStep;

        [Header("AudioClips")]
        [SerializeField] private AudioClip _forestClip;
        [SerializeField] private AudioClip _safeClip;
        [SerializeField] private AudioClip _roadClip;
        [SerializeField] private AudioClip _pentagramClip;
        [SerializeField] private AudioClip _grannyClip;

        public AudioClip ForestClip => _forestClip;
        public AudioClip SafeClip => _safeClip;
        public AudioClip RoadClip => _roadClip;
        public AudioClip PentagramClip => _pentagramClip;
        public AudioClip GrannyClip => _grannyClip;
    }
}
