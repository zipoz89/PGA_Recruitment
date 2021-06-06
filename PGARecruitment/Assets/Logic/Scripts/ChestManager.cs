using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

//manages what happens to chess object while interacting

//works only with one chest on cene due to timeline playable being a some kind of pointer so all chests play the same animation, I could potentialy clone the binding but for now its outside the scope of task
public class ChestManager : ClickableObjectManager {
    private PlayableDirector director;
    [SerializeField] bool isOpen = false;

    protected new void Start() {
        base.Start();
        director = this.GetComponent<PlayableDirector>();
        //to do 
        //potential playable cloning
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
    public void SetIsOpen() {
        isOpen = true;
    }

    public void SetTimelineCheckpoint() {
        StopTimeline();
    }

    //---to use by events---
    public override void PromptYes() {
        ToggleChest();
    }


    private void    Update() {
        if (Input.GetKeyUp(KeyCode.Escape) ) {
                ExitChest();
        }
    }
}
