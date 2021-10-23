using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCutscene : Cutscene
{
    public Sprite fullMask;

    private SpriteMask lanternMask;

    private void Start()
    {
        lanternMask = lantern.GetComponent<SpriteMask>();

        events.Add(new Event
        {
            action = delegate
            {
                lanternMask.sprite = fullMask;
                lantern.Refresh(1.0f);
                lantern.enabled = false;
            },
            startTime = 0.5f
        });

        events.Add(new Event
        {
            action = delegate
            {
                SceneManager.LoadScene("WinScene");
            },
            startTime = 3.0f
        });
    }
}
