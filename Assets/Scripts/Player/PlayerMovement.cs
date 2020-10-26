﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.ParticleSystemJobs;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 playerPos;
    public float speed = 2.0f;
    public float moveDelay = 0.5f;
    public bool isActive = true;
    public GameObject[] gridTiles;
    public Transform player;
    public ParticleSystem playerExplosion;
    public Vector3 startPos;
    public Vector3 deathPos;
    public HoldMouse holdMouse;
    float respawnDelay = 0.2f;
    public ButtonCommand button;


    void Start()
    {
        startPos = player.position;
        foreach(GameObject g in gridTiles)
        {
            g.SetActive(false);
        }
    }

    void Update()
    {
        respawnDelay -= Time.deltaTime;
        if(holdMouse.numberSpaces == 1 && isActive)
        {
            gridTiles[0].SetActive(true);
            gridTiles[1].SetActive(false);
            gridTiles[2].SetActive(false);
            gridTiles[3].SetActive(false);            
        }
        else if(holdMouse.numberSpaces == 2 && isActive)
        {
            gridTiles[0].SetActive(true);
            gridTiles[1].SetActive(true);
            gridTiles[2].SetActive(false);
            gridTiles[3].SetActive(false);
        }
        else if(holdMouse.numberSpaces == 3 && isActive)
        {
            gridTiles[0].SetActive(true);
            gridTiles[1].SetActive(true);
            gridTiles[2].SetActive(true);
            gridTiles[3].SetActive(false);
        }
        else if(holdMouse.numberSpaces == 4 && isActive)
        {
            gridTiles[0].SetActive(true);
            gridTiles[1].SetActive(true);
            gridTiles[2].SetActive(true);
            gridTiles[3].SetActive(true);
        }
        else
        {
            gridTiles[0].SetActive(false);
            gridTiles[1].SetActive(false);
            gridTiles[2].SetActive(false);
            gridTiles[3].SetActive(false);
        }

        // switch(holdMouse.numberSpaces)
        // {
        //     case 1:
        //         gridTiles[0].SetActive(true);
        //         gridTiles[1].SetActive(false);
        //         gridTiles[2].SetActive(false);
        //         gridTiles[3].SetActive(false);
        //         break;
        //     case 2:
        //         gridTiles[0].SetActive(true);
        //         gridTiles[1].SetActive(true);
        //         gridTiles[2].SetActive(false);
        //         gridTiles[3].SetActive(false);
        //         break;
        //     case 3:
        //         gridTiles[0].SetActive(true);
        //         gridTiles[1].SetActive(true);
        //         gridTiles[2].SetActive(true);
        //         gridTiles[3].SetActive(false);
        //         break;
        //     case 4:
        //         gridTiles[0].SetActive(true);
        //         gridTiles[1].SetActive(true);
        //         gridTiles[2].SetActive(true);
        //         gridTiles[3].SetActive(true);
        //         break;
        //     default:
        //         gridTiles[0].SetActive(false);
        //         gridTiles[1].SetActive(false);
        //         gridTiles[2].SetActive(false);
        //         gridTiles[3].SetActive(false);
        //         break;
        // }

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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if(other.tag == "enemy")
        {
            Debug.Log("death");
            deathPos = playerPos;
            var deathPosition = Instantiate(playerExplosion, player);
            deathPosition.transform.SetParent(null);
            speed = 0;
            playerTransform();
        }
        else if(other.tag == "button")
        {
            button.LowerBlockage(); 
        }
    }

    void playerTransform()
    {
        player.localPosition = startPos;
        if(respawnDelay <= 0)
        {
            playerPos = startPos;
            speed = 1f;
        }
    }
}
