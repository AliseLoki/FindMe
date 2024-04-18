using UnityEngine;

public class Container : InteractableObject
{
    [SerializeField] private FoodSO _foodSO;
    [SerializeField] private Food _food;
    [SerializeField] private SoundEffects _soundEffects;

    protected override void UseObject()
    {
        if (!Player1.HasSomethingInHands)
        {
            TipsViewPanel.Instance.ShowFoodPickedTip();

            _food = Instantiate(_foodSO.Prefab, Player1.HandlePoint);
            Player1.SetHasSomethingInHands(true);
            Player1.SetFood(_food, _foodSO);

            _soundEffects.PlayGettingFoodSoundEffect(transform);
        }
        else
        {
            TipsViewPanel.Instance.ShowHandsAreFullTip();
        }
    }
}
