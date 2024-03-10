using UnityEngine.SceneManagement;

public class Door : InteractableObject
{
    protected override void UseObject()
    {
        SceneManager.LoadScene(1);
    }
}
