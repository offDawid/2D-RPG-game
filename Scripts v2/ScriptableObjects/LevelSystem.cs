using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    private int level;
    private int exp;
    private int expToNextLevel;

    public LevelSystem()
    {
        level = 0;
        exp = 0;
        expToNextLevel = 100;
    }
     
    public void AddExp(int amount)
    {
        exp += amount;
        if (exp >= expToNextLevel)
        {
            level++;
            exp -= expToNextLevel;
        }
    }

    public int GetLevel()
    {
        return level;
    }
}
