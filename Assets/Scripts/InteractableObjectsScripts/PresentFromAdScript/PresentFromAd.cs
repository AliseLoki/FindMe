using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class PresentFromAd : InteractableObject
    {
        [SerializeField] private ParticleSystem _confettiEffect;
        [SerializeField] private List<GameObject> _packing;
        [SerializeField] private List<InteractableObject> _presentsList = new();

        protected override void UseObject()
        {
            DestroyOpenedPresent();
            PlayEffects();
            ChooseRandomPresent();
        }

        private void ChooseRandomPresent()
        {
            int index = Random.Range(0, _presentsList.Count);
            var randomPresent = Instantiate(_presentsList[index], transform.position, Quaternion.identity);
            randomPresent.InitLinks(TipsViewPanel, Player, PlayerInventory);
        }

        private void PlayEffects()
        {
            _confettiEffect.Play();
            AudioSource.Play();
        }

        private void DestroyOpenedPresent()
        {
            this.GetComponent<BoxCollider>().enabled = false;

            foreach (var item in _packing)
            {
                item.gameObject.SetActive(false);
            }

            Destroy(gameObject, 2f);
        }
    }
}
