using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;
    public int xp = 0;
    public int xpNeedForLevel = 10;
    public float xpNeedIncreaseFactor = 1.2f;

    public GameObject uiXpProgressBar;

    public void GetXp(int value)
    {
        xp += value;

        if (xp >= xpNeedForLevel)
        {
            LevelUp();
        }

        uiXpProgressBar.GetComponent<UIXpProgressBar>().UpdateBar(xp, xpNeedForLevel);
    }

    private void LevelUp()
    {
        level++;
        xp -= xpNeedForLevel;
        xpNeedForLevel = (int)(xpNeedForLevel * xpNeedIncreaseFactor);

        // todo: show window to select from 3 random upgrades
    }
}
