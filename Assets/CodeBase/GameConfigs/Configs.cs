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
    }
}
