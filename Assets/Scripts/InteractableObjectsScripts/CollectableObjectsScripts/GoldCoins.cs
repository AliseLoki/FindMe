using UnityEngine;

namespace Interactables
{
    public class GoldCoins : MonoBehaviour
    {
        public int CoinsValue { get; private set; } = 1;

        public void PickUpCoins()
        {
            Destroy(gameObject);
        }
    }
}
