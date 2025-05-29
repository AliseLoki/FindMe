using System.Collections.Generic;
using Indexies;

namespace SettingsForYG
{
    public class Russian : AllPhrases
    {
        private const string Bridge = "����";
        private const string Home = "������";
        private const string Woodcutter = "��������";
        private const string PearVillage = "��������";
        private const string AppleVillage = "���������";
        private const string CowVillage = "��������";
        private const string GreenVillage = "���������";
        private const string RiverVillage = "�������";

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
              "����� ������� � ���������� ������, ����� ������� ��������� ��� �������",
              "�� ������ ������ ��� ������ � ���������, ����� �� ������ ���������� ������",
              "� ����������� ������ ���� �������� �� ����������� ������, ������� �� ��������� ������, � ���� �� ��������� ������� ������",
              "������ ������� �������� ������ ��� ����������, ����� ��� ����������",
              "����� �� ������ �������, �� ���������� ������� � �������� �� ��� ���� ����, ���� �����",
              "� ���� ����� ��������, � �������� ����� �����������������",
              "��� �������������� ����� ������ ��� ����� �����������",
              "������� � ���� ������,  � ����� � ��� �������",
              "����� �� ���� � �������� �����",
              "����� ����� ����������, ����� �� ������ � ����� ������� ����",
              "� ������ ������ � ��� - ��� ����� ������� � ����� � ����� �� ���",
              "������� ������ �����  � ������ �� � ����",
              "������ ������� � ����� ���� � ������ �������",
              "������ ���� �� ���� ��� ������� � ������ ������� - ������ � ����� ������� ����",
              "���� ������������  �������, �� ����� ������� �������� ������� �������, ����� �� ���",
              "�� ����� ��� ������� ��������� ��������, ������ �� � ���� � ����",
              "���� �������� ���������� ������ �������� � ���� � ������ � ��������",
              "���� ����� ��� �� �����, ����� �������, ����� ��� ��������� � ���� � ������ � ������",
              "������ �������� � �������, ������ ������� � ������ ���� ���������",
              "����� ��������� ����� � ����� �������, ��� ����� �� ������ �� ���������",
              "�� ����� � ������, � �� ���� ���� �����",
              "����� ��������� ���� �������� �������, � ����� �������� ����� ��������� �� ����� � ����� �����������",
              "����� � ���� ������ �����, �� ����� ���� ������� � ����� � ����� �� ����",
              "����� ����� ���� �������� � ���������, ����� �� ����",
              "������ ����� ���������� ��������, ������� ��������",
              "������ ��� ����� �� ������� � ������� ��� ���������",
              "����� ��������� �������, ������� � ����� ���� ��������� � ����� �� ���",
              "���� ����� ����������� ������ - �� ����� � �� ��������, �� �������� ������",
              "�� ������ ����� ������ ���� � �������, ��� ����� ����� ���������� ����� �� �������",
              "����� ����� �������� � �������, ����� �������� ���� �������",
              "���� �����������, ����� �� ����� � ������ ������� ����, ��� ��������� ���� ��� ������",
              "������ �� ��� �� ����, ������ �����, ��������� �� � �������",
              "... �� ������� �� ������� � �����",
            };

            PreEducationText = "���� ������ � ���� �������, ��������� ������ ���� ��� ������������, �������� ����� ��� ����������� ������";
            SkipEducationButtonText = "���������� ��������";
            Restart = "�������";
            SaveGameText = "���� ���������";
            NeedToAuthorizeText = "��� ��������� ������� ������� ����� ��������������";
            LeaderbordName = " ������ ������";
            Name = "���";
            AnonymousName = "������";
            DeliveredDishesName = "���������� ����";
        }
    }
}