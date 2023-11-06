using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySound : MonoBehaviour
{

    public AudioSource soundPlayer;
    public Animator animator;
    bool isActive = false;
    public Text playMusicText;
    private string playMusic;
    private string stopMusic;

    // Start is called before the first frame update
    void Start()
    {
        playMusic = "Play Music";
        animator.speed = 0.0f;
        playMusicText.text = playMusic;
        stopMusic = "Stop Music";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playThisSoundEffect()
    {
        soundPlayer.Play();
        if (!isActive)
        { 
            soundPlayer.Play(); 
            animator.speed = 1f;
            isActive = true;
            playMusicText.text = stopMusic;
        }

        else
        {
            soundPlayer.Pause();
            animator.speed = 0f;
            isActive = false;
            playMusicText.text = playMusic;
        }
        
    }
}
