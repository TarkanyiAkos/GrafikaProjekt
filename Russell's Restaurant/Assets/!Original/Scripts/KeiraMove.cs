using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeiraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public void MoveMe()
    {
        transform.Translate(0.04f, 0, 0);
    }
}
