using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int score;
    public List<string> playerSkills;

    public GameData()
    {
        score = 0;
        playerSkills = new List<string>();
    }
}
