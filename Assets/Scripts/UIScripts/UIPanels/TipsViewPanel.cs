using SO;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UIPanels
{
    public class TipsViewPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tipsText;

        // передаем словарь из общего текстового со
        public Dictionary<Tips, string> Names = new Dictionary<Tips, string>()
    {   //inventory prefabs
        {Tips.MushroomTip,"съешь меня" },
        {Tips.SeedTip,"возьми меня и отнеси на грядку" },
        {Tips.SwordTip,"возьми меня и убей волка" },
        {Tips.NecronomiconTip,"возьми меня, я тебе пригожусь" },
        {Tips.CowTip,"возьми меня и отнеси домой" },
        //wood
        {Tips.WoodTip,"эти дрова можно положить в печь" },
        //containers
        {Tips.ContainerTip,"здесь лежат ингредиенты для блюд" },
        {Tips.GarbageContainerTip,"это мусорка" },
        {Tips.PackingPlaceTip,"это место для упаковки готовых блюд" },
        //tables
        {Tips.CuttingTableTip,"здесь можно порезать продукты" },
        {Tips.CookingTableTip,"это стол для готовки, здесь можно смешать ингредиенты" },
        {Tips.OvenTip,"это печь, в ней можно готовить" },
        //door
        {Tips.DoorTip," это дверь" },
        //recieving orders point
        {Tips.RecievingOrdersPointTip,"здесь можно получить заказ" },
        //patch for tomato
        {Tips.TomatoPatchTip,"здесь можно выращивать помидоры" },
        //patch for cabbage
        {Tips.CabbagePatchTip,"здесь можно выращивать  капусту" },
        //place for cow
        {Tips.CowPlaceTip,"Это место для коровы" },
        //house
        {Tips.HouseTip,"это дом, нажми на дверь, чтобы доставить заказ" },
        //well
        {Tips.WellTip,"кинь в меня 10 золотых и получишь воду" },
    };

        private TipsSO _tipsSO;

        private void Start()
        {
            // ShowYouAreSafeTip();
        }

        public void InitTipsSO(TipsSO tipsSO)
        {
            _tipsSO = tipsSO;
        }

        public void ShowItIsNotRightTimeTip()
        {
            ShowTips(_tipsSO.ItIsNotRightTimeTip);
        }

        public void ShowYouHaveMeatNowTip()
        {
            ShowTips(_tipsSO.YouHaveMeatNowTip);
        }

        public void ShowYouCankillTheWolfNowTip()
        {
            ShowTips(_tipsSO.YouCanKillWolfNowTip);
        }

        public void ShowYouCanCookOnkyInGrannysHome()
        {
            ShowTips(_tipsSO.YouCanCookOnlyInGrannysHomeTip);
        }

        public void ShowBringmeToPatchTip()
        {
            ShowTips(_tipsSO.BringMeToPatchTip);
        }

        public void ShowUseNecronomikonTip()
        {
            ShowTips(_tipsSO.UseNecronomiconTip);
        }


        public void ShowKillTheWolfTip()
        {
            ShowTips(_tipsSO.KillTheWolfTip);
        }

        public void ShowIDidntOrderThisTip()
        {
            ShowTips(_tipsSO.IDidntOrderThisTip);
        }

        public void ShowTakeRewardTip()
        {
            ShowTips(_tipsSO.TakeRewardTip);
        }

        public void ShowFirstCompleteOldOrdersTip()
        {
            ShowTips(_tipsSO.FirstCompleteOldOrdersTip);
        }

        public void ShowYouCanBringACowHereTip()
        {
            ShowTips(_tipsSO.YouCanBringACowHere);
        }

        public void ShowGiveMeAWaterTip()
        {
            ShowTips(_tipsSO.BringMeAWater);
        }

        public void ShowNowYouHaveCheeseTip()
        {
            ShowTips(_tipsSO.NowYouHaveCheese);
        }

        public void ShowNowYouHaveNewVegetableTip()
        {
            ShowTips(_tipsSO.NowYouHaveNewVegetable);
        }

        public void ShowBringWaterHere()
        {
            ShowTips(_tipsSO.BringWaterHere);
        }

        public void ShowHereYouCanGrowVegetablesTip()
        {
            ShowTips(_tipsSO.HereYouCanGrowVegetables);
        }

        public void ShowPutGoldInMeTip()
        {
            ShowTips(_tipsSO.PutGoldInMe);
        }

        public void ShowNotEnoughMoneyTip()
        {
            ShowTips(_tipsSO.NotEnoughMoney);
        }

        public void ShowWaterPatchTip()
        {
            ShowTips(_tipsSO.WaterPatch);
        }


        public void ShowYouAreSafeTip()
        {
            ShowTips(_tipsSO.YouAreSafeTip);
        }

        public void ShowYouAreNotSafeTip()
        {
            ShowTips(_tipsSO.YouAreNotSafeTip);
        }

        public void ShowThisIsPackingPlaceTip()
        {
            ShowTips(_tipsSO.ThisIsPackingPlaceTip);
        }

        public void ShowThisISOvenTip()
        {
            ShowTips(_tipsSO.ThisIsOvenTip);
        }

        public void ShowThisIsCookingTableTip()
        {
            ShowTips(_tipsSO.ThisIsCookingTableTip);
        }

        public void ShowFirstCutItTip()
        {
            ShowTips(_tipsSO.FirstCutItTip);
        }

        public void ShowThisIsCuttingTableTip()
        {
            ShowTips(_tipsSO.ThisIsCuttingTableTip);
        }

        public void ShowThisIsGarbageTip()
        {
            ShowTips(_tipsSO.ThisIsGarbageTip);
        }

        public void ShowThisIsContainerTip()
        {
            ShowTips(_tipsSO.ThisIsContainerTip);
        }

        public void ShowTakeBackpackTip()
        {
            ShowTips(_tipsSO.TakeBackpackTip);
        }

        public void ShowPutWoodInOvenTip()
        {
            ShowTips(_tipsSO.PutWoodInOvenTip);
        }

        public void ShowNoPlaceTip()
        {
            ShowTips(_tipsSO.NoPlaceTip);
        }

        public void ShowRecipesTip()
        {
            ShowTips(_tipsSO.ShowRecipesTip);
        }

        public void ShowCanCookTip()
        {
            ShowTips(_tipsSO.CanCookTip);
        }

        public void EraseTip()
        {
            ShowTips(string.Empty);
        }

        public void ShowBringToOvenTip()
        {
            ShowTips(_tipsSO.BringToOvenTip);
        }

        public void ShowDishIssPackedTip()
        {
            ShowTips(_tipsSO.DishIsPackedTip);
        }

        public void ShowTimeToPack()
        {
            ShowTips(_tipsSO.TimeToPack);
        }

        public void ShowReadynessInstruction()
        {
            ShowTips(_tipsSO.ReadynessInstruction);
        }

        public void ShowCanUseOvenTip()
        {
            ShowTips(_tipsSO.CanUseOvenTip);
        }

        public void ShowCantLightFire()
        {
            ShowTips(_tipsSO.CantLightFireTip);
        }

        public void ShowNoWoodsTip()
        {
            ShowTips(_tipsSO.NoWoodsTip);
        }

        public void ShowBringToCookingTableTip()
        {
            ShowTips(_tipsSO.BringToCookingTableTip);
        }

        public void ShowCantCutItTip()
        {
            ShowTips(_tipsSO.CantCutItTip);
        }

        public void ShowCutItTip()
        {
            ShowTips(_tipsSO.CutItTip);
        }

        public void ShowNothingInHandsTip()
        {
            ShowTips(_tipsSO.NothingInHandsTip);
        }

        public void ShowThrowFoodTip()
        {
            ShowTips(_tipsSO.ThrowFoodTip);
        }

        public void ShowFoodPickedTip()
        {
            ShowTips(_tipsSO.FoodPickedTip);
        }

        public void ShowHandsAreFullTip()
        {
            ShowTips(_tipsSO.HandsAreFullTip);
        }

        public void ShowTapTheObjectTip()
        {
            ShowTips(_tipsSO.TapTheObjectTip);
        }

        public void ShowApproachTip()
        {
            ShowTips(_tipsSO.ApproachObjectForInteractionTip);
        }

        public void ShowThisIsRecievingOrdersPointTip()
        {
            ShowTips(_tipsSO.ThisIsRecievingOrdersPointTip);
        }

        public void ShowThisIsHouseTip()
        {
            ShowTips(_tipsSO.ThisIsHouseTip);
        }

        public void ShowDishIsPreparedBadlyTip()
        {
            ShowTips(_tipsSO.DishIsPreparedBadly);
        }

        public void ShowTips(string tips)
        {
            _tipsText.text = tips;
        }

        public void ShowTip(Tips tip)
        {
            _tipsText.text = Names[tip];
        }
    }
}
