using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AllTexts : ScriptableObject
{
    private const string _text = "text";
    private const string _text1 = "text";



    public Dictionary<string, string> EducationText = new Dictionary<string, string>
    {
        {_text,_text1 }
    };

    // education SO
    public string FirstEducationText = "хочешь ли ты пройти обучение ?";
    public string StartEducationButtonText = "начать обучение"; // yes
    public string SkipEducationButtonText = "пропустить обучение"; //no

    public List<string> Advices = new List<string>()
    {
        {" чтобы перейти к следующему совету, нажми зеленую стрелочку под текстом" },
        {"ты можешь менять вид камеры и громкость, нажми на черную шестеренку справа" },
        {"в появившемся окошке лупа отвечает за приближение камеры, динамик за громкость звуков, а ноты за громкость фоновой музыки" },
        {"просто пертащи ползунок вправо для увеличения, влево для уменьшения" },
        {"нажав на значок подарка, ты посмотришь рекламу и получишь за это либо гриб, либо дрова" },
        {"в игре много объектов, с которыми можно взаимодействовать" },
        {"они подсвечиваются серым цветом при твоем приближении" },
        {"подойди к дому птички,  у входа в дом бабушки" },
        {"нажми на него и получишь заказ" },
        {"заказ можно посмотреть, нажав на свиток в левом верхнем углу" },
        {"а теперь заходи в дом - для этого подойди к двери и нажми на нее" },
        {"сначала возьми дрова  и положи их в печь" },
        {"теперь подойди к мешку муки и возьми немного" },
        {"положи муку на стол для готовки и открой рецепты - свиток в левом верхнем углу" },
        {"если ингредиентов  хватает, то около рецепта появится зеленая галочка, нажми на нее" },
        {"на столе для готовки появилась кастрюля, хватай ее и неси в печь" },
        {"если кастрюля покраснела скорее доставай и неси к скамье с посылкой" },
        {"если пошел дым из печки, блюдо сгорело, лучше его выбросить в ящик и начать с начала" },
        {"положи кастрюлю в посылку, возьми посылку и скорее неси дровосеку" },
        {"домик дровосека рядом с домом бабушки, иди прямо по дороге до указателя" },
        {"не сходи с дороги, а то волк тебя съест" },
        {"около указателя есть сливовые деревья, в таких деревьях можно прятаться от волка а также сохраняться" },
        {"также у него растут грибы, их можно есть подойди к грибу и нажми на него" },
        {"после этого гриб появится в инвентаре, нажми на него" },
        {"желтые грибы прибавляют скорость, красные здоровье" },
        {"просто иди прямо по дорожке и увидишь дом дровосека" },
        {"чтобы доставить посылку, подойди к двери дома дровосека и нажми на нее" },
        {"если заказ приготовлен хорошо - не сырой и не сожжённый, ты получишь деньги" },
        {"на деньги можно купить воду в колодце, она нужна чтобы выращивать овощи на грядках" },
        {"овощи можно получить в деревне, после доставки всех заказов" },
        {"если запутаешься, нажми на книгу в правом верхнем углу, она подскажет тебе что делать" },
        {"теперь ты сам по себе, готовь блюда, доставляй их в деревни" },
        {"... но никогда не забывай о волке" }
    };

    //first start SO
    public string WelcomeTex = "готов ли ты начать приключение ?";
    public string RunText = "тогда беги вперед к дому бабушки, используй кнопки Ц,Ф,Ы,В для передвижения, колесико мышки для приближения камеры";
    public string YesButtonText = "да"; //yes
    public string RemainingTimeText = "осталось времени до показа рекламы";
    public string LeaderbordName = " лучшие игроки";
    public string Name = "имя";
    public string Place = "место";
    public string DeliveredDishesName = "доставлено блюд";
    public string CloseButtonText = "закрыть";
    public string AuthorizeButtonText = "авторизоваться";
    public string NeedToAuthorizeText = "для просмотра таблицы игроков нужно авторизоваться";
    public string AnonymousName = "аноним";
    public string SaveGameText = "игра сохранена";
    public string FullRestartButtonText = "начать сначала - нажмите К";

    // GameOverSO
    public string Restart = "рестарт";
    public string GameOver = "игра окончена ";
    public string VictoryText = " ты победил !!!";
    public string LooseText = "я нашла тебя ...";

    //VillagesName

    public string Woodcutter = "дровосек";
    public string FirstVillageName = "грушевка";
    public string SecondVillageName = "яблоневка";
    public string ThirdVillageName = "коровино";
    public string FourthVillageName = "зеленовка";
    public string LastVillageName = "заречье";

    // SignsSO
    public List<string> FirstSign = new List<string>()
    {
        {"мост" }, {"хижина"},{"дровосек" }, {"грушевка"},
    };

    public List<string> SecondSign = new List<string>()
    {
        {"мост" },{"дровосек"},{"хижина"},{"грушевка"}
    };

    public List<string> ThirdSign = new List<string>()
    {
        {"хижина" },{"мост"},{"дровосек"},{"грушевка"}
    };

    public List<string> FourthSign = new List<string>()
    {
        { "дровосек" }, { "грушевка" }, { "хижина" }, { "яблоневка" }
    };

    public List<string> FifthSign = new List<string>()
    {
        { "мост" }, { "яблоневка" }, { "хижина" }, { "грушевка" }
    };

    public List<string> SixthSign = new List<string>()
    {
        { "заречье" }, { "мост" }, { "зеленовка" }, { "коровино" }
    };

    public List<string> SeventhSign = new List<string>()
    {
        { "коровино" }, { "мост" }, { "зеленовка" }, { "заречье" }
    };

    public List<string> EighthSign = new List<string>()
    {
        {"мост" },{"коровино"},{"зеленовка"},{"заречье"}
    };

    public List<string> NinthSign = new List<string>()
    {
        { "коровино" }, { "зеленовка" }, { "заречье" }, { "мост" }
    };

    public List<string> TenthSign = new List<string>()
    {
        { "зеленовка" }, { "мост" }, { "грушевка" }, { "яблоневка" }
    };

    public List<string> EleventhSign = new List<string>()
    {
        { "зеленовка" }, { "мост" }, { "заречье" }, { "яблоневка" }
    };

    public List<string> TwelfthSign = new List<string>()
    {
        { "хижина" }, { "заречье" }, { "грушевка" }, { "яблоневка" }
    };


    // Tips SO

    public Dictionary<Tips, string> AllTips = new Dictionary<Tips, string>() 
    {
    
        {Tips.YouAreSafeTip,"у домика бабушки ты в безопасности, волк тебя не съест" },
        {Tips.YouAreNotSafeTip,"не сходи с дороги, хотя дрова для печки есть только в лесу..." },
        {Tips.ApproachObjectForInteractionTip,"если хочешь использовать предмет, надо к нему подойти" },
        {Tips.TapTheObjectTip,"предмет выбран, нажми на него"},
        {Tips.HandsAreFullTip,"руки заняты" },
    };


    //public string YouAreSafeTip = "у домика бабушки ты в безопасности, волк тебя не съест";
   // public string YouAreNotSafeTip = "не сходи с дороги, хотя дрова для печки есть только в лесу...";
   // public string ApproachObjectForInteractionTip = "если хочешь использовать предмет, надо к нему подойти";
  //  public string TapTheObjectTip = "предмет выбран, нажми на него";
   // public string HandsAreFullTip = "руки заняты";
    public string ThrowFoodTip = "ты уверен что стоило это выкидывать?";
    public string NothingInHandsTip = "у вас в руках ничего нет";
    public string CutItTip = "тэпни еще раз чтобы порезать";
    public string CantCutItTip = "это невозможно порезать";
    public string FoodPickedTip = "отнеси еду на стол для готовки, но помни, некоторые продукты нужно сначала порезать";
    public string BringToCookingTableTip = "молодец, теперь отнеси это на стол для готовки";
    public string BringToOvenTip = "теперь неси в печь";
    public string NoWoodsTip = "в печке нет дров";
    public string CantLightFireTip = "невозможно разжечь огонь, руки заняты";
    public string CanUseOvenTip = "теперь можно готовить в печи";
    public string ReadynessInstruction = "если кастрюля покраснела - блюдо готово, если пошел дым - блюдо сгорело";
    public string TimeToPack = "можно уже и упаковать";
    public string FirstCutItTip = "это нужно сначала порезать";
    public string ShowRecipesTip = "нажми на рецепты в левом углу экрана";
    public string CanCookTip = " если галочка возле рецепта зеленая, нажми на нее";
    public string DishIsPackedTip = "упаковали блюдо";
    public string NoPlaceTip = "в рюкзаке уже нет места, пора отправляться в дорогу";
    public string FirstCompleteOldOrdersTip = "сначала доставь прошлый заказ";
    public string IDidntOrderThisTip = "я это блюдо не заказывал";
    public string DishIsPreparedBadly = "блюдо плохо приготовлено, ты не получишь деньги";
    public string NotEnoughMoney = "недостаточно денег";
    public string WaterPatch = "полей грядки";
    public string BringWaterHere = "полей грядку";
    public string NowYouHaveNewVegetable = "теперь в домике появился новый овощ, возьми заказ на новые рецепты";
    public string BringMeAWater = "напои меня водой";
    public string NowYouHaveCheese = "теперь в домике появился сыр, ты можешь взять заказ на новые рецепты";

    public string TakeBackpackTip = "возможно стоило взять с собой посылки";
    //wood
    public string PutWoodInOvenTip = "эти дрова можно положить в печь";

    //inventory prefabs
    public string EatMeTip = "съешь меня";
    public string TakeMeTip = "возьми меня и отнеси на грядку";
    public string KillTheWolfTip = "возьми меня и убей волка";
    public string KillTheWitchTip = "возьми меня, я тебе пригожусь";
    //containers
    public string ThisIsContainerTip = "здесь лежат ингредиенты для блюд";
    public string ThisIsGarbageTip = "это мусорка";
    public string ThisIsPackingPlaceTip = "это место для упаковки готовых блюд";
    //tables 
    public string ThisIsCookingTableTip = "это стол для готовки, здесь можно смешать ингредиенты";
    public string ThisIsCuttingTableTip = "здесь можно порезать продукты";
    public string ThisIsOvenTip = "это печь, в ней можно готовить";
    //recieving orders point
    public string ThisIsRecievingOrdersPointTip = "здесь можно получить заказ";
    //houses
    public string ThisIsHouseTip = "это дом, нажми на дверь, чтобы доставить заказ";
    //cow place
    public string YouCanBringACowHere = "Это место для коровы";
    // cabbage patch
    public string HereYouCanGrowVegetables = "здесь можно выращивать овощи, левая грядка для помидор, правая для капусты";

    //tomato patch

    //well
    public string PutGoldInMe = "кинь в меня 10 золотых и получишь воду";

    public string TakeRewardTip = "возьми награду в центре деревни ";
    public string UseNecronomiconTip = "скорее доставай некрономикон";
    public string YouCanCookOnlyInGrannysHomeTip = "готовить ты можешь только в доме бабушки";
    public string BringMeToPatchTip = "а теперь посади меня в грядку и  полей";
    public string YouCanKillWolfNowTip = "теперь ты можешь убить волка";
    public string YouHaveMeatNowTip = "теперь у тебя в домике есть мясо...";
    public string ItIsNotRightTimeTip = "еще не время...";

}
