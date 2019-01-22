using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        CharControl.isgrnd = 1;
        CharControl.secondj = 2;

    }
}





