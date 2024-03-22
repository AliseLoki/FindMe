using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] private Transform _nonActiveArea;
    [SerializeField] private Transform _needToBeActiveArea;
    [SerializeField] private Transform _newPosition;

    protected override void UseObject()
    {
        _nonActiveArea.gameObject.SetActive(false);
        _needToBeActiveArea.gameObject.SetActive(true);
        Player.Instance.transform.position = _newPosition.position;
    }
}
