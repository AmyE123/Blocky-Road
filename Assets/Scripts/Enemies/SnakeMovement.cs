using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnakeMovement : MonoBehaviour
{
    public Vector3[] snakePositions;
    public Transform frontBlock;
    public int position = 0;
    int positionRemainder;
    public float delay = 1f;
    float delayTimer = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delayTimer -= Time.deltaTime;
        if(delayTimer <= 0)
        {
            if(position == 12)
            {
                position = 0;
            }
            //frontBlock.localPosition = new Vector3 (frontBlock.position.x, snakePositions[position].y, snakePositions[position].z);
            frontBlock.localPosition = snakePositions[position];
            position++;
            delayTimer = delay;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit enemy");
    }
}
