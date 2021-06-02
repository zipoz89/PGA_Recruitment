using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ChestManager : ClickableObjectManager {
    private PlayableDirector director;
    [SerializeField] bool isOpen = false;


    protected new void Start() {
        base.Start();
        director = this.GetComponent<PlayableDirector>();
        director.Play();
    }


    [ContextMenu("Pause timeline")]
    private void StopTimeline() {
        director.Pause();
        
    }

    [ContextMenu("Continue timeline")]
    private void ToggleChest() {
        director.Resume();
        
    }


    public void ExitChest() {
        if (isOpen) {
            ToggleChest();
            isOpen = false;
            SetActive(true);
            SetPlayerControllerActive(true);
        }
    }
    //used by timeline signal
    public void SetChestOpen() {
        director.Resume();
        isOpen = true;
    }

    //---to use by events---
    public override void PromptYes() {
        ToggleChest();
    }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && isOpen) {
            ExitChest();
        }
    }
}
