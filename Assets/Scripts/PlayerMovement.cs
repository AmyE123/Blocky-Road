using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 playerPos;
    public float speed = 2.0f;
    public float moveDelay = 0.5f;
    public bool isActive = true;
    public GameObject[] gridTiles;

    public HoldMouse holdMouse;


    void Start()
    {
        foreach(GameObject g in gridTiles)
        {
            g.SetActive(false);
        }
    }

    void Update()
    {
        switch(holdMouse.numberSpaces)
        {
            case 1:
                gridTiles[0].SetActive(true);
                gridTiles[1].SetActive(false);
                gridTiles[2].SetActive(false);
                gridTiles[3].SetActive(false);
                break;
            case 2:
                gridTiles[0].SetActive(true);
                gridTiles[1].SetActive(true);
                gridTiles[2].SetActive(false);
                gridTiles[3].SetActive(false);
                break;
            case 3:
                gridTiles[0].SetActive(true);
                gridTiles[1].SetActive(true);
                gridTiles[2].SetActive(true);
                gridTiles[3].SetActive(false);
                break;
            case 4:
                gridTiles[0].SetActive(true);
                gridTiles[1].SetActive(true);
                gridTiles[2].SetActive(true);
                gridTiles[3].SetActive(true);
                break;
            default:
                gridTiles[0].SetActive(false);
                gridTiles[1].SetActive(false);
                gridTiles[2].SetActive(false);
                gridTiles[3].SetActive(false);
                break;

        }




        if(holdMouse.numberSpaces == 1)
        {
            gridTiles[0].SetActive(true);

        }
    }

    public void PlayerMove(int numberOfSpaces)
    {
        // if(isActive)
        // {
        //     playerPos += Vector3.right * numberOfSpaces;
        //     Debug.Log("right");  
        //     transform.DOMove(playerPos, speed); 
        // }
        if(isActive && holdMouse.players[0])
        {
            playerPos += Vector3.right * numberOfSpaces; 
            transform.DOLocalMove(playerPos, speed); 
        }
        else if(isActive && holdMouse.players[1])
        {
            playerPos += Vector3.left * numberOfSpaces; 
            transform.DOLocalMove(playerPos, speed); 
        }
    }

    // void OnTriggerExit(Collider other)
    // {
    //     var cubeFloor = other.gameObject;
    //     cubeFloor.transform.position = new Vector3 (cubeFloor.transform.position.x, 1f, cubeFloor.transform.position.z);
    // }
}
