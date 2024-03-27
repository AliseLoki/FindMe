using UnityEngine;

public class Container : InteractableObject
{
    [SerializeField] private FoodSO _foodSO;
    [SerializeField] private Food _food;

    [SerializeField] private SoundEffects _soundEffects;

    protected override void UseObject()
    {
        if (!Player.Instance.HasSomethingInHands)
        {
            TipsViewPanel.Instance.ShowFoodPickedTip();

            _food = Instantiate(_foodSO.Prefab, Player.Instance.HandlePoint);
            Player.Instance.SetHasSomethingInHands(true);
            Player.Instance.SetFood(_food, _foodSO);

            _soundEffects.PlayGettingFoodSoundEffect(transform);
        }
        else
        {
            TipsViewPanel.Instance.ShowHandsAreFullTip();
        }
    }
}
