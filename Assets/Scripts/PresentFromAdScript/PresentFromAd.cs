using System.Collections.Generic;
using UnityEngine;

public class PresentFromAd : InteractableObject
{
    [SerializeField] private ParticleSystem _confettiEffect;

    [SerializeField] private List<GameObject> _packing;
    [SerializeField] private List<GameObject> _presentsList = new();

    protected override void UseObject()
    {
        DestroyOpenedPresent();
        PlayEffects();
        ChooseRandomPresent();
    }

    private void ChooseRandomPresent()
    {
        int index = Random.Range(0, _presentsList.Count);
        Instantiate(_presentsList[index], transform.position, Quaternion.identity);
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
