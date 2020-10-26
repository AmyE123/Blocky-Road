using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloorTile : MonoBehaviour
{
    public bool isWalkedOn = false;

    void OnTriggerExit(Collider other)
    {
        isWalkedOn = true;
        //Debug.Log("WalkedOver");
        //transform.DOPunchScale(Vector3.zero, 2, 10, 1);
        //Destroy(other.gameObject);
    }
}
