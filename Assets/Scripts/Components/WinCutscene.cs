using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCutscene : MonoBehaviour
{
    public Sprite fullMask;

    private Player player;
    private SpriteMask lanternMask;
    private Lantern lantern;

    private class Event
    {
        public delegate void Action();
        public Action action;
        public float startTime;
    }
    private List<Event> events = new List<Event>();
    private int currentEventIndex;
    private float timeSinceStart;

    private void Start()
    {
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

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<FootstepPlayer>().enabled = false;
        lantern = player.GetComponentInChildren<Lantern>();
        lantern.allowGameOver = false;
        lanternMask = lantern.GetComponent<SpriteMask>();
        timeSinceStart = 0.0f;
        currentEventIndex = 0;
    }

    private void Update()
    {
        timeSinceStart += Time.deltaTime;
        if (events[currentEventIndex].startTime <= timeSinceStart)
        {
            events[currentEventIndex].action();
            currentEventIndex++;
        }
    }
}
