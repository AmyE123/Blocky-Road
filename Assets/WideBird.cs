using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WideBird : MonoBehaviour
{
    public Image BirdImage;
    public int birdFedAmount;
    int width = 100;

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            birdFedAmount++;
            FeedBird();
        }
    }

    void FeedBird()
    {
        BirdImage.rectTransform.sizeDelta = new Vector2(++birdFedAmount, width);
    }
}
