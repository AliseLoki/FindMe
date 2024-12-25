using UnityEngine;
using Interactables.InventoryPrefabs;

namespace SO
{
    [CreateAssetMenu()]
    public class InventoryPrefabSO : ScriptableObject
    {
        public Sprite Sprite;
        public InventoryPrefab InventoryPrefab;
    }
}
