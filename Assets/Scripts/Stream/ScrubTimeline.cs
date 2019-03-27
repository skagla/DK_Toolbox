using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class ScrubTimeline : MonoBehaviour
{

    PlayableDirector playableDirector;
    double duration;

    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        duration = playableDirector.duration;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTimelineTime(float t)
    {
        playableDirector.time = t*duration;
        playableDirector.Evaluate();
    }
}
