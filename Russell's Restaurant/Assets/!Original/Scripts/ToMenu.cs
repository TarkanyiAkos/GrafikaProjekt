using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{

    public GameObject GameOver;
    public GameObject TurnMeOn1;
    public GameObject TurnMeOn2;
    public GameObject TurnMeOn3;
    public GameObject TurnMeOn4;

    public GameObject TurnMeOff1;
    public GameObject TurnMeOff2;

    public void Start()
    {
        GameOver.SetActive(false);
    }
    public void ToMenuF()
    {
        GameOver.SetActive(true);
        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        AIScript2.Unmask = false;
    }

    public void Win()
    {
        TurnMeOff1.SetActive(false);
        TurnMeOff2.SetActive(false);
        TurnMeOn1.SetActive(true);
        TurnMeOn2.SetActive(true);
        TurnMeOn3.SetActive(true);
        TurnMeOn4.SetActive(true);
        if (AIscript1.Mode != 3 && AIscript1.Night < 5)
        {
            AIscript1.Night++;
        }
    }

    public void ToMenuB()
    {
        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        AIScript2.Unmask = false;

    }
   
}
