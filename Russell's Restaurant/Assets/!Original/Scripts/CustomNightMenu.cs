using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomNightMenu : MonoBehaviour
{
    public RawImage RawI;
    public Texture TexI1;
    public Texture TexI2;
    public Texture TexI3;
    public Texture TexI4;
    public Texture TexI5;
    public Texture TexI6;
    public Texture TexI7;
    public Texture TexI8;
    public Texture TexI9;
    public Texture TexI10;
    public float page = 1;
    public Text INH;
    public Text IRH;
    public Text ISH;
    public Text IENH;
    public Text AInumber;
    public Text Pagenumber;
    public static int BenAI = 0;
    public static int DaveAI = 0;
    public static int GarryAI = 0;
    public static int HappyAI = 0;
    public static int JeremyAI = 0;
    public static int KeiraAI = 0;
    public static int OttoAI = 0;
    public static int RussellAI = 0;
    public static int TinaAI = 0;
    public static int WendyAI = 0;
    public Text Pointnumber;
    public float pointvalue;
    public Animator evileyes;
    public static int FinalScore = 0;
    public Text HighScore;

    private void Start()
    {
        if (Random.Range(1f,20f) > 19f)
        {
            evileyes.SetBool("ee",true);
        }
        HighScore.text = " ";
    }

    public void PrevPress()
    {
        if (page > 1)
        {
            page--;
            Pagenumber.text = "Page " + page + "/10";
            if (page == 1)
            {

                RawI.texture = TexI1;
                INH.text = "Ben";
                IRH.text = "Gorilla";
                ISH.text = "Stable";
                IENH.text = "Ben sits behind you. He will slowly approach you while you are distracted. Keep an eye on him in order to avoid a fatal meeting.";
                AInumber.text = BenAI.ToString();
            }
            if (page == 2)
            {
                
                RawI.texture = TexI2;
                INH.text = "Dave";
                IRH.text = "Chameleon";
                ISH.text = "Stable";
                IENH.text = "Dave sits in the service room. While not exposed to light, he will slowly turn red. Uppon reaching a pure red color, he will attack you.";
                AInumber.text = DaveAI.ToString();
            }
            if (page == 3)
            {
                
                RawI.texture = TexI3;
                INH.text = "Garry";
                IRH.text = "Racoon";
                ISH.text = "Inactive";
                IENH.text = "Garry sits in the office, on your right. He is inactive most of the time, however once he's activated, avoid any eye contact, or he will notice your presence. He will deactivate after a few seconds.";
                AInumber.text = GarryAI.ToString();
            }
            if (page == 4)
            {
                
                RawI.texture = TexI4;
                INH.text = "Happy";
                IRH.text = "Rabbit";
                ISH.text = "Stable";
                IENH.text = "Happy stands on the main stage. If he starts clapping, you should find him on your monitor, and watch his performance, or he might get angry.";
                AInumber.text = HappyAI.ToString();
            }
            if (page == 5)
            {
                
                RawI.texture = TexI5;
                INH.text = "Jeremy";
                IRH.text = "Mole";
                ISH.text = "Stable";
                IENH.text = "Jeremy can hack your computer, leaving you in a rather unpleasant situation.";
                AInumber.text = JeremyAI.ToString();
            }
            if (page == 6)
            {
                
                RawI.texture = TexI6;
                INH.text = "Keira and Billy";
                IRH.text = "Kangaro";
                ISH.text = "Stable";
                IENH.text = "Billy will try to unscreew the vent in front of you, to open an entrance for Keira. You can hit the desk to scare Billy away, but keep in mind that it might alert someone else. Once the vent has been opened, you should wear the mask to prevent Keira from entering.";
                AInumber.text = KeiraAI.ToString();
            }
            if (page == 7)
            {
                
                RawI.texture = TexI7;
                INH.text = "Otto";
                IRH.text = "Otter";
                ISH.text = "Unstable";
                IENH.text = "Otto roams the halls. He can't see really well, but he will track down the source of any noise nearby. Be silent to avoid him or use the decoy systems.";
                AInumber.text = OttoAI.ToString();
            }
            if (page == 8)
            {
                
                RawI.texture = TexI8;
                INH.text = "Russell";
                IRH.text = "Red Panda";
                ISH.text = "Stable";
                IENH.text = "Russel only attacks once every night. He is locked away in the staff room, but will start breaking the door down after hearing any noice. After the door is opened, he will check on you. Avoid using your flashlight, or he will turn off the power in the building.";
                AInumber.text = RussellAI.ToString();
            }
            if (page == 9)
            {
                
                RawI.texture = TexI9;
                INH.text = "Tina";
                IRH.text = "Mouse";
                ISH.text = "Stable";
                IENH.text = "Tina is constantly playing music. If you hear her approaching, look in the appropriate direction while wearing mask to trick her.";
                AInumber.text = TinaAI.ToString();
            }
            if (page == 10)
            {
                
                RawI.texture = TexI10;
                INH.text = "Wendy";
                IRH.text = "Rabbit";
                ISH.text = "Stable";
                IENH.text = "Wendy might peek at you from any of the 3 entrances. Blind her with your flashlight to scare her away.";
                AInumber.text = WendyAI.ToString();
            }
        }
    }
    public void NextPress()
    {
        if (page < 10)
        {
            page++;
            Pagenumber.text = "Page (" + page + "/10)";
            if (page == 1)
            {

                RawI.texture = TexI1;
                INH.text = "Ben";
                IRH.text = "Gorilla";
                ISH.text = "Stable";
                IENH.text = "Ben sits behind you. He will slowly approach you while you are distracted. Keep an eyey on him in order to avoid a fatal meeting.";
                AInumber.text = BenAI.ToString();
            }
            if (page == 2)
            {
    
                RawI.texture = TexI2;
                INH.text = "Dave";
                IRH.text = "Chameleon";
                ISH.text = "Stable";
                IENH.text = "Dave sits in the service room. While not exposed to light, he will slowly turn red. Uppon reaching a pure red color, he will attack you.";
                AInumber.text = DaveAI.ToString();
            }
            if (page == 3)
            {

                RawI.texture = TexI3;
                INH.text = "Garry";
                IRH.text = "Racoon";
                ISH.text = "Inactive";
                IENH.text = "Garry sits in the office, on your right. He is inactive most of the time, however once he's activated, avoid any eye contact, or he will notice your presence. He will deactivate after a few seconds.";
                AInumber.text = GarryAI.ToString();
            }
            if (page == 4)
            {
                RawI.texture = TexI4;
                INH.text = "Happy";
                IRH.text = "Rabbit";
                ISH.text = "Stable";
                IENH.text = "Happy stands on the main stage. If he starts clapping, you should find him on your monitor, and watch his performance, or he might get angry.";
                AInumber.text = HappyAI.ToString();
            }
            if (page == 5)
            {
                RawI.texture = TexI5;
                INH.text = "Jeremy";
                IRH.text = "Mole";
                ISH.text = "Stable";
                IENH.text = "Jeremy can hack your computer, leaving you in a rather unpleasant situation.";
                AInumber.text = JeremyAI.ToString();
            }
            if (page == 6)
            {
                RawI.texture = TexI6;
                INH.text = "Keira and Billy";
                IRH.text = "Kangaro";
                ISH.text = "Stable";
                IENH.text = "Billy will try to unscreew the vent in front of you, to open an entrance for Keira. You can hit the desk. to scare Billy away, but keep in mind that it might alert someone else. Once the vent has been opened, you should wear the mask to prevent Keira from entering.";
                AInumber.text = KeiraAI.ToString();
            }
            if (page == 7)
            {
                RawI.texture = TexI7;
                INH.text = "Otto";
                IRH.text = "Otter";
                ISH.text = "Unstable";
                IENH.text = "Otto roams the halls. He can't see really well, but he will track down the source of any noise nearby. Be silent to avoid him or use the decoy systems.";
                AInumber.text = OttoAI.ToString();
            }
            if (page == 8)
            {
                RawI.texture = TexI8;
                INH.text = "Russell";
                IRH.text = "Red Panda";
                ISH.text = "Stable";
                IENH.text = "Russel only attacks once every night. He is locked away in the staff room, but will start breaking the door down after hearing any noice. After the door is opened, he will check on you. Avoid using your flashlight, or he will turn off the power in the building.";
                AInumber.text = RussellAI.ToString();
            }
            if (page == 9)
            {
                RawI.texture = TexI9;
                INH.text = "Tina";
                IRH.text = "Mouse";
                ISH.text = "Stable";
                IENH.text = "Tina is constantly playing music. If you hear her approaching, look in the appropriate direction while wearing mask to trick her.";
                AInumber.text = TinaAI.ToString();
            }
            if (page == 10)
            {
                RawI.texture = TexI10;
                INH.text = "Wendy";
                IRH.text = "Rabbit";
                ISH.text = "Stable";
                IENH.text = "Wendy might peek at you from any of the 3 entrances. Blind her with your flashlight to scare her away.";
                AInumber.text = WendyAI.ToString();
            }
        }
    }

    public void plusFive()
    {
        if (page == 1)
        {
            BenAI += 5;
            if (BenAI>20)
            {
                BenAI = 20;
            }
            AInumber.text = BenAI.ToString();
        }
        if (page == 2)
        {
            DaveAI += 5;
            if (DaveAI > 20)
            {
                DaveAI = 20;
            }
            AInumber.text = DaveAI.ToString();
        }
        if (page == 3)
        {
            GarryAI += 5;
            if (GarryAI > 20)
            {
                GarryAI = 20;
            }
            AInumber.text = GarryAI.ToString();
        }
        if (page == 4)
        {
            HappyAI += 5;
            if (HappyAI > 20)
            {
                HappyAI = 20;
            }
            AInumber.text = HappyAI.ToString();
        }
        if (page == 5)
        {
            JeremyAI += 5;
            if (JeremyAI > 20)
            {
                JeremyAI = 20;
            }
            AInumber.text = JeremyAI.ToString();
        }
        if (page == 6)
        {
            KeiraAI += 5;
            if (KeiraAI > 20)
            {
                KeiraAI = 20;
            }
            AInumber.text = KeiraAI.ToString();
        }
        if (page == 7)
        {
            OttoAI += 5;
            if (OttoAI > 20)
            {
                OttoAI = 20;
            }
            AInumber.text = OttoAI.ToString();
        }
        if (page == 8)
        {
            RussellAI += 5;
            if (RussellAI > 20)
            {
                RussellAI = 20;
            }
            AInumber.text = RussellAI.ToString();
        }
        if (page == 9)
        {
            TinaAI += 5;
            if (TinaAI > 20)
            {
                TinaAI = 20;
            }
            AInumber.text = TinaAI.ToString();
        }
        if (page == 10)
        {
            WendyAI += 5;
            if (WendyAI > 20)
            {
                WendyAI = 20;
            }
            AInumber.text = WendyAI.ToString();
        }
    }
    public void MinusFive()
    {
        if (page == 1)
        {
            BenAI -= 5;
            if (BenAI < 0)
            {
                BenAI = 0;
            }
            AInumber.text = BenAI.ToString();
        }
        if (page == 2)
        {
            DaveAI -= 5;
            if (DaveAI < 0)
            {
                DaveAI = 0;
            }
            AInumber.text = DaveAI.ToString();
        }
        if (page == 3)
        {
            GarryAI -= 5;
            if (GarryAI < 0)
            {
                GarryAI = 0;
            }
            AInumber.text = GarryAI.ToString();
        }
        if (page == 4)
        {
            HappyAI -= 5;
            if (HappyAI < 0)
            {
                HappyAI = 0;
            }
            AInumber.text = HappyAI.ToString();
        }
        if (page == 5)
        {
            JeremyAI -= 5;
            if (JeremyAI < 0)
            {
                JeremyAI = 0;
            }
            AInumber.text = JeremyAI.ToString();
        }
        if (page == 6)
        {
            KeiraAI -= 5;
            if (KeiraAI < 0)
            {
                KeiraAI = 0;
            }
            AInumber.text = KeiraAI.ToString();
        }
        if (page == 7)
        {
            OttoAI -= 5;
            if (OttoAI < 0)
            {
                OttoAI = 0;
            }
            AInumber.text = OttoAI.ToString();
        }
        if (page == 8)
        {
            RussellAI -= 5;
            if (RussellAI < 0)
            {
                RussellAI = 0;
            }
            AInumber.text = RussellAI.ToString();
        }
        if (page == 9)
        {
            TinaAI -= 5;
            if (TinaAI < 0)
            {
                TinaAI = 0;
            }
            AInumber.text = TinaAI.ToString();
        }
        if (page == 10)
        {
            WendyAI -= 5;
            if (WendyAI < 0)
            {
                WendyAI = 0;
            }
            AInumber.text = WendyAI.ToString();
        }
    }
    public void plusOne()
    {
        if (page == 1)
        {
            BenAI += 1;
            if (BenAI > 20)
            {
                BenAI = 20;
            }
            AInumber.text = BenAI.ToString();
        }
        if (page == 2)
        {
            DaveAI += 1;
            if (DaveAI > 20)
            {
                DaveAI = 20;
            }
            AInumber.text = DaveAI.ToString();
        }
        if (page == 3)
        {
            GarryAI += 1;
            if (GarryAI > 20)
            {
                GarryAI = 20;
            }
            AInumber.text = GarryAI.ToString();
        }
        if (page == 4)
        {
            HappyAI += 1;
            if (HappyAI > 20)
            {
                HappyAI = 20;
            }
            AInumber.text = HappyAI.ToString();
        }
        if (page == 5)
        {
            JeremyAI += 1;
            if (JeremyAI > 20)
            {
                JeremyAI = 20;
            }
            AInumber.text = JeremyAI.ToString();
        }
        if (page == 6)
        {
            KeiraAI += 1;
            if (KeiraAI > 20)
            {
                KeiraAI = 20;
            }
            AInumber.text = KeiraAI.ToString();
        }
        if (page == 7)
        {
            OttoAI += 1;
            if (OttoAI > 20)
            {
                OttoAI = 20;
            }
            AInumber.text = OttoAI.ToString();
        }
        if (page == 8)
        {
            RussellAI += 1;
            if (RussellAI > 20)
            {
                RussellAI = 20;
            }
            AInumber.text = RussellAI.ToString();
        }
        if (page == 9)
        {
            TinaAI += 1;
            if (TinaAI > 20)
            {
                TinaAI = 20;
            }
            AInumber.text = TinaAI.ToString();
        }
        if (page == 10)
        {
            WendyAI += 1;
            if (WendyAI > 20)
            {
                WendyAI = 20;
            }
            AInumber.text = WendyAI.ToString();
        }
    }
    public void MinusOne()
    {
        if (page == 1)
        {
            BenAI -= 1;
            if (BenAI < 0)
            {
                BenAI = 0;
            }
            AInumber.text = BenAI.ToString();
        }
        if (page == 2)
        {
            DaveAI -= 1;
            if (DaveAI < 0)
            {
                DaveAI = 0;
            }
            AInumber.text = DaveAI.ToString();
        }
        if (page == 3)
        {
            GarryAI -= 1;
            if (GarryAI < 0)
            {
                GarryAI = 0;
            }
            AInumber.text = GarryAI.ToString();
        }
        if (page == 4)
        {
            HappyAI -= 1;
            if (HappyAI < 0)
            {
                HappyAI = 0;
            }
            AInumber.text = HappyAI.ToString();
        }
        if (page == 5)
        {
            JeremyAI -= 1;
            if (JeremyAI < 0)
            {
                JeremyAI = 0;
            }
            AInumber.text = JeremyAI.ToString();
        }
        if (page == 6)
        {
            KeiraAI -= 1;
            if (KeiraAI < 0)
            {
                KeiraAI = 0;
            }
            AInumber.text = KeiraAI.ToString();
        }
        if (page == 7)
        {
            OttoAI -= 1;
            if (OttoAI < 0)
            {
                OttoAI = 0;
            }
            AInumber.text = OttoAI.ToString();
        }
        if (page == 8)
        {
            RussellAI -= 1;
            if (RussellAI < 0)
            {
                RussellAI = 0;
            }
            AInumber.text = RussellAI.ToString();
        }
        if (page == 9)
        {
            TinaAI -= 1;
            if (TinaAI < 0)
            {
                TinaAI = 0;
            }
            AInumber.text = TinaAI.ToString();
        }
        if (page == 10)
        {
            WendyAI -= 1;
            if (WendyAI < 0)
            {
                WendyAI = 0;
            }
            AInumber.text = WendyAI.ToString();
        }
    }

    public void allTwenty()
    {
        BenAI = 20;
        DaveAI = 20;
        GarryAI = 20;
        HappyAI = 20;
        JeremyAI = 20;
        KeiraAI = 20;
        OttoAI = 20;
        RussellAI = 20;
        TinaAI = 20;
        WendyAI = 20;
        AInumber.text = "20";
    }
    public void allZero()
    {
        BenAI = 0;
        DaveAI = 0;
        GarryAI = 0;
        HappyAI = 0;
        JeremyAI = 0;
        KeiraAI = 0;
        OttoAI = 0;
        RussellAI = 0;
        TinaAI = 0;
        WendyAI = 0;
        AInumber.text = "0";
    }
    public void Update()
    {
        pointvalue = (BenAI + DaveAI + GarryAI + HappyAI + JeremyAI + KeiraAI + OttoAI + RussellAI + TinaAI + WendyAI)*10;
        Pointnumber.text = pointvalue.ToString();
        FinalScore = (BenAI + DaveAI + GarryAI + HappyAI + JeremyAI + KeiraAI + OttoAI + RussellAI + TinaAI + WendyAI) * 10;
    }
}
