using System.Collections.Generic;
using Indexies;

namespace SettingsForYG
{
    public class Russian : AllPhrases
    {
        private const string Bridge = "мост";
        private const string Home = "хижина";
        private const string Woodcutter = "дровосек";
        private const string PearVillage = "грушевка";
        private const string AppleVillage = "яблоневка";
        private const string CowVillage = "коровино";
        private const string GreenVillage = "зеленовка";
        private const string RiverVillage = "заречье";

        private static List<string> FirstSign = new List<string>()
        {
          { Bridge }, { Home }, { Woodcutter }, { PearVillage },
        };

        private static List<string> SecondSign = new List<string>()
        {
          { Bridge }, { Woodcutter }, { Home }, { PearVillage },
        };

        private static List<string> ThirdSign = new List<string>()
        {
          { Home }, { Bridge }, { Woodcutter }, { PearVillage },
        };

        private static List<string> FourthSign = new List<string>()
        {
          { Woodcutter }, { PearVillage }, { Home }, { AppleVillage },
        };

        private static List<string> FifthSign = new List<string>()
        {
          { Bridge }, { AppleVillage }, { Home }, { PearVillage },
        };

        private static List<string> SixthSign = new List<string>()
        {
          { RiverVillage }, { Bridge }, { GreenVillage }, { CowVillage },
        };

        private static List<string> SeventhSign = new List<string>()
        {
          { CowVillage }, { Bridge }, { GreenVillage }, { RiverVillage },
        };

        private static List<string> EighthSign = new List<string>()
        {
          { Bridge }, { CowVillage }, { GreenVillage }, { RiverVillage },
        };

        private static List<string> NinthSign = new List<string>()
        {
          { CowVillage }, { GreenVillage }, { RiverVillage }, { Bridge },
        };

        private static List<string> TenthSign = new List<string>()
        {
          { GreenVillage }, { Bridge }, { PearVillage }, { AppleVillage },
        };

        private static List<string> EleventhSign = new List<string>()
        {
          { GreenVillage }, { Bridge }, { RiverVillage }, { AppleVillage },
        };

        private static List<string> TwelfthSign = new List<string>()
        {
          { Home }, { RiverVillage }, { PearVillage }, { AppleVillage },
        };

        public Russian()
        {
            VillagesNames = new ()
            {
              { NamesOfVillages.Woodcutter, Woodcutter },
              { NamesOfVillages.FirstVillageName, PearVillage },
              { NamesOfVillages.SecondVillageName, AppleVillage },
              { NamesOfVillages.ThirdVillageName, CowVillage },
              { NamesOfVillages.FourthVillageName, GreenVillage },
              { NamesOfVillages.LastVillageName, RiverVillage },
            };
            AllSignsText = new ()
            {
              { SignsNumbers.First, FirstSign },
              { SignsNumbers.Second, SecondSign },
              { SignsNumbers.Third, ThirdSign },
              { SignsNumbers.Fourth, FourthSign },
              { SignsNumbers.Fifth, FifthSign },
              { SignsNumbers.Sixth, SixthSign },
              { SignsNumbers.Seventh, SeventhSign },
              { SignsNumbers.Eights, EighthSign },
              { SignsNumbers.Ninth, NinthSign },
              { SignsNumbers.Tenth, TenthSign },
              { SignsNumbers.Eleventh, EleventhSign },
              { SignsNumbers.Twelfth, TwelfthSign },
            };
            Education = new ()
            {
              "чтобы перейти к следующему совету, нажми зеленую стрелочку под текстом",
              "ты можешь менять вид камеры и громкость, нажми на черную шестеренку справа",
              "в появившемся окошке лупа отвечает за приближение камеры, динамик за громкость звуков, а ноты за громкость фоновой музыки",
              "просто пертащи ползунок вправо для увеличения, влево для уменьшения",
              "нажав на значок подарка, ты посмотришь рекламу и получишь за это либо гриб, либо дрова",
              "в игре много объектов, с которыми можно взаимодействовать",
              "они подсвечиваются серым цветом при твоем приближении",
              "подойди к дому птички,  у входа в дом бабушки",
              "нажми на него и получишь заказ",
              "заказ можно посмотреть, нажав на свиток в левом верхнем углу",
              "а теперь заходи в дом - для этого подойди к двери и нажми на нее",
              "сначала возьми дрова  и положи их в печь",
              "теперь подойди к мешку муки и возьми немного",
              "положи муку на стол для готовки и открой рецепты - свиток в левом верхнем углу",
              "если ингредиентов  хватает, то около рецепта появится зеленая галочка, нажми на нее",
              "на столе для готовки появилась кастрюля, хватай ее и неси в печь",
              "если кастрюля покраснела скорее доставай и неси к скамье с посылкой",
              "если пошел дым из печки, блюдо сгорело, лучше его выбросить в ящик и начать с начала",
              "положи кастрюлю в посылку, возьми посылку и скорее неси дровосеку",
              "домик дровосека рядом с домом бабушки, иди прямо по дороге до указателя",
              "не сходи с дороги, а то волк тебя съест",
              "около указателя есть сливовые деревья, в таких деревьях можно прятаться от волка а также сохраняться",
              "также у него растут грибы, их можно есть подойди к грибу и нажми на него",
              "после этого гриб появится в инвентаре, нажми на него",
              "желтые грибы прибавляют скорость, красные здоровье",
              "просто иди прямо по дорожке и увидишь дом дровосека",
              "чтобы доставить посылку, подойди к двери дома дровосека и нажми на нее",
              "если заказ приготовлен хорошо - не сырой и не сожжённый, ты получишь деньги",
              "на деньги можно купить воду в колодце, она нужна чтобы выращивать овощи на грядках",
              "овощи можно получить в деревне, после доставки всех заказов",
              "если запутаешься, нажми на книгу в правом верхнем углу, она подскажет тебе что делать",
              "теперь ты сам по себе, готовь блюда, доставляй их в деревни",
              "... но никогда не забывай о волке",
            };

            PreEducationText = "беги вперед к дому бабушки, используй кнопки ЦФЫВ для передвижения, колесико мышки для приближения камеры";
            SkipEducationButtonText = "пропустить обучение";
            Restart = "рестарт";
            SaveGameText = "игра сохранена";
            NeedToAuthorizeText = "для просмотра таблицы игроков нужно авторизоваться";
            LeaderbordName = " лучшие игроки";
            Name = "имя";
            AnonymousName = "аноним";
            DeliveredDishesName = "доставлено блюд";
        }
    }
}