using Indexies;
using System.Collections.Generic;

namespace SettingsForYG
{
    public class Turkish : AllPhrases
    {
        private const string Bridge = "köprü";
        private const string Home = "ev";
        private const string Woodcutter = "oduncu";
        private const string PearVillage = "armut köyü";
        private const string AppleVillage = "elma köyü";
        private const string CowVillage = "inek köyü";
        private const string GreenVillage = "yeşil köyü";
        private const string RiverVillage = "nehir köyü";

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

        public Turkish()
        {
            VillagesNames = new()
            {
              { NamesOfVillages.Woodcutter, Woodcutter },
              { NamesOfVillages.FirstVillageName, PearVillage },
              { NamesOfVillages.SecondVillageName, AppleVillage },
              { NamesOfVillages.ThirdVillageName, CowVillage },
              { NamesOfVillages.FourthVillageName, GreenVillage },
              { NamesOfVillages.LastVillageName, RiverVillage },
            };
            AllSignsText = new()
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
            Education = new()
            {
               "sonraki tavsiyei görmek için yeşil oku tıkla",
               "kamera görünümünü ve ses seviyesini değiştirebilirsin, sağdaki siyah düğme tıkla",
               "açılan pencerede büyüteç kamera yakınlaştırmasından, hoparlör ses seviyesinden ve notalar arka plan müziğinin seviyesinden sorumludur.",
               "artırmak için kaydırıcıyı sağa, azaltmak için sola sürüklemeniz yeterlidir",
               "sağda  hediyeye tıklayarak bir reklam izleyeceksin ve bunun için bir ödül alacaksın: odun veya mantar",
               "oyunda etkileşim kurabileceğin birçok nesne var",
               "yaklaştığında gri renkte yanıyorlar",
               "büyükannenin evinin girişindeki kuş evine git",
               "üzerine tıkla ve siparişini alacaksın",
               "sol üst köşedeki kaydırma işaretine tıklayarak siparişini görüntüleyebilirsin",
               "şimdi eve gir - bunu yapmak için kapıya git ve bas",
               "önce odunu alıp fırına koy",
               "şimdi un çuvalına git ve biraz al",
               "unu yemek masasına koyun ve tarifleri açın - sol üst köşedeki kaydırma",
               "yeterli malzeme varsa tarifin yanında yeşil bir onay işareti görünecek, üzerine tıkla",
               "yemek masasında bir tencere belirdi, onu alıp fırına getir",
               "tava kırmızıya dönerse hemen çıkarın ve paketle birlikte tezgaha getir",
               "ocağından dumanı çıkıyorsa, yemek yanmıştır, çöp kutusuna atıp baştan başlamak daha iyidir",
               "tencereyiı paketin içine koyun, paketi alın ve hemen oduncuya getir",
               "oduncunun evi büyükannenin evinin yanında, tabelaya kadar yol boyunca düz ilerleyin",
               "yoldan ayrılmayın yoksa kurt senii yer",
               "tabelanın yanında erik ağaçları var, böyle ağaçlarda kurttan saklanabilirsin ve kaydedebilirsin",
               "mantar da yetiştiriyor, onları yiyebilirsin, mantarın yanına gidip üzerine tıklayabilirsin",
               "bundan sonra mantar envanterinizde görünecek, üzerine tıkla",
               "sarı mantarlar hızı artırır, kırmızı mantarlar sağlığı artırır",
               "yol boyunca düz git, oduncunun evini göreceksin",
               "paketi teslim etmek için oduncunun evinin kapısına git ve tıkla",
               "sipariş iyi pişirilirse - çiğ değilse ve yanmamışsa, parayı alırsın",
               "parayla kuyudan su satın alabilirsin, bahçe tarhlarında sebze yetiştirmek gerekiyor",
               "tüm siparişler teslim edildikten sonra köyden sebze temin edilebilir",
               "kafan karışırsa sağ üst köşedeki kitaba tıklayın, o size ne yapman gerektiğini söyleyecektir",
               "Artık tek başınasın, yemekleri hazırla, köylere getir",
               "...ama kurdu varlığı asla unutma",
            };

            PreEducationText = "büyük annenin evine doğru koş, hareket etmek için WASD tuşlarını kullan, kamerayı yakınlaştırmak için fare tekerleğini kullan";
            SkipEducationButtonText = "atla";
            Restart = "baştan başla";
            SaveGameText = "oyun kaydedildi";
            NeedToAuthorizeText = "oyncuların tablosunu görmek için giriş yapmanı gerekir";
            LeaderbordName = "en iyi oyuncular";
            Name = "isim";
            AnonymousName = "anonim";
            DeliveredDishesName = "teslim edilen yemek";
        }
    }
}