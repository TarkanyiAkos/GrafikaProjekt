using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public GameObject RMask;
    public Animator animator;
    public static bool Masked = false;
    public AudioSource msound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && AIScript2.Unmask == false)
        {
            if (Masked == true)
            {
                msound.Stop();
                Masked = false;
                animator.SetBool("MaskedA", false);
                msound.Play();
            }
            else
            {
                msound.Stop();
                Masked = true; 
                animator.SetBool("MaskedA", true);
                msound.Play();

            }
        }
        if (AIScript2.Unmask == true && Masked == true)
        {
            msound.Stop();
            Masked = false;
            animator.SetBool("MaskedA", false);
            msound.Play();
        }

    }
}
