using Interactables;
using UnityEngine;

namespace Assets.CodeBase.GamePlay.Loot
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] protected AudioClip _clip;
        [SerializeField] private SelectedObject _selectedObject;

        protected void EnableInteract() =>
            _selectedObject.Show();

        protected void DisableInteract() =>
            _selectedObject.Hide();

        protected abstract void UseObject();

        private void OnMouseDown()
        {
            if (_selectedObject.isActiveAndEnabled)
                UseObject();
        }
    }
}
