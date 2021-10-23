using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCutscene : Cutscene
{
    public Sprite fullMask;
    public float lightOpacity = 0.5f;

    private SpriteMask lanternMask;
    private SpriteRenderer lanternLight;

    private void Start()
    {
        lanternMask = lantern.GetComponent<SpriteMask>();
        lanternLight = lantern.GetComponent<SpriteRenderer>();

        events.Add(new Event
        {
            action = delegate
            {
                lanternMask.sprite = fullMask;
                lantern.Refresh(1.0f);
                lantern.enabled = false;
                lanternLight.sprite = fullMask;
                lanternLight.color = new Color(lanternLight.color.r, lanternLight.color.g, lanternLight.color.b, lightOpacity);
            },
            startTime = 0.5f
        });

        events.Add(new Event
        {
            action = delegate
            {
                SceneManager.LoadScene("WinScene");
            },
            startTime = 3.5f
        });
    }
}
