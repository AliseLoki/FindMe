using UnityEngine;

[CreateAssetMenu()]
public class TipsSO : ScriptableObject
{
    public string ApproachObjectForInteractionTip = "Если хочешь использовать предмет, надо к нему подойти";
    public string TapTheObjectTip = "Предмет выбран, тэпни на него";
    public string HandsAreFullTip = "Руки заняты";
    public string FoodPickedTip = "Теперь отнеси еду на стол для готовки. Но помни, некоторые продукты нужно сначала порезать ";

    public string ThisIsGarbageTip = "Это мусорка";
    public string ThrowFoodTip = "Ты уверен что стоило это выкидывать?";
    public string NothingToThrowTip = "Нечего выбрасывать";

    public string ThisIsCuttingTableTip = "Здесь можно порезать продукты";
    public string CutItTip = "Тэпни еще раз чтобы порезать";
    public string CantCutItTip = "Это невозможно порезать";

    public string BringToCookingTableTip = "Молодец, теперь отнеси это на стол для готовки";
    public string BringToOvenTip = "Теперь неси в печь";

    public string ThisIsOvenTip = "Это печь, в ней можно готовить";
    public string NoWoodsTip = "В печке нет дров";
    public string CantLightFireTip = "Невозможно разжечь огонь, руки заняты";
    public string CanUseOvenTip = "Теперь можно готовить в печи";
    public string ReadynessInstruction = "Если кастрюля покраснела - блюдо готово, если пошел дым - блюдо сгорело";
    public string TimeToPack = "Можно уже и упаковать";

    public string ThisIsCookingTableTip = "Это стол для готовки. Здесь можно смешать ингредиенты";
    public string ShowRecipesTip = "Нажми на рецепты в левом углу экрана";
    public string CanCookTip = " Теперь нажми на галочку возле рецепта";

    public string ThisIsPackingPlace = "Это место для упаковки готовых блюд";
    public string NoPlaceTip = "В рюкзаке уже нет места. Пора отправляться в дорогу";

    public string PutWoodInOvenTip = "Эти дрова можно положить в печь";

    public string TakeBackpackTip = "Возможно стоило взять с собой посылки";

}
