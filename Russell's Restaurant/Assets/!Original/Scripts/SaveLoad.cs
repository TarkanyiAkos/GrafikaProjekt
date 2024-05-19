using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public int highscore;
    public int night;

    public PlayerData() 
    {
        if (highscore < CustomNightMenu.FinalScore)
        {
            highscore = CustomNightMenu.FinalScore;
        }
        night = AIscript1.Night;
    }

}
