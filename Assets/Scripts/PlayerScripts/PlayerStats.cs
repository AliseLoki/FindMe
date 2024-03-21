using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentExp;
    public int[] expToNextLevel;
    public int maxLevel = 6;
    public int baseEXP = 100;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int strength;
    public int defence;
    public int wpnPwr;
    public int armPwr;
    public int equippedWpn;
    public int equippedArmr;
    public Sprite charImage;

    private void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for (int i = 1; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = expToNextLevel[i - 1] + baseEXP;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddExp(25);
        }
    }

    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;

        if (currentExp > expToNextLevel[playerLevel] && playerLevel < maxLevel - 1)
        {
            currentExp -= expToNextLevel[playerLevel];
            playerLevel++;

          //  if(playerLevel)
        }
    }
}
