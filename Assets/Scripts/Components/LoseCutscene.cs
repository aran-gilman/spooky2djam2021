using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCutscene : Cutscene
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        events.Add(new Event
        {
            action = delegate
            {
                lantern.enabled = false;
                lantern.GetComponent<AudioSource>().enabled = false;
            },
            startTime = 1.0f
        });

        events.Add(new Event
        {
            action = delegate
            {
                audioSource.Play();
            },
            startTime = 1.5f
        });

        events.Add(new Event
        {
            action = delegate
            {
                SceneManager.LoadScene("LoseScene");
            },
            startTime = 7.0f
        });

    }
}
