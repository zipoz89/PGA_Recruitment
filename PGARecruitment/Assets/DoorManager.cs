﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoorManager : ClickableObjectManager {
    [SerializeField] private PlayableDirector director;
    protected new void Start() {
        base.Start();
        if(director==null)
            director = this.GetComponent<PlayableDirector>();
    }

    [ContextMenu("Start timeline")]
    private void StartTimeline() {
        director.Play();

    }

    public override void PromptYes() {
        StartTimeline();
    }
}