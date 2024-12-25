using UnityEngine;

namespace SO
{
    [CreateAssetMenu()]
    public class TipsSO : ScriptableObject
    {
        public string YouAreSafeTip = "у домика бабушки ты в безопасности, волк тебя не съест";
        public string YouAreNotSafeTip = "не сходи с дороги, хотя дрова для печки есть только в лесу...";

        public string ApproachObjectForInteractionTip = "если хочешь использовать предмет, надо к нему подойти";
        public string TapTheObjectTip = "предмет выбран, нажми на него";
        public string HandsAreFullTip = "руки заняты";
        public string ThisIsGarbageTip = "это мусорка";
        public string ThrowFoodTip = "ты уверен что стоило это выкидывать?";
        public string NothingInHandsTip = "у вас в руках ничего нет";

        public string ThisIsCuttingTableTip = "здесь можно порезать продукты";
        public string CutItTip = "тэпни еще раз чтобы порезать";
        public string CantCutItTip = "это невозможно порезать";

        public string ThisIsContainerTip = "здесь лежат ингредиенты для блюд";
        public string FoodPickedTip = "отнеси еду на стол для готовки, но помни, некоторые продукты нужно сначала порезать";

        public string BringToCookingTableTip = "молодец, теперь отнеси это на стол для готовки";
        public string BringToOvenTip = "теперь неси в печь";

        public string ThisIsOvenTip = "это печь, в ней можно готовить";
        public string NoWoodsTip = "в печке нет дров";
        public string CantLightFireTip = "невозможно разжечь огонь, руки заняты";
        public string CanUseOvenTip = "теперь можно готовить в печи";
        public string ReadynessInstruction = "если кастрюля покраснела - блюдо готово, если пошел дым - блюдо сгорело";
        public string TimeToPack = "можно уже и упаковать";

        public string ThisIsCookingTableTip = "это стол для готовки, здесь можно смешать ингредиенты";
        public string FirstCutItTip = "это нужно сначала порезать";
        public string ShowRecipesTip = "нажми на рецепты в левом углу экрана";
        public string CanCookTip = " если галочка возле рецепта зеленая, нажми на нее";

        public string ThisIsPackingPlaceTip = "это место для упаковки готовых блюд";
        public string DishIsPackedTip = "упаковали блюдо";
        public string NoPlaceTip = "в рюкзаке уже нет места, пора отправляться в дорогу";

        public string ThisIsRecievingOrdersPointTip = "здесь можно получить заказ";
        public string FirstCompleteOldOrdersTip = "сначала доставь прошлый заказ";

        public string ThisIsHouseTip = "это дом, нажми на дверь, чтобы доставить заказ";
        public string IDidntOrderThisTip = "я это блюдо не заказывал";
        public string DishIsPreparedBadly = "блюдо плохо приготовлено, ты не получишь деньги";

        public string PutGoldInMe = "кинь в меня 10 золотых и получишь воду";
        public string NotEnoughMoney = "недостаточно денег";
        public string WaterPatch = "полей грядки";

        public string HereYouCanGrowVegetables = "здесь можно выращивать овощи, левая грядка для помидор, правая для капусты";
        public string BringWaterHere = "полей грядку";
        public string NowYouHaveNewVegetable = "теперь в домике появился новый овощ, возьми заказ на новые рецепты";

        public string YouCanBringACowHere = "Это место для коровы";
        public string BringMeAWater = "напои меня водой";
        public string NowYouHaveCheese = "теперь в домике появился сыр, ты можешь взять заказ на новые рецепты";

        public string PutWoodInOvenTip = "эти дрова можно положить в печь";

        public string TakeBackpackTip = "возможно стоило взять с собой посылки";

        public string EatMeTip = "съешь меня";
        public string TakeMeTip = "возьми меня и отнеси на грядку";
        public string KillTheWolfTip = "возьми меня и убей волка";
        public string KillTheWitchTip = "возьми меня, я тебе пригожусь";

        public string TakeRewardTip = "возьми награду в центре деревни ";

        public string UseNecronomiconTip = "скорее доставай некрономикон";
        public string YouCanCookOnlyInGrannysHomeTip = "готовить ты можешь только в доме бабушки";
        public string BringMeToPatchTip = "а теперь посади меня в грядку и  полей";
        public string YouCanKillWolfNowTip = "теперь ты можешь убить волка";
        public string YouHaveMeatNowTip = "теперь у тебя в домике есть мясо...";
        public string ItIsNotRightTimeTip = "еще не время...";
    }
}
