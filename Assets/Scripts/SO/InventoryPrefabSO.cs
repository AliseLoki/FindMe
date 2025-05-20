using Interactables.InventoryPrefabs;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu]
    public class InventoryPrefabSO : ScriptableObject
    {
        public Sprite Sprite;
        public InventoryPrefab InventoryPrefab;
    }
}