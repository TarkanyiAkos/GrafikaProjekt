using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;

public class AIScript2 : MonoBehaviour
{
    int Timer = 0;
    public GameObject Ben;
    public GameObject Dave;
    public GameObject Garry;
    public GameObject Happy;
    public GameObject Jeremy;
    public GameObject Keira;
    public GameObject Otto;
    public GameObject Russell;
    public GameObject Tina;
    public GameObject Wendy;
    public GameObject Billy;
    public Camera pc; //Player camera
    public GameObject Character; //FP AIO character
    public Light fl; //flashlight
    public Collider BenC; //used in BenAI
    public Collider Benc2; //used in BenAI
    public Plane[] planes; //used to detect player FoV.
    public float BenDistance; //used in BenAI to measure distance from pc.
    bool ftBen = true; //used to set Ben's first animation
    public Animator BenAnimator; //Used to controll Ben's overall animation.
    public AudioSource BenS1;
    public AudioSource BenS2;
    public AudioSource BenS3;
    public Animator RedPanel;
    public static bool Unmask = false;
    public Animator DaveAnimator;
    public Material DaveBase;
    public float DaveColor = 0;
    public float DaveCool = 0;
    public int GarryWait = 1000;
    public bool GarryStare = false;
    public Animator GarryAnimator;
    public Collider GarryC;
    public Animator HappyAnimator;
    public int HappyWait = 0;
    public bool HappyClap = false;
    public bool HappyS = false;
    public GameObject MonitorCube;
    public Material Static;
    int JeremyWait = 0;
    bool hack = false;
    public Material cam1;
    public Material cam2;
    public Material cam3;
    public Material cam4;
    public Material cam5;
    public Material cam6;
    public Material Black;
    public AudioSource hacksound;
    public AudioSource GarryOff;
    public AudioSource GarryOn;
    float Vent = 4f;
    float BillyWait = 0;
    public static bool deskHit = false;
    public GameObject Screw1;
    public GameObject Screw2;
    public GameObject Screw3;
    public GameObject Screw4;
    public GameObject VentO;
    public Animator KeiraAnimator;
    public AudioSource BillyScratch;
    public AudioSource VentFallDown;
    public AudioSource ScrewSound1;
    bool sc1 = false;
    bool sc2 = false;
    bool sc3 = false;
    public static int OttoLocation = 0;
    public NavMeshAgent OttoNav;
    public Animator OttoAnimator;
    public static bool RusselCalm = true;
    int DoorHP = 0;
    public Animator DoorAnimator;
    int RusselWait;
    public Light OfficeLight;
    public Light PCLight;
    float russelstay = 0;
    public Light Flash;
    public AudioSource OfficeLampSound;
    public NavMeshAgent RusselNav;
    public Animator RussellAnimator;
    bool ROff = false;
    int rtalk = 0;
    public AudioSource DoorHit;
    public AudioSource RCome;
    public AudioSource POffed;
    bool rcame = false;
    public Animator WinAnimation;
    public AudioSource WinMusic;
    bool TinaTarget = false;
    public NavMeshAgent TinaNav;
    public Collider TinaC;
    int TinaLocation = 0;
    public Animator TinaAnimator;
    int TinaW = 0;
    int WendyTimer = 0;
    public Collider WendyC;
    public Animator WendyAnimator;
    bool WendyHere = false;
    int Wdest = 0;
    public AudioSource WendySound;
    int temp = 0;

    private void Start()
    {
        DaveBase.SetColor("_Color", Color.green);
        TinaLocation = 0;
        Wdest = 0;
        TinaW = 0;
        WendyHere = false;
        WendyTimer = 0;
        TinaTarget = false;
        DaveBase.SetColor("_EmissionColor", Color.green);
        GarryStare = false;
        GarryWait = UnityEngine.Random.Range(500, 5000 - CustomNightMenu.GarryAI * 50);
        HappyWait = UnityEngine.Random.Range(2000 - 10 * CustomNightMenu.HappyAI, 3200 - 10 * CustomNightMenu.HappyAI);
        HappyClap = false;
        HappyS = false;
        JeremyWait = UnityEngine.Random.Range(700 - CustomNightMenu.JeremyAI * 5, 1000 - CustomNightMenu.JeremyAI * 5);
        hack = false;
        hacksound.enabled = false;
        Vent = 4f;
        deskHit = false;
        BillyWait = UnityEngine.Random.Range(600 - CustomNightMenu.KeiraAI * 10, 850 - CustomNightMenu.KeiraAI * 10);
        Billy.SetActive(false);
        sc1 = false;
        sc2 = false;
        sc3 = false;
        OttoLocation = 0;
        OttoNav.speed = CustomNightMenu.OttoAI/20;
        OttoNav.SetDestination(new Vector3(0, 1, 0));
        RusselCalm = true;
        DoorHP = (21 - CustomNightMenu.RussellAI) * 150;
        RusselWait = (21 - CustomNightMenu.RussellAI) * 250;
        russelstay = (CustomNightMenu.RussellAI + 10)/2*50;
        ROff = false;
        rtalk = 100;
        rcame = false;
        Timer = 0;
    }


    private void Update()
    {
        Character.transform.position = new Vector3(-0.5f,1.562f,0f);
        if (Flashlight.Power <=0)
        {
            OfficeLight.enabled = false;
            PCLight.enabled = false;
            OfficeLampSound.Stop();
        }
    }

    private void FixedUpdate()
    {
        //0,02 tick rate (elvileg)
        Timer++;
        Debug.Log(Timer);
        if (Timer == 15000)
        {
            Unmask = true;
            //Win
            WinAnimation.SetBool("won", true);
            //Hang effekt + kép: 5:59 AM --> 6:00 AM
            WinMusic.Play();
        }
        //Ben
        if (CustomNightMenu.BenAI >0)
        {
            //If not visible to the player, move him. If close enough, Jumpscare. If spotted, stop movement for a while. AI: + movement speed.
            if (Unmask == false)
            {
                pc = Camera.main;
                planes = GeometryUtility.CalculateFrustumPlanes(pc);
                if (GeometryUtility.TestPlanesAABB(planes, BenC.bounds) || GeometryUtility.TestPlanesAABB(planes, Benc2.bounds))
                    {
                    //BenSeen
                    //animate!!!!!
                    BenAnimator.SetFloat("step", 0f);
                    }
                else
                {
                    //BenUnseen
                    if (UnityEngine.Random.Range(0,4000) >= 4000 - CustomNightMenu.BenAI)
                        {
                        //move
                        Ben.transform.Translate(1, 0, 0);
                        BenDistance += 1;
                        if (ftBen == true)
                            {
                            Ben.transform.Translate(3f, 0.5f, -1.5f);
                            ftBen = false;
                            }
                        BenAnimator.SetFloat("step", 1f);
                        }

                }
                if (BenDistance > 15)
                {
                    //Jumpscare
                    Unmask = true;
                    GetComponent<FirstPersonAIO>().enabled = false;
                    //Rotate camera
                    pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    Character.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    Ben.transform.Translate(0, -1.4f, 0.15f);
                    BenAnimator.SetFloat("step", 0f);
                    BenAnimator.SetBool("jump", true);
                    BenS1.Play();
                    BenS2.Play();
                    BenS3.Play();
                    BenDistance = 0;
                    RedPanel.SetFloat("jump", 1f);
                }
            }
            
        }
        else
        {
            Ben.SetActive(false);
        }
        //Dave
        if (CustomNightMenu.DaveAI > 0)
        {
            //Re-do this one.
            //Sits in the service, Slowly turning red. (needs new materials, rgb value change via script) Using camera light can make him calmer ---> greener. When fully red, Jumpscare.
            if (Unmask == false)
            {
                //DaveColor +5/sec on AI level 20
                if (Flashlight.temp2 == false)
                {
                    DaveCool++;
                }
                else if (DaveColor > 0)
                {
                    DaveColor--;
                }
                if (DaveCool == 30-CustomNightMenu.DaveAI)
                {
                    DaveCool = 0;
                    DaveColor++;
                }
                DaveBase.SetColor("_Color", new Color(DaveColor / 100, 1 - DaveColor/100, 0));
                DaveBase.SetColor("_EmissionColor", new Color(DaveColor / 100, 1 - DaveColor / 100, 0));
                if (DaveColor == 100)
                {
                    //Jumpscare
                    Unmask = true;
                    GetComponent<FirstPersonAIO>().enabled = false;
                    //Rotate camera
                    pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    Character.transform.localRotation = Quaternion.Euler(0, 180, 0);
                    Dave.transform.position = new Vector3(-0.5f, 2f, -2f);
                    Dave.transform.Rotate(0, 90f, 0);
                    DaveAnimator.SetBool("jump", true);
                    BenS1.Play();
                    BenS2.Play();
                    BenS3.Play();
                    RedPanel.SetFloat("jump", 1f);
                }
            }
        }
        else
        {
            Dave.SetActive(false);
        }
        //Garry
        if (CustomNightMenu.GarryAI > 0)
        {
            //loop idle animation. Uppon random intervals, stare. If player looks at it, JS. 
            //Else: Deactivate after a while. AI: Longer active period. More Often activation.
            if (Unmask == false)
            {
                //wait random based on AI
                if (GarryWait > 0)
                {
                    GarryWait--;
                    
                }
                if (GarryWait == 0 && GarryStare == false)
                {
                    GarryStare = true;
                    GarryAnimator.SetInteger("state", 1);
                    GarryOn.Play();
                    GarryWait = UnityEngine.Random.Range(70, 50+CustomNightMenu.GarryAI * 25);
                }
                if (GarryWait == 0 && GarryStare == true)
                {
                    GarryAnimator.SetInteger("state", 2);
                    GarryStare = false;
                    GarryOff.Play();
                    GarryWait = UnityEngine.Random.Range(500,5000-CustomNightMenu.GarryAI*50);
                }
                if (GarryWait > 0 && GarryStare == true)
                {
                    //test if seen
                    pc = Camera.main;
                    planes = GeometryUtility.CalculateFrustumPlanes(pc);
                    if (GeometryUtility.TestPlanesAABB(planes, GarryC.bounds))
                    {
                        //Jumpscare
                        Unmask = true;
                        GarryAnimator.SetInteger("state", 3);
                        GetComponent<FirstPersonAIO>().enabled = false;
                        //Rotate camera
                        pc.transform.rotation = Quaternion.Euler(0, 0, 0);
                        Character.transform.rotation = Quaternion.Euler(0, 0, 0);
                        Garry.transform.Translate(2f, 0.5f, -1f);
                        pc.transform.rotation = Quaternion.Euler(0, 0, 0);
                        Garry.transform.Rotate(0, 90, 0);
                        pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        BenS1.Play();
                        BenS2.Play();
                        BenS3.Play();
                        Character.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        RedPanel.SetFloat("jump", 1f);
                    }
                }
            }
        }
        else
        {
            Garry.SetActive(false);
        }
        //Happy
        if (CustomNightMenu.HappyAI > 0)
        {
            //Every x second % chance to appear on an unseen stage, calpping animation. Look at him for Y seconds to deactivate, else JS. AI: lower x, increase y.
            if (Unmask == false)
            {
                if (HappyWait > 0)
                {
                    HappyWait--;
                }
                if (HappyWait == 0 && HappyClap == false)
                {
                    //Start clap
                    HappyS = false;
                    HappyWait = UnityEngine.Random.Range(400 + 12* CustomNightMenu.HappyAI, 700 + 12 * CustomNightMenu.HappyAI);
                    HappyAnimator.SetInteger("state", 1);
                    HappyClap = true;
                }
                if (HappyWait == 0 && HappyClap == true)
                {
                    //Stop Clap
                    if (HappyS == true)
                    {
                        HappyWait = UnityEngine.Random.Range(2000 - 10 * CustomNightMenu.HappyAI, 3200 - 10 * CustomNightMenu.HappyAI);
                        HappyAnimator.SetInteger("state", 2);
                        HappyClap = false;
                    }
                    else
                    {
                        //Jumpscare
                        Unmask = true;
                        HappyAnimator.SetInteger("state", 3);
                        GetComponent<FirstPersonAIO>().enabled = false;
                        //Rotate camera
                        pc.transform.rotation = Quaternion.Euler(0, 0, 0);
                        Character.transform.rotation = Quaternion.Euler(0, 0, 0);
                        Happy.transform.position = new Vector3(-0.5f, 2f, 2.5f);
                        Happy.transform.Rotate(0, -90f, 0);
                        BenS1.Play();
                        BenS2.Play();
                        BenS3.Play();
                        Character.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        RedPanel.SetFloat("jump", 1f);
                    }
                }
                if (HappyWait > 0 && HappyClap == true && Flashlight.id == 5 && Flashlight.IsOn > 0)
                {
                    HappyS = true;
                }
            }
        }
        else
        {
            Happy.SetActive(false);
        }
        //Jeremy
        if (CustomNightMenu.JeremyAI > 0)
        {
            
            if (Unmask == false)
            {
                if (JeremyWait > 0)
                {
                    JeremyWait--;
                }
                if (JeremyWait == 0 && hack == false)
                {
                    JeremyWait = UnityEngine.Random.Range(200+CustomNightMenu.JeremyAI*5, 400 + CustomNightMenu.JeremyAI * 5);
                    hack = true;
                    hacksound.Stop();
                    hacksound.Play();
                }
                if (hack == true && JeremyWait > 0)
                {
                    if (Flashlight.IsOn > 0)
                    {
                        MonitorCube.GetComponent<MeshRenderer>().material = Static;
                        hacksound.enabled = true;
                    }
                    else
                    {
                        hacksound.enabled = false;
                    }
                }
                if (JeremyWait == 0 && hack == true)
                {
                    hacksound.enabled = false; ;
                    JeremyWait = UnityEngine.Random.Range(700 - CustomNightMenu.JeremyAI * 5, 1000 - CustomNightMenu.JeremyAI * 5);
                    hack = false;
                    if (Flashlight.IsOn > 0)
                    {
                        if (Flashlight.id == 1)
                        {
                            MonitorCube.GetComponent<MeshRenderer>().material = cam1;
                        }
                        if (Flashlight.id == 2)
                        {
                            MonitorCube.GetComponent<MeshRenderer>().material = cam2;
                        }
                        if (Flashlight.id == 3)
                        {
                            MonitorCube.GetComponent<MeshRenderer>().material = cam3;
                        }
                        if (Flashlight.id == 4)
                        {
                            MonitorCube.GetComponent<MeshRenderer>().material = cam4;
                        }
                        if (Flashlight.id == 5)
                        {
                            MonitorCube.GetComponent<MeshRenderer>().material = cam5;
                        }
                        if (Flashlight.id == 6)
                        {
                            MonitorCube.GetComponent<MeshRenderer>().material = cam6;
                        }

                    }
                    else
                    {
                        MonitorCube.GetComponent<MeshRenderer>().material = Black;
                    }
                    

                }
            }
        }
        else
        {
            Jeremy.SetActive(false);
        }
        //Keira & Billy
        if (CustomNightMenu.KeiraAI > 0)
        {
            //every x seconds %chance to start screwing. Press A to hit desk. After 25-AI seconds Keira appears. 
            //If mask is not worn for a second, JS. AI: decrease x.
            if (Unmask == false)
            {
                if (Vent > 0)
                {
                    //Billy
                    Keira.SetActive(false);
                    if (BillyWait > 0)
                    {
                        BillyWait--;
                    }
                    if (BillyWait == 0)
                    {
                        Vent -= CustomNightMenu.KeiraAI/1000f;
                        Billy.SetActive(true);
                        if (BillyScratch.isPlaying == false)
                        {
                            BillyScratch.Play(1);
                        }
                        
                    }
                    if (deskHit == true)
                    {
                        deskHit = false;
                        BillyWait = UnityEngine.Random.Range(600 - CustomNightMenu.KeiraAI*10, 850 - CustomNightMenu.KeiraAI*10);
                        Billy.SetActive(false);
                        BillyScratch.Stop();
                    }
                    if (Vent > 3)
                    {
                        Screw4.SetActive(true);
                    }
                    else
                    {
                        Screw4.SetActive(false);
                    }
                    if (Vent > 2)
                    {
                        Screw3.SetActive(true);
                    }
                    else
                    {
                        Screw3.SetActive(false);
                    }
                    if (Vent > 1)
                    {
                        Screw2.SetActive(true);
                    }
                    else
                    {
                        Screw2.SetActive(false);
                    }
                    if (sc1 == false && Vent < 3)
                    {
                        ScrewSound1.Play(10000);
                        sc1 = true;
                    }
                    if (sc2 == false && Vent < 2)
                    {
                        ScrewSound1.Play(10000);
                        sc2 = true;
                    }
                    if (sc3 == false && Vent < 1)
                    {
                        ScrewSound1.Play(10000);
                        sc3 = true;
                    }
                    Screw1.SetActive(true);
                    if (Vent <= 0)
                    {
                        //Vent fall down
                        Screw1.SetActive(false);
                        Billy.SetActive(false);
                        ScrewSound1.Play(10000);
                        VentO.AddComponent<Rigidbody>();
                        BillyWait = UnityEngine.Random.Range(1000 - CustomNightMenu.KeiraAI * 10, 1250 - CustomNightMenu.KeiraAI * 10);
                        BillyScratch.Stop();
                        VentFallDown.Play(15000);
                    }
                }
                else
                {
                    //Keira
                    if (BillyWait > 0)
                    {
                        BillyWait--;
                    }
                    else
                    {
                        Keira.SetActive(true);
                        //check mask
                        if (Mask.Masked == false)
                        {
                            //Jumpscare
                            Unmask = true;
                            GetComponent<FirstPersonAIO>().enabled = false;
                            //Rotate camera
                            pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                            Character.transform.localRotation = Quaternion.Euler(0, 235, 0);
                            Keira.transform.position = new Vector3(-2.5f, 2.8f, -1.5f);
                            Keira.transform.Rotate(0, -45f, 0);
                            KeiraAnimator.SetBool("jump", true);
                            BenS1.Play();
                            BenS2.Play();
                            BenS3.Play();
                            RedPanel.SetFloat("jump", 1f);
                        }
                    }
                    
                }
            }
            
        }
        else
        {
            Keira.SetActive(false);
            Billy.SetActive(false);
        }
        //Otto
        if (CustomNightMenu.OttoAI > 0)
        {
            //variable based on sound location. Move based on this var. In office: JS. AI: faster movement. 
            if (Unmask == false)
            {
                if (Flashlight.DecoyId == 1)
                {
                    OttoNav.SetDestination(new Vector3(6, 1, -7f));
                    if (Otto.transform.position.x == 6 && Otto.transform.position.z == -7)
                    {
                        Flashlight.DecoyId = 0;
                        OttoNav.SetDestination(new Vector3(0, 1, 0));
                    }
                }
                if (Flashlight.DecoyId == 2)
                {
                    OttoNav.SetDestination(new Vector3(-9.5f, 1, -4.5f));
                    if (Otto.transform.position.x == -9.5f && Otto.transform.position.z == -4.5f)
                    {
                        Flashlight.DecoyId = 0;
                        OttoNav.SetDestination(new Vector3(0, 1, 0));
                    }
                }
                if (Flashlight.DecoyId == 3)
                {
                    OttoNav.SetDestination(new Vector3(-18f, 1, 20f));
                    if (Otto.transform.position.x == -18f && Otto.transform.position.z == 20f)
                    {
                        Flashlight.DecoyId = 0;
                        OttoNav.SetDestination(new Vector3(0, 1, 0));
                    }
                }
                if (Flashlight.DecoyId == 4)
                {
                    OttoNav.SetDestination(new Vector3(-23f, 1, 7));
                    if (Otto.transform.position.x == -23f && Otto.transform.position.z == 7f)
                    {
                        Flashlight.DecoyId = 0;
                        OttoNav.SetDestination(new Vector3(0, 1, 0));
                    }
                }
                if (Flashlight.DecoyId == 5)
                {
                    OttoNav.SetDestination(new Vector3(-32f, 1, -10f));
                    if (Otto.transform.position.x == -32f && Otto.transform.position.z == -10f)
                    {
                        Flashlight.DecoyId = 0;
                        OttoNav.SetDestination(new Vector3(0, 1, 0));
                    }
                }
                if (Flashlight.DecoyId == 6)
                {
                    OttoNav.SetDestination(new Vector3(3, 1, 12.5f));
                    if (Otto.transform.position.x == 3f && Otto.transform.position.z == 12.5f)
                    {
                        Flashlight.DecoyId = 0;
                        OttoNav.SetDestination(new Vector3(0, 1, 0));
                    }
                }
                if (Flashlight.DecoyId == 0)
                {
                    OttoNav.SetDestination(new Vector3(0, 1, 0));
                }
                if (Otto.transform.position.z < 4 && Otto.transform.position.x > -1 && Otto.transform.position.z > 3 && Otto.transform.position.x < 0)
                {
                    OttoLocation = 2;
                }
                if (Otto.transform.position.z < -3 && Otto.transform.position.x > -1 && Otto.transform.position.z > -4 && Otto.transform.position.x < 0)
                {
                    OttoLocation = 1;
                }
                if (OttoLocation == 1)
                {
                    //JumpscareLeft
                    Unmask = true;
                    OttoNav.SetDestination(new Vector3(Otto.transform.position.x, Otto.transform.position.y, Otto.transform.position.z));
                    OttoNav.SetDestination(new Vector3(-0.5f,1,0));
                    OttoNav.speed = 2;
                    GetComponent<FirstPersonAIO>().enabled = false;
                    //Rotate camera
                    pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    Character.transform.localRotation = Quaternion.Euler(0, 180, 0);
                    OttoAnimator.SetBool("jump", true);
                    BenS1.Play();
                    BenS2.Play();
                    BenS3.Play();
                    RedPanel.SetFloat("jump", 1f);
                }
                if (OttoLocation == 2)
                {
                    //JumpscareRight
                    Unmask = true;
                    OttoNav.SetDestination(new Vector3(Otto.transform.position.x, Otto.transform.position.y, Otto.transform.position.z));
                    OttoNav.SetDestination(new Vector3(-0.5f, 1, 0));
                    OttoNav.speed = 2;
                    GetComponent<FirstPersonAIO>().enabled = false;
                    //Rotate camera
                    pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    Character.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    OttoAnimator.SetBool("jump", true);
                    BenS1.Play();
                    BenS2.Play();
                    BenS3.Play();
                    RedPanel.SetFloat("jump", 1f);
                }
            }
        }
        else
        {
            Otto.SetActive(false);
        }
        //Russell
        if (CustomNightMenu.RussellAI > 0)
        {
            //When russel attacks, the lights in the office will turn off, and your flashlight will start to blink, and your computer will turn off. 
            //Put on the mask, and don't move. If your lucky, (100-AI %) he will leave you alone. He needs 100-3*AI seconds to break the door, 
            //during witch time he wont attack. He starts breaking the door after the first sound effect. (desk hitting, decoy, etc...) Only comes once per night.
            //He hates light. After the door has been broken, you can lower the chance of him attacking with using your flashlight on his doorway.
            if (Unmask == false && ROff == false)
            {
                if (RusselCalm == false)
                {
                    if (DoorHP > 0)
                    {
                        DoorHP--;
                        if (DoorHit.isPlaying == false)
                        {
                            DoorHit.Play();
                        }
                        if (DoorHP == 0)
                        {
                            DoorAnimator.SetBool("door", true);
                            DoorHit.Stop();
                        }
                    }
                    else
                    {
                        //DoorBroken
                        if (RusselWait > 0)
                        {
                            RusselWait--;
                        }
                        else
                        {
                            RussellAnimator.SetBool("walk",true);
                            Flashlight.IsOn = 0;
                            if (rcame == false)
                            {
                                rcame = true;
                                RCome.Play();
                            }
                            RusselNav.SetDestination(new Vector3(-0.5f,1,-18.5f));
                            OfficeLight.enabled = false;
                            PCLight.enabled = false;
                            OfficeLampSound.Stop();
                            if (russelstay > 0 && Flash.enabled == false)
                            {
                                russelstay--;
                                Flashlight.IsOn = 0;
                                if (RusselNav.pathStatus == NavMeshPathStatus.PathComplete && RusselNav.remainingDistance == 0)
                                {
                                    //Arrived Outside
                                    RussellAnimator.SetBool("walk", false);
                                }
                                if (russelstay == 0)
                                {
                                    RussellAnimator.SetBool("walk", true);
                                    RusselNav.SetDestination(new Vector3(4.5f, 1, -17f));
                                    OfficeLight.enabled = true;
                                    PCLight.enabled = true;
                                    OfficeLampSound.Play();
                                    ROff = true;
                                }
                            }
                            else
                            {
                                //TODO: Say: time to turn the lights off
                                OfficeLight.enabled = false;
                                PCLight.enabled = false;
                                OfficeLampSound.Stop();
                                RussellAnimator.SetBool("come", true);
                                Flashlight.Power = 0;
                                POffed.Play();
                                //Wait 2 s
                                if (rtalk > 0)
                                {
                                    rtalk--;
                                }
                                else
                                {
                                    //Go back
                                    RussellAnimator.SetBool("walk", true);
                                    RusselNav.SetDestination(new Vector3(4.5f, 1, -17f));
                                    ROff = true;

                                }
                                
                            }
                        }
                    }
                }
                
                
            }
        }
        else
        {
            Russell.SetActive(false);
        }
        //Tina
        if (CustomNightMenu.TinaAI > 0)
        {
            //appoach the office, walk through some cameras, play music on left/right, use mask and face the appropriate dir. AI: faster movement, 
            //shorter reaction time for player.
            if (Unmask == false)
            {
                if (TinaTarget == false)
                {
                    TinaTarget = true;
                    TinaW++;
                    TinaNav.SetDestination(new Vector3(UnityEngine.Random.Range(-35f, 2),1, UnityEngine.Random.Range(-23f, 40)));
                }
                if (TinaW == 25 - CustomNightMenu.TinaAI)
                {
                    TinaW = 0;
                    TinaNav.SetDestination(new Vector3(0.5f, 1, 0));
                }
                else if(TinaNav.pathStatus == NavMeshPathStatus.PathComplete && TinaNav.remainingDistance == 0)
                {
                    //Reached
                    TinaTarget = false;
                }
                if (Mask.Masked == true)
                {
                    pc = Camera.main;
                    planes = GeometryUtility.CalculateFrustumPlanes(pc);
                    if (GeometryUtility.TestPlanesAABB(planes, TinaC.bounds))
                    {
                        //GoAway
                        TinaTarget = true;
                        TinaW = 0;
                        TinaNav.SetDestination(new Vector3(UnityEngine.Random.Range(-35f, -5f), 1, UnityEngine.Random.Range(-23f, 40)));
                    }
                }

                if (Tina.transform.position.z < 4 && Tina.transform.position.x > -1 && Tina.transform.position.z > 3 && Tina.transform.position.x < 0)
                {
                    TinaLocation = 2;
                }
                if (Tina.transform.position.z < -3 && Tina.transform.position.x > -1 && Tina.transform.position.z > -4 && Tina.transform.position.x < 0)
                {
                    TinaLocation = 1;
                }
                if (TinaLocation == 1)
                {
                    //JumpscareLeft
                    Unmask = true;
                    TinaNav.SetDestination(new Vector3(Tina.transform.position.x, Tina.transform.position.y, Tina.transform.position.z));
                    TinaNav.SetDestination(new Vector3(-0.25f, 1, 0));
                    TinaNav.speed = 1;
                    GetComponent<FirstPersonAIO>().enabled = false;
                    //Rotate camera
                    pc.transform.rotation = Quaternion.Euler(0, 180, 0);
                    Character.transform.rotation = Quaternion.Euler(0, 180, 0);
                    TinaAnimator.SetBool("jump", true);
                    BenS1.Play();
                    BenS2.Play();
                    BenS3.Play();
                    RedPanel.SetFloat("jump", 1f);
                }
                if (TinaLocation == 2)
                {
                    //JumpscareRight
                    Unmask = true;
                    TinaNav.SetDestination(new Vector3(Tina.transform.position.x, Tina.transform.position.y, Tina.transform.position.z));
                    TinaNav.SetDestination(new Vector3(-0.25f, 1, 0));
                    TinaNav.speed = 1;
                    GetComponent<FirstPersonAIO>().enabled = false;
                    //Rotate camera
                    pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    Character.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    TinaAnimator.SetBool("jump", true);
                    BenS1.Play();
                    BenS2.Play();
                    BenS3.Play();
                    RedPanel.SetFloat("jump", 1f);
                }
            }
        }
        else
        {
            Tina.SetActive(false);
        }
        //Wendy
        if (CustomNightMenu.WendyAI > 0)
        {
            //every 3 seconds there is X chance to appear on left/right/back. If flashed uppon, she will flee. AI: x = AI. 
            //(AI level 20: avarage appearance: every 15s. thats like 20 times during the night)
            if (Unmask == false)
            {
                WendyTimer++;
                pc = Camera.main;
                planes = GeometryUtility.CalculateFrustumPlanes(pc);
                if (GeometryUtility.TestPlanesAABB(planes, WendyC.bounds) && Flash.enabled == true)
                {
                    //GoAway
                    WendyAnimator.SetInteger("look", 0);
                    Invoke("WendyGoesBack", 1);
                }
                if (WendyTimer == 150)
                {
                    WendyTimer = 0;
                    if (UnityEngine.Random.Range(1,100) < CustomNightMenu.WendyAI && Flashlight.id != 4)
                    {
                        if (WendyHere == false)
                        {
                            WendyHere = true;
                            //Appear
                            Wdest = UnityEngine.Random.Range(1, 4);
                            if (Wdest == 4)
                            {
                                Wdest = 3;
                            }
                            if (Wdest == 1)
                            {
                                //left
                                Wendy.transform.position = new Vector3(-2.5f, 3, -17f);
                                WendyAnimator.SetInteger("look", 1);
                                Wendy.transform.rotation = Quaternion.Euler(0,-90f,0);

                            }
                            if (Wdest == 2)
                            {
                                //right
                                Wendy.transform.position = new Vector3(-2.5f, 3, 12);
                                WendyAnimator.SetInteger("look", 2);
                                Wendy.transform.rotation = Quaternion.Euler(0, 90, 0);
                            }
                            if (Wdest == 3)
                            {
                                //back
                                Wendy.transform.position = new Vector3(15.5f, 3, 4);
                                WendyAnimator.SetInteger("look", 2);
                                Wendy.transform.rotation = Quaternion.Euler(0, 180, 0);
                            }
                            WendySound.Play();
                        }
                        else
                        {
                            //Jumpscare
                            if (Wdest == 1)
                            {
                                Unmask = true;
                                GetComponent<FirstPersonAIO>().enabled = false;
                                //Rotate camera
                                pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                                Character.transform.localRotation = Quaternion.Euler(0, 180, 0);
                                Wendy.transform.position = new Vector3(-0.5f, 3, -3);
                                WendyAnimator.SetBool("jump", true);
                                BenS1.Play();
                                BenS2.Play();
                                BenS3.Play();
                                RedPanel.SetFloat("jump", 1f);
                            }
                            if (Wdest == 2)
                            {
                                Unmask = true;
                                GetComponent<FirstPersonAIO>().enabled = false;
                                //Rotate camera
                                pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                                Character.transform.localRotation = Quaternion.Euler(0, 0, 0);
                                Wendy.transform.position = new Vector3(-0.5f, 3, 3);
                                WendyAnimator.SetBool("jump", true);
                                BenS1.Play();
                                BenS2.Play();
                                BenS3.Play();
                                RedPanel.SetFloat("jump", 1f);
                            }
                            if (Wdest == 3)
                            {
                                Unmask = true;
                                GetComponent<FirstPersonAIO>().enabled = false;
                                //Rotate camera
                                pc.transform.localRotation = Quaternion.Euler(0, 0, 0);
                                Character.transform.localRotation = Quaternion.Euler(0, 90, 0);
                                Wendy.transform.position = new Vector3(3f,3,0);
                                WendyAnimator.SetBool("jump", true);
                                BenS1.Play();
                                BenS2.Play();
                                BenS3.Play();
                                RedPanel.SetFloat("jump", 1f);
                            }
                        }
                        
                    }
                }
            }
            
        }
        else
        {
            Wendy.SetActive(false);
        }

    }

    public void WendyGoesBack ()
    {
        Wendy.transform.position = new Vector3(-4.676907f, 3.56f, 7.956243f);
        Wendy.transform.rotation = Quaternion.Euler(0, 180, 0);
        WendyHere = false;
    }
    

    
}
