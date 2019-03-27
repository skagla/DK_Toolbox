using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TrigTimeline : MonoBehaviour
{

    PlayableDirector playableDirector;

    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        
    }
  

    public void TriggerTimeline()
    {
        playableDirector.Play();
    }
}
