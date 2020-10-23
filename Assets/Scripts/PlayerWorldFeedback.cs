using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerWorldFeedback : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        var cubeFloor = other.gameObject;
        //Destroy(other.gameObject);
        cubeFloor.transform.position += new Vector3 (0, -1.5f, 0);
    }
}
