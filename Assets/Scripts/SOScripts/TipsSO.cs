using UnityEngine;

[CreateAssetMenu()]
public class TipsSO : ScriptableObject
{
    public string ApproachObjectForInteractionTip = "Если хочешь использовать предмет, надо к нему подойти";
    public string TapTheObjectTip = "Предмет выбран, тэпни на него";
    public string HandsAreFullTip = "Невозможно взять, в руках уже есть предмет";
    public string FoodPickedTip = "Теперь отнеси еду на стол для готовки. Но помни, некоторые продукты нужно сначала порезать ";
    public string ThrowFoodTip = "Ты уверен что стоило это выкидывать?";
    public string NothingToThrowTip = "Нечего выбрасывать";
    public string CantCutTip = "Это невозможно порезать";
    public string CutItTip = "Тэпни еще раз чтобы порезать";
    public string BringToCookingTableTip = "Молодец, теперь отнеси это на стол для готовки";
}
