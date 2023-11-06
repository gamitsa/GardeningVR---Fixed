using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class FootStepsAudio : MonoBehaviour
{
    public AudioClip[] steps;
    private List<AudioClip> randomlist;
    AudioSource source;

    [SerializeField] float stepSpeed = 0.5f;

    [SerializeField] AudioMixerGroup mixerOutput;

    [SerializeField] float pitchMin = 0.95f;

    [SerializeField] float pitchMax = 1.05f;

    [SerializeField] float volumeMin = 0.95f;

    [SerializeField] float volumeMax = 1.00f;
    bool playerisMoving;

    void Start()
    {
        randomlist = new List<AudioClip>(new AudioClip[steps.Length]);
        InvokeRepeating("CallFootsteps", 0f, stepSpeed);
        source = gameObject.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = mixerOutput;

        for (int i = 0; i < steps.Length; i++)
        {
            randomlist[i] = steps[i];
        }

    }

    public void Update()
    {
        if (Input.GetAxis("Vertical") >= 0.02f && Input.GetAxis("Horizontal") >= 0.02f
            && Input.GetAxis("Vertical") < 0f && Input.GetAxis("Horizontal") < 0f)
        {
            playerisMoving = true;
        }
        else if (Input.GetAxis("Vertical") == 0f && Input.GetAxis("Horizontal") == 0f)
        {
            playerisMoving = false;
        }
    }

    public void Reset()
    {
        for (int i = 0; i < steps.Length; i++)
        {
            randomlist.Add(steps[i]);
        }
    }
    void CallFootsteps()
    {
        if (playerisMoving == true)
        {
            PlayRandomSound();
        }
    }
    public void PlayRandomSound()
    {
        int i = Random.Range(0, randomlist.Count);
        source.pitch = Random.Range(pitchMin, pitchMax);
        source.volume = Random.Range(volumeMin, volumeMax);
        source.PlayOneShot(randomlist[i]);
        randomlist.RemoveAt(i);

        if (randomlist.Count == 0)
        {
            Reset();
        }
    }
}