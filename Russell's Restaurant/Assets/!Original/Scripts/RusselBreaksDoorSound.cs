using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RusselBreaksDoorSound : MonoBehaviour
{
    public AudioSource doorBreak;
    public void DoorBreak ()
    {
        doorBreak.Play();
    }
}
