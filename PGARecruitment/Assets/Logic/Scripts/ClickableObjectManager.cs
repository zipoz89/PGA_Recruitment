using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObjectManager : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private Collider objectColider;
    [SerializeField] private Outline outline;
    public bool isActive;
    protected virtual void Start() {
        objectColider = this.GetComponent<Collider>();
        outline = this.GetComponent<Outline>();
        controller = FindObjectOfType<PlayerController>();
    }

    protected void SetActive(bool state) {
        objectColider.enabled = state;
        outline.enabled = state;
        isActive = state;
    }

    protected void SetPlayerControllerActive(bool state) {
        controller.SetActive(state);
    }


    //---to use by events---
    public virtual void ObjectClicked() {
        SetActive(false);
        SetPlayerControllerActive(false);
    }
    public abstract void PromptYes();
    public virtual void PromptNo() {
        SetActive(true);
        SetPlayerControllerActive(true);
    }

}
