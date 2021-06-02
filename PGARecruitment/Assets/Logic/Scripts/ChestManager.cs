using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ChestManager : MonoBehaviour
{
    private PlayableDirector director;
    [SerializeField] bool isOpen = false;
    [SerializeField] private VoidEvent exitChest;

    private void Start() {
        director = GetComponent<PlayableDirector>();
        director.Play();
    }


    [ContextMenu("Pause timeline")]
    public void StopTimeline() {
        director.Pause();
        
    }

    [ContextMenu("Continue timeline")]
    public void ToggleChest() {
        director.Resume();
        
    }

    public void SetChestOpen() {
        director.Resume();
        isOpen = true;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && isOpen) {
            isOpen = false;
            ToggleChest();
            exitChest.Raise();
        }
    }
}
