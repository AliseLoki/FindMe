using System.Collections.Generic;
using Indexies;

namespace SettingsForYG
{
    public abstract class AllPhrases
    {
        public string Restart;
        public string SkipEducationButtonText;
        public string PreEducationText;
        public string SaveGameText;
        public string NeedToAuthorizeText;
        public string LeaderbordName;
        public string Name;
        public string AnonymousName;
        public string DeliveredDishesName;

        public Dictionary<NamesOfVillages, string> VillagesNames;
        public Dictionary<SignsNumbers, List<string>> AllSignsText;
        public List<string> Education;
    }
}