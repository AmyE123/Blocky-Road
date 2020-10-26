using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCommand : MonoBehaviour
{
    public GameObject blockage;

    public void LowerBlockage()
    {
        blockage.SetActive(false);
    }
}
