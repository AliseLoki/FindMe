using System.Collections.Generic;
using Indexies;

namespace SettingsForYG
{
    public class English : AllPhrases
    {
        private const string Bridge = nameof(Bridge);
        private const string Home = nameof(Home);
        private const string Woodcutter = nameof(Woodcutter);
        private const string PearVillage = "pear village";
        private const string AppleVillage = "apple village";
        private const string CowVillage = "cow village";
        private const string GreenVillage = "green village";
        private const string RiverVillage = "river village";

        public static List<string> FirstSign = new List<string>()
        {
          { Bridge }, { Home }, { Woodcutter }, { PearVillage },
        };

        public static List<string> SecondSign = new List<string>()
        {
          { Bridge }, { Woodcutter }, { Home }, { PearVillage },
        };

        public static List<string> ThirdSign = new List<string>()
        {
          { Home }, { Bridge }, { Woodcutter }, { PearVillage },
        };

        public static List<string> FourthSign = new List<string>()
        {
          { Woodcutter }, { PearVillage }, { Home }, { AppleVillage },
        };

        public static List<string> FifthSign = new List<string>()
        {
          { Bridge }, { AppleVillage }, { Home }, { PearVillage },
        };

        public static List<string> SixthSign = new List<string>()
        {
          { RiverVillage }, { Bridge }, { GreenVillage }, { CowVillage },
        };

        public static List<string> SeventhSign = new List<string>()
        {
          { CowVillage }, { Bridge }, { GreenVillage }, { RiverVillage },
        };

        public static List<string> EighthSign = new List<string>()
        {
          { Bridge }, { CowVillage }, { GreenVillage }, { RiverVillage },
        };

        public static List<string> NinthSign = new List<string>()
        {
          { CowVillage }, { GreenVillage }, { RiverVillage }, { Bridge },
        };

        public static List<string> TenthSign = new List<string>()
        {
          { GreenVillage }, { Bridge }, { PearVillage }, { AppleVillage },
        };

        public static List<string> EleventhSign = new List<string>()
        {
          { GreenVillage }, { Bridge }, { RiverVillage }, { AppleVillage },
        };

        public static List<string> TwelfthSign = new List<string>()
        {
          { Home }, { RiverVillage }, { PearVillage }, { AppleVillage },
        };

        public English()
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
                "to go to the next tip, click the green arrow under the text",
                "you can change the camera view and volume, click on the black gear on the right",
                "in the window that appears, the magnifying glass is responsible for zooming, the speaker is responsible for the volume of sounds, and the notes are responsible for the volume of background music",
                "just drag the slider to the right to increase, to the left to decrease",
                "click on the present on the right, you will watch add and get present:  mushroom or wood",
                "there are a lot of objects in the game that you can interact with",
                "they light up gray when you approach",
                "go to the bird's house, at the entrance to grandma's house",
                "click on it and you will receive an order",
                "you can view your orders by clicking on the scroll in the upper left corner",
                "now go into the house - to do this, go to the door and click on it",
                "first take the firewood and put it in the oven",
                "now go to the sack of flour and take some",
                "put the flour on the cooking table and open the recipes - the scroll in the upper left corner",
                "if there are enough ingredients, a green checkmark will appear next to the recipe, click on it",
                "a pan has appeared on the cooking table, grab it and take it to the oven",
                "if the pan turns red, quickly take it out and take it to the bench with the parcel",
                "if smoke comes from the stove, the dish is burnt, it is better to throw it in a trash box and start over",
                "put the pan in the parcel, take the parcel and quickly bring it to the woodcutter",
                "the woodcutter's house is next to grandma's house, go straight along the road until the sign",
                "don't leave the road, otherwise the wolf will eat you",
                "near the signpost there are plum trees, in such trees you can hide from the wolf and save progress",
                "also there are mushrooms, you can eat them, go to the mushroom and click on it",
                "after this the mushroom will appear in your inventory, click on it",
                "yellow mushrooms increase speed, red mushrooms increase health",
                "just go straight along the path and you will see the woodcutter's house",
                "to deliver the package, go to the door of the woodcutter's house and click on it",
                "if the order is cooked well - not raw and not burnt, you will get the money",
                "with money you can buy water in a well, it is needed to grow vegetables in the garden",
                "vegetables can be obtained in the village after all orders have been delivered",
                "if you get stuck, click on the book in the upper right corner, it will tell you  what to do",
                "now you are on your own, prepare dishes, deliver them to the villages",
                "but never forget about the wolf...",
            };

            PreEducationText = "run forward to granny's house, use WASD buttons to move, mouse wheel for camera zoom";
            SkipEducationButtonText = "skip";
            Restart = "restart";
            SaveGameText = "game saved";
            NeedToAuthorizeText = "to view the leaderboard you need to log in";
            LeaderbordName = "best players";
            Name = "name";
            AnonymousName = "anonymous";
            DeliveredDishesName = "dishes delivered";
        }
    }
}