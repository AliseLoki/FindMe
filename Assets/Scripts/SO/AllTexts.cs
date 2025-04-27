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
    public string FirstEducationText = "������ �� �� ������ �������� ?";
    public string StartEducationButtonText = "������ ��������"; // yes
    public string SkipEducationButtonText = "���������� ��������"; //no

    public List<string> Advices = new List<string>()
    {
        {" ����� ������� � ���������� ������, ����� ������� ��������� ��� �������" },
        {"�� ������ ������ ��� ������ � ���������, ����� �� ������ ���������� ������" },
        {"� ����������� ������ ���� �������� �� ����������� ������, ������� �� ��������� ������, � ���� �� ��������� ������� ������" },
        {"������ ������� �������� ������ ��� ����������, ����� ��� ����������" },
        {"����� �� ������ �������, �� ���������� ������� � �������� �� ��� ���� ����, ���� �����" },
        {"� ���� ����� ��������, � �������� ����� �����������������" },
        {"��� �������������� ����� ������ ��� ����� �����������" },
        {"������� � ���� ������,  � ����� � ��� �������" },
        {"����� �� ���� � �������� �����" },
        {"����� ����� ����������, ����� �� ������ � ����� ������� ����" },
        {"� ������ ������ � ��� - ��� ����� ������� � ����� � ����� �� ���" },
        {"������� ������ �����  � ������ �� � ����" },
        {"������ ������� � ����� ���� � ������ �������" },
        {"������ ���� �� ���� ��� ������� � ������ ������� - ������ � ����� ������� ����" },
        {"���� ������������  �������, �� ����� ������� �������� ������� �������, ����� �� ���" },
        {"�� ����� ��� ������� ��������� ��������, ������ �� � ���� � ����" },
        {"���� �������� ���������� ������ �������� � ���� � ������ � ��������" },
        {"���� ����� ��� �� �����, ����� �������, ����� ��� ��������� � ���� � ������ � ������" },
        {"������ �������� � �������, ������ ������� � ������ ���� ���������" },
        {"����� ��������� ����� � ����� �������, ��� ����� �� ������ �� ���������" },
        {"�� ����� � ������, � �� ���� ���� �����" },
        {"����� ��������� ���� �������� �������, � ����� �������� ����� ��������� �� ����� � ����� �����������" },
        {"����� � ���� ������ �����, �� ����� ���� ������� � ����� � ����� �� ����" },
        {"����� ����� ���� �������� � ���������, ����� �� ����" },
        {"������ ����� ���������� ��������, ������� ��������" },
        {"������ ��� ����� �� ������� � ������� ��� ���������" },
        {"����� ��������� �������, ������� � ����� ���� ��������� � ����� �� ���" },
        {"���� ����� ����������� ������ - �� ����� � �� ��������, �� �������� ������" },
        {"�� ������ ����� ������ ���� � �������, ��� ����� ����� ���������� ����� �� �������" },
        {"����� ����� �������� � �������, ����� �������� ���� �������" },
        {"���� �����������, ����� �� ����� � ������ ������� ����, ��� ��������� ���� ��� ������" },
        {"������ �� ��� �� ����, ������ �����, ��������� �� � �������" },
        {"... �� ������� �� ������� � �����" }
    };

    //first start SO
    public string WelcomeTex = "����� �� �� ������ ����������� ?";
    public string RunText = "����� ���� ������ � ���� �������, ��������� ������ �,�,�,� ��� ������������, �������� ����� ��� ����������� ������";
    public string YesButtonText = "��"; //yes
    public string RemainingTimeText = "�������� ������� �� ������ �������";
    public string LeaderbordName = " ������ ������";
    public string Name = "���";
    public string Place = "�����";
    public string DeliveredDishesName = "���������� ����";
    public string CloseButtonText = "�������";
    public string AuthorizeButtonText = "��������������";
    public string NeedToAuthorizeText = "��� ��������� ������� ������� ����� ��������������";
    public string AnonymousName = "������";
    public string SaveGameText = "���� ���������";
    public string FullRestartButtonText = "������ ������� - ������� �";

    // GameOverSO
    public string Restart = "�������";
    public string GameOver = "���� �������� ";
    public string VictoryText = " �� ������� !!!";
    public string LooseText = "� ����� ���� ...";

    //VillagesName

    public string Woodcutter = "��������";
    public string FirstVillageName = "��������";
    public string SecondVillageName = "���������";
    public string ThirdVillageName = "��������";
    public string FourthVillageName = "���������";
    public string LastVillageName = "�������";

    // SignsSO
    public List<string> FirstSign = new List<string>()
    {
        {"����" }, {"������"},{"��������" }, {"��������"},
    };

    public List<string> SecondSign = new List<string>()
    {
        {"����" },{"��������"},{"������"},{"��������"}
    };

    public List<string> ThirdSign = new List<string>()
    {
        {"������" },{"����"},{"��������"},{"��������"}
    };

    public List<string> FourthSign = new List<string>()
    {
        { "��������" }, { "��������" }, { "������" }, { "���������" }
    };

    public List<string> FifthSign = new List<string>()
    {
        { "����" }, { "���������" }, { "������" }, { "��������" }
    };

    public List<string> SixthSign = new List<string>()
    {
        { "�������" }, { "����" }, { "���������" }, { "��������" }
    };

    public List<string> SeventhSign = new List<string>()
    {
        { "��������" }, { "����" }, { "���������" }, { "�������" }
    };

    public List<string> EighthSign = new List<string>()
    {
        {"����" },{"��������"},{"���������"},{"�������"}
    };

    public List<string> NinthSign = new List<string>()
    {
        { "��������" }, { "���������" }, { "�������" }, { "����" }
    };

    public List<string> TenthSign = new List<string>()
    {
        { "���������" }, { "����" }, { "��������" }, { "���������" }
    };

    public List<string> EleventhSign = new List<string>()
    {
        { "���������" }, { "����" }, { "�������" }, { "���������" }
    };

    public List<string> TwelfthSign = new List<string>()
    {
        { "������" }, { "�������" }, { "��������" }, { "���������" }
    };


    // Tips SO

    public Dictionary<Tips, string> AllTips = new Dictionary<Tips, string>() 
    {
    
        {Tips.YouAreSafeTip,"� ������ ������� �� � ������������, ���� ���� �� �����" },
        {Tips.YouAreNotSafeTip,"�� ����� � ������, ���� ����� ��� ����� ���� ������ � ����..." },
        {Tips.ApproachObjectForInteractionTip,"���� ������ ������������ �������, ���� � ���� �������" },
        {Tips.TapTheObjectTip,"������� ������, ����� �� ����"},
        {Tips.HandsAreFullTip,"���� ������" },
    };


    //public string YouAreSafeTip = "� ������ ������� �� � ������������, ���� ���� �� �����";
   // public string YouAreNotSafeTip = "�� ����� � ������, ���� ����� ��� ����� ���� ������ � ����...";
   // public string ApproachObjectForInteractionTip = "���� ������ ������������ �������, ���� � ���� �������";
  //  public string TapTheObjectTip = "������� ������, ����� �� ����";
   // public string HandsAreFullTip = "���� ������";
    public string ThrowFoodTip = "�� ������ ��� ������ ��� ����������?";
    public string NothingInHandsTip = "� ��� � ����� ������ ���";
    public string CutItTip = "����� ��� ��� ����� ��������";
    public string CantCutItTip = "��� ���������� ��������";
    public string FoodPickedTip = "������ ��� �� ���� ��� �������, �� �����, ��������� �������� ����� ������� ��������";
    public string BringToCookingTableTip = "�������, ������ ������ ��� �� ���� ��� �������";
    public string BringToOvenTip = "������ ���� � ����";
    public string NoWoodsTip = "� ����� ��� ����";
    public string CantLightFireTip = "���������� ������� �����, ���� ������";
    public string CanUseOvenTip = "������ ����� �������� � ����";
    public string ReadynessInstruction = "���� �������� ���������� - ����� ������, ���� ����� ��� - ����� �������";
    public string TimeToPack = "����� ��� � ���������";
    public string FirstCutItTip = "��� ����� ������� ��������";
    public string ShowRecipesTip = "����� �� ������� � ����� ���� ������";
    public string CanCookTip = " ���� ������� ����� ������� �������, ����� �� ���";
    public string DishIsPackedTip = "��������� �����";
    public string NoPlaceTip = "� ������� ��� ��� �����, ���� ������������ � ������";
    public string FirstCompleteOldOrdersTip = "������� ������� ������� �����";
    public string IDidntOrderThisTip = "� ��� ����� �� ���������";
    public string DishIsPreparedBadly = "����� ����� ������������, �� �� �������� ������";
    public string NotEnoughMoney = "������������ �����";
    public string WaterPatch = "����� ������";
    public string BringWaterHere = "����� ������";
    public string NowYouHaveNewVegetable = "������ � ������ �������� ����� ����, ������ ����� �� ����� �������";
    public string BringMeAWater = "����� ���� �����";
    public string NowYouHaveCheese = "������ � ������ �������� ���, �� ������ ����� ����� �� ����� �������";

    public string TakeBackpackTip = "�������� ������ ����� � ����� �������";
    //wood
    public string PutWoodInOvenTip = "��� ����� ����� �������� � ����";

    //inventory prefabs
    public string EatMeTip = "����� ����";
    public string TakeMeTip = "������ ���� � ������ �� ������";
    public string KillTheWolfTip = "������ ���� � ���� �����";
    public string KillTheWitchTip = "������ ����, � ���� ���������";
    //containers
    public string ThisIsContainerTip = "����� ����� ����������� ��� ����";
    public string ThisIsGarbageTip = "��� �������";
    public string ThisIsPackingPlaceTip = "��� ����� ��� �������� ������� ����";
    //tables 
    public string ThisIsCookingTableTip = "��� ���� ��� �������, ����� ����� ������� �����������";
    public string ThisIsCuttingTableTip = "����� ����� �������� ��������";
    public string ThisIsOvenTip = "��� ����, � ��� ����� ��������";
    //recieving orders point
    public string ThisIsRecievingOrdersPointTip = "����� ����� �������� �����";
    //houses
    public string ThisIsHouseTip = "��� ���, ����� �� �����, ����� ��������� �����";
    //cow place
    public string YouCanBringACowHere = "��� ����� ��� ������";
    // cabbage patch
    public string HereYouCanGrowVegetables = "����� ����� ���������� �����, ����� ������ ��� �������, ������ ��� �������";

    //tomato patch

    //well
    public string PutGoldInMe = "���� � ���� 10 ������� � �������� ����";

    public string TakeRewardTip = "������ ������� � ������ ������� ";
    public string UseNecronomiconTip = "������ �������� ������������";
    public string YouCanCookOnlyInGrannysHomeTip = "�������� �� ������ ������ � ���� �������";
    public string BringMeToPatchTip = "� ������ ������ ���� � ������ �  �����";
    public string YouCanKillWolfNowTip = "������ �� ������ ����� �����";
    public string YouHaveMeatNowTip = "������ � ���� � ������ ���� ����...";
    public string ItIsNotRightTimeTip = "��� �� �����...";

}
