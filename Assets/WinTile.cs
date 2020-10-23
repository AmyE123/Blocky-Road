using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTile : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Win");
    }

}
