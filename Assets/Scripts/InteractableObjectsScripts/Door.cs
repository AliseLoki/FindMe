using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] private SceneSwitcher _sceneSwitcher;

    protected override void UseObject()
    {
        _sceneSwitcher.ChangeScene();
    }
}
