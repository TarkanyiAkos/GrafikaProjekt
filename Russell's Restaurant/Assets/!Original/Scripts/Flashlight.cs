using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Flashlight : MonoBehaviour
{
    public Light FlashLight;
    public Material Cam1;
    public Material Cam2;
    public Material Cam3;
    public Material Cam4;
    public Material Cam5;
    public Material Cam6;
    public Material OffScreen;
    public GameObject Monitor;
    public static int id = 1;
    public Light C1;
    public Light C2;
    public Light C3;
    public Light C4;
    public Light C5;
    public Light C6;
    public static int IsOn = 30;
    public AudioSource camSwitch;
    public AudioSource comp;
    float FTime = 0f;
    public AudioSource DeskHit;
    public static float Power = 100f;
    public static float Usage = 2f;
    //cameraUsage
    public static bool temp1 = false;
    public static bool temp2 = false;
    public static bool temp3 = false;
    public static bool temp4 = false;
    public static bool temp5 = false;
    public static bool temp6 = false;
    //PowerDisplay
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public Material P_On;
    public Material P_Off;
    //Decoys
    public AudioSource d1;
    public AudioSource d2;
    public AudioSource d3;
    public AudioSource d4;
    public AudioSource d5;
    public AudioSource d6;
    public AudioSource FlashlightClick;
    public static int DecoyId = 0;
    public Light PCBGlow;
    public GameObject PCB;
    public Material Glass;
    public Material PCBColor;

    public GameObject CameraItem1;
    public GameObject CameraItem2;
    public GameObject CameraItem3;
    public GameObject CameraItem4;
    public GameObject CameraItem5;
    public GameObject CameraItem6;

    public GameObject GreenLamp;


    public void Start()
    {
        Power = 100f;
    }
    public void FixedUpdate()
    {
        FTime++;
        if (FTime == 50f)
        {
            FTime = 0F;
            //1 sec tick rate
            if (IsOn > 0)
            {
                IsOn--;
            }
            else if(IsOn == 0)
            {
                Monitor.GetComponent<MeshRenderer>().material = OffScreen;
                PCB.GetComponent<MeshRenderer>().material = Glass;
                PCBGlow.enabled = false;
                comp.Stop();
                Usage--;
                IsOn = -1;
                GreenLamp.SetActive(false);
            }
            //drain power
            if (Power > 0)
            {
                Power -= Usage / 10;
            }
            
            

        }
    }

    void turnOffExcept(int camID)
    {
        CameraItem1.SetActive(true);
        CameraItem2.SetActive(true);
        CameraItem3.SetActive(true);
        CameraItem4.SetActive(true);
        CameraItem5.SetActive(true);
        CameraItem6.SetActive(true);
        if (camID != 1)
        {
            if (C1.enabled)
            {
                C1.enabled = false;
                Usage--;
            }
            CameraItem1.SetActive(false);
        }
        if (camID != 2)
        {
            if (C2.enabled)
            {
                C2.enabled = false;
                Usage--;
            }
            CameraItem2.SetActive(false);
        }
        if (camID != 3)
        {
            if (C3.enabled)
            {
                C3.enabled = false;
                Usage--;
            }
            CameraItem3.SetActive(false);
        }
        if (camID != 4)
        {
            if (C4.enabled)
            {
                C4.enabled = false;
                Usage--;
            }
            CameraItem4.SetActive(false);
        }
        if (camID != 5)
        {
            if (C5.enabled)
            {
                C5.enabled = false;
                Usage--;
            }
            CameraItem5.SetActive(false);
        }
        if (camID != 6)
        {
            if (C6.enabled)
            {
                C6.enabled = false;
                Usage--;
            }
            CameraItem6.SetActive(false);
        }
    }


    public void Update()
    {
        //Q: Prev. Camera.*
        //W: Camera Light. (usage 0-6)*
        //E: Next Camera.*
        //A: Hit desk. (sound)
        //S: Shut down/activate pc (usage 0-1, takes 1 second) 
        //D: Camera decoy. (sound, use 1% power, 30s cooldown for each camera)*
        //Right-Click: Flashlight. (usage 0-1)
        //ESC: return to main menu.
        //SPACE: Mask
        if (Power > 80)
        {
            p1.GetComponent<MeshRenderer>().material = P_On;
        }
        else
        {
            p1.GetComponent<MeshRenderer>().material = P_Off;
        }
        if (Power > 60)
        {
            p2.GetComponent<MeshRenderer>().material = P_On;
        }
        else
        {
            p2.GetComponent<MeshRenderer>().material = P_Off;
        }
        if (Power > 40)
        {
            p3.GetComponent<MeshRenderer>().material = P_On;
        }
        else
        {
            p3.GetComponent<MeshRenderer>().material = P_Off;
        }
        if (Power > 20)
        {
            p4.GetComponent<MeshRenderer>().material = P_On;
        }
        else
        {
            p4.GetComponent<MeshRenderer>().material = P_Off;
        }
        if (Power > 0)
        {
            p5.GetComponent<MeshRenderer>().material = P_On;
        }
        else
        {
            p5.GetComponent<MeshRenderer>().material = P_Off;
            IsOn = 0;
            C1.enabled = false;
            C2.enabled = false;
            C3.enabled = false;
            C4.enabled = false;
            C5.enabled = false;
            C6.enabled = false;
            d1.Stop();
            d2.Stop();
            d3.Stop();
            d4.Stop();
            d5.Stop();
            d6.Stop();
            FlashLight.enabled = false;
            GreenLamp.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Hit
            DeskHit.PlayDelayed(0.1f);
            AIScript2.deskHit = true;
            DecoyId = 0;
            AIScript2.RusselCalm = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //PC On/Off
            if (IsOn == -1 && Power > 0)
            {
                comp.Play(0);
                IsOn = 30;
                Monitor.GetComponent<MeshRenderer>().material = Cam1;
                PCB.GetComponent<MeshRenderer>().material = PCBColor;
                PCBGlow.enabled = true;
                turnOffExcept(1);
                id = 1;
                Usage++;
                GreenLamp.SetActive(true);
            }
            else if (Power > 0)
            {
                IsOn = 0;
                Monitor.GetComponent<MeshRenderer>().material = OffScreen;
                PCB.GetComponent<MeshRenderer>().material = Glass;
                PCBGlow.enabled = false;
                comp.Stop();
                GreenLamp.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && IsOn > 0 && Power > 0)
        {
            //Decoy
            DecoyId = id;
            AIScript2.RusselCalm = false;
            if (id == 1)
            {
                d2.Stop();
                d3.Stop();
                d4.Stop();
                d5.Stop();
                d6.Stop();
                d1.Play();
            }
            if (id == 2)
            {
                d2.Play();
                d1.Stop();
                d3.Stop();
                d4.Stop();
                d5.Stop();
                d6.Stop();
            }
            if (id == 3)
            {
                d3.Play();
                d2.Stop();
                d1.Stop();
                d4.Stop();
                d5.Stop();
                d6.Stop();
            }
            if (id == 4)
            {
                d4.Play();
                d2.Stop();
                d3.Stop();
                d1.Stop();
                d5.Stop();
                d6.Stop();
            }
            if (id == 5)
            {
                d5.Play();
                d2.Stop();
                d3.Stop();
                d4.Stop();
                d1.Stop();
                d6.Stop();
            }
            if (id == 6)
            {
                d6.Play();
                d2.Stop();
                d3.Stop();
                d4.Stop();
                d5.Stop();
                d1.Stop();
            }
            Power -= 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        if (Input.GetMouseButtonDown(1) && Power > 0)
        {
            FlashLight.enabled = true;
            Usage++;
            FlashlightClick.Play();
        }
        if (Input.GetMouseButtonUp(1) && Power > 0)
        {
            FlashLight.enabled = false;
            Usage--;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1) && IsOn > 0)
        {
            turnOffExcept(1);
            Monitor.GetComponent<MeshRenderer>().material = Cam1;
            id = 1;
            camSwitch.Play(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) && IsOn > 0)
        {
            turnOffExcept(2);
            Monitor.GetComponent<MeshRenderer>().material = Cam2;
            id = 2;
            camSwitch.Play(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) && IsOn > 0)
        {
            turnOffExcept(3);
            Monitor.GetComponent<MeshRenderer>().material = Cam3;
            id = 3;
            camSwitch.Play(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) && IsOn > 0)
        {
            turnOffExcept(4);
            Monitor.GetComponent<MeshRenderer>().material = Cam4;
            id = 4;
            camSwitch.Play(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5) && IsOn > 0)
        {
            turnOffExcept(5);
            Monitor.GetComponent<MeshRenderer>().material = Cam5;
            id = 5;
            camSwitch.Play(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6) && IsOn > 0)
        {
            turnOffExcept(6);
            Monitor.GetComponent<MeshRenderer>().material = Cam6;
            id = 6;
            camSwitch.Play(0);
        }
        //array
        //-1
        if (Input.GetKeyDown(KeyCode.Q) && IsOn > 0)
        {
            if (id != 1)
            {
                camSwitch.Play(0);
            }
            if (id == 2)
            {
                Monitor.GetComponent<MeshRenderer>().material = Cam1;
                id -= 1;
                turnOffExcept(1);
            }
            if (id == 3)
            {
                Monitor.GetComponent<MeshRenderer>().material = Cam2;
                id -= 1;
                turnOffExcept(2);
            }
            if (id == 4)
            {
                Monitor.GetComponent<MeshRenderer>().material = Cam3;
                id -= 1;
                turnOffExcept(3);
            }
            if (id == 5)
            {
                Monitor.GetComponent<MeshRenderer>().material = Cam4;
                id -= 1;
                turnOffExcept(4);
            }
            if (id == 6)
            {
                Monitor.GetComponent<MeshRenderer>().material = Cam5;
                id -= 1;
                turnOffExcept(5);
            }
        }

        
        //+1
        if (Input.GetKeyDown(KeyCode.E) && IsOn > 0)
        {
            if (id != 6)
            {
                camSwitch.Play(0);
            }
            if (id == 5)
            {
                Monitor.GetComponent<MeshRenderer>().material = Cam6;
                id += 1;
                turnOffExcept(6);
            }
            if (id == 4)
            {
                Monitor.GetComponent<MeshRenderer>().material = Cam5;
                id += 1;
                turnOffExcept(5);
            }
            if (id == 3)
            {
                Monitor.GetComponent<MeshRenderer>().material = Cam4;
                id += 1;
                turnOffExcept(4);
            }
            if (id == 2)
            {
                Monitor.GetComponent<MeshRenderer>().material = Cam3;
                id += 1;
                turnOffExcept(3);
            }
            if (id == 1)
            {
                Monitor.GetComponent<MeshRenderer>().material = Cam2;
                id += 1;
                turnOffExcept(2);
            }
        }
        //array END
        //Cam Lightning
        if (Input.GetKeyDown(KeyCode.W) && IsOn > 0 && Power > 0)
        {
            if (id == 1)
            {
                C1.enabled = !C1.enabled;
                temp1 = !temp1;
                if (temp1 == true)
                {
                    Usage++;
                }
                else
                {
                    Usage--;
                }
            }
            if (id == 2)
            {
                C2.enabled = !C2.enabled;
                temp2 = !temp2;
                if (temp2 == true)
                {
                    Usage++;
                }
                else
                {
                    Usage--;
                }
            }
            if (id == 3)
            {
                C3.enabled = !C3.enabled;
                temp3 = !temp3;
                if (temp3 == true)
                {
                    Usage++;
                }
                else
                {
                    Usage--;
                }
            }
            if (id == 5)
            {
                C5.enabled = !C5.enabled;
                temp5 = !temp5;
                if (temp5 == true)
                {
                    Usage++;
                }
                else
                {
                    Usage--;
                }
            }
            if (id == 6)
            {
                C6.enabled = !C6.enabled;
                temp6 = !temp6;
                if (temp6 == true)
                {
                    Usage++;
                }
                else
                {
                    Usage--;
                }
            }
            if (id == 4)
            {
                C4.enabled = !C4.enabled;
                temp4 = !temp4;
                if (temp4 == true)
                {
                    Usage++;
                }
                else
                {
                    Usage--;
                }
            }
        }

    }
    public void LightOff()
    {
        FlashLight.enabled = false;
    }
}
