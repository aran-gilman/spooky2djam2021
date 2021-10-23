using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    protected Player player;
    protected Lantern lantern;

    protected class Event
    {
        public delegate void Action();
        public Action action;
        public float startTime;
    }
    protected List<Event> events = new List<Event>();

    private int currentEventIndex;
    private float timeSinceStart;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        lantern = player.GetComponentInChildren<Lantern>();
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<FootstepPlayer>().enabled = false;
        lantern.allowGameOver = false;

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
