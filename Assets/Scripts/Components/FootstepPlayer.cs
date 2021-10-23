using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepPlayer : MonoBehaviour
{
    public List<AudioClip> stepSounds = new List<AudioClip>();
    public float stepsPerSecond = 2.0f;

    private AudioSource source;
    private float timeSinceLastStep = 999.0f;

    private AudioClip SelectClip()
    {
        return stepSounds[Random.Range(0, stepSounds.Count)];
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        timeSinceLastStep += Time.deltaTime;
        if (timeSinceLastStep > 1.0f / stepsPerSecond)
        {
            source.PlayOneShot(SelectClip());
            timeSinceLastStep = 0.0f;
        }
    }
}
