using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AIscript1 : MonoBehaviour
{
    public static int Mode = 0;
    public static int Night = 1;
    public Text contValue;
    public void Night_LOAD(int modeID)
    {
        Mode = modeID;
        if (modeID == 1)
        {
            CustomNightMenu.BenAI = 2;
            CustomNightMenu.DaveAI = 2;
            CustomNightMenu.GarryAI = 1;
            CustomNightMenu.HappyAI = 1;
            CustomNightMenu.JeremyAI = 2;
            CustomNightMenu.OttoAI = 1;
            CustomNightMenu.KeiraAI = 1;
            CustomNightMenu.TinaAI = 1;
            CustomNightMenu.RussellAI = 0;
        }
        if (modeID == 2)
        {
            
                CustomNightMenu.BenAI = Random.Range(0,20);
                CustomNightMenu.DaveAI = Random.Range(0, 20);
                CustomNightMenu.GarryAI = Random.Range(0, 20);
                CustomNightMenu.HappyAI = Random.Range(0, 20);
                CustomNightMenu.JeremyAI = Random.Range(0, 20);
                CustomNightMenu.OttoAI = Random.Range(0, 20);
                CustomNightMenu.KeiraAI = Random.Range(0, 20);
                CustomNightMenu.TinaAI = Random.Range(0, 20);
                CustomNightMenu.RussellAI = Random.Range(0, 20);
            
        }
        SceneManager.LoadScene("Russell's Restaurant", 0);
    }




}
