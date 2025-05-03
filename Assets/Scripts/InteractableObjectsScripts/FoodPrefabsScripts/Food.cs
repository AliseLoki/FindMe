using SO;
using UnityEngine;

namespace Interactables
{
    public class Food : MonoBehaviour
    {
        [SerializeField] private FoodSO _foodSO;

        public FoodSO ConnectedFoodSO => _foodSO;

        public void SetInParent(Transform parent)
        {
            this.transform.parent = parent;
            this.transform.position = parent.transform.position;
        }
    }
}