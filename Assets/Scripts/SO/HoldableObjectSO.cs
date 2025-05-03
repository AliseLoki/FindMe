using Indexies;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu()]
    public class HoldableObjectSO : ScriptableObject
    {
        public GameObject Prefab;
        public HoldableObjectType Type;
    }
}