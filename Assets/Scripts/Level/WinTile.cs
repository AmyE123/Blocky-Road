using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTile : MonoBehaviour
{
    public SoundFX soundFX;
    public AudioClip winSound;
    public int winButton;
    public string nextScene;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Win");
            soundFX.PlaySound(winSound);
            winButton++;
        }


    }

    void Update()
    {
        if(winButton >= 2)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

}
