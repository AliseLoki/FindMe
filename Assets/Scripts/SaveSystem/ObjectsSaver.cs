using System.Collections.Generic;
using UnityEngine;
using Interactables;
using Interactables.Containers;
using Interactables.Patches;
using Indexes;
using Villages;
using SO;

namespace SaveSystem
{
    public class ObjectsSaver : MonoBehaviour
    {
        [SerializeField] private List<Container> _allContainers;
        [SerializeField] private List<ActivableObjectType> _activeContainers;

        [SerializeField] private List<Patch> _allPatches;
        [SerializeField] private List<ActivableObjectType> _activePatches;

        [SerializeField] private List<House> _allHouses;
        [SerializeField] private List<HouseIndex> _housesThatRecivedOrders;

        [SerializeField] private List<Transform> _allPlacesWithReward;
        [SerializeField] private List<InventoryPrefabSO> _givenRewards;

        [SerializeField] private List<Village> _allVillages;

        [SerializeField] private List<VillageIndex> _villagesThatGaveReward;
        [SerializeField] private List<VillageIndex> _villagesWhereRewardIsntPickedUp;

        public void InitAllVillagesThatGaveReward(List<VillageIndex> villagesThatGaveReward)
        {
            _villagesThatGaveReward = villagesThatGaveReward;

            foreach (var index in _villagesThatGaveReward)
            {
                foreach (var village in _allVillages)
                {
                    if (index == village.Index)
                    {
                        village.SetIsGivenReward(true);
                    }
                }
            }
        }

        public List<VillageIndex> SaveRewardIsGiven()
        {
            foreach (var village in _allVillages)
            {
                if (village.IsGivenReward)
                {
                    _villagesThatGaveReward.Add(village.Index);
                }
            }

            return _villagesThatGaveReward;
        }

        public void InitNotPickedRewards(List<VillageIndex> villagesWithNotPickedUpReward)
        {
            _villagesWhereRewardIsntPickedUp = villagesWithNotPickedUpReward;

            foreach (var index in _villagesWhereRewardIsntPickedUp)
            {
                foreach (var village in _allVillages)
                {
                    if (index == village.Index)
                    {
                        village.GiveReward();
                    }
                }
            }
        }

        public List<VillageIndex> SaveNotPickedRewards()
        {
            foreach (Village village in _allVillages)
            {
                if (village.SpawnPoint.childCount > 0)
                {
                    _villagesWhereRewardIsntPickedUp.Add(village.Index);
                }
            }

            return _villagesWhereRewardIsntPickedUp;
        }

        public void InitAllHouses(List<HouseIndex> houseIndexes)
        {
            _housesThatRecivedOrders = houseIndexes;

            foreach (var item in _housesThatRecivedOrders)
            {
                foreach (House house in _allHouses)
                {
                    if (house.Index == item)
                    {
                        house.InitIsDelivered();
                    }
                }
            }
        }

        public List<HouseIndex> SaveAllHousesThatRecivedOrders()
        {
            foreach (House house in _allHouses)
            {
                if (house.IsDelivered && !_housesThatRecivedOrders.Contains(house.Index))
                {
                    _housesThatRecivedOrders.Add(house.Index);
                }
            }

            return _housesThatRecivedOrders;
        }

        public void InitAllActivePatches(List<ActivableObjectType> activableObjectTypes)
        {
            _activePatches = activableObjectTypes;

            EnablePatches();
        }

        public List<ActivableObjectType> SaveAllActivePatches()
        {
            foreach (Patch patch in _allPatches)
            {
                if (patch.Grass.gameObject.activeSelf && !_activePatches.Contains(patch.ActivableObject))
                {
                    _activePatches.Add(patch.ActivableObject);
                }
            }

            return _activePatches;
        }

        public void InitAllActiveContainers(List<ActivableObjectType> activableObjectTypes)
        {
            _activeContainers = activableObjectTypes;
            EnableContainers();
        }

        public List<ActivableObjectType> SaveAllActiveContainers()
        {
            foreach (Container container in _allContainers)
            {
                if (container.gameObject.activeSelf && !_activeContainers.Contains(container.ActivableObject))
                {
                    _activeContainers.Add(container.ActivableObject);
                }
            }

            return _activeContainers;
        }

        private void EnablePatches()
        {
            foreach (var item in _activePatches)
            {
                foreach (Patch patch in _allPatches)
                {
                    if (patch.ActivableObject == item)
                    {
                        patch.Grass.gameObject.SetActive(true);
                    }
                }
            }
        }

        private void EnableContainers()
        {
            foreach (var item in _activeContainers)
            {
                foreach (Container container in _allContainers)
                {
                    if (container.ActivableObject == item)
                    {
                        container.gameObject.SetActive(true);
                        EnablePatchChildObjects(container);
                    }
                }
            }
        }

        private void EnablePatchChildObjects(Container container)
        {
            foreach (Patch patch in _allPatches)
            {
                if (patch.BarrelWithIngredients == container)
                {
                    foreach (Transform child in patch.transform)
                    {
                        child.gameObject.SetActive(true);
                        patch.DisableInteract();
                    }
                }
            }
        }
    }
}
