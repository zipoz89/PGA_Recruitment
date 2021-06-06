using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//general class for clickable objects, It manages things like outline, player controlls while on prompt etc.

public class ClickableObject : MonoBehaviour
{
    [SerializeField] protected GameObject prompt;
    [SerializeField] protected Transform objestToparentPrompt;
    [SerializeField] private Renderer[] objectsToHighlight;
    [SerializeField] private Color highlightColor;
    [SerializeField] private Outline outline;
    [SerializeField] private float outlineWidth=5;
    [SerializeField] protected VoidEvent objectCllicked;
    [SerializeField] protected PromptData data;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private Transform distanceTo;

    [SerializeField] private bool isActive = false;
    bool isMouseOver = false;
    bool isHighlighted = false;

    protected virtual void Start()
    {
        distanceTo = FindObjectOfType<CharacterController>().transform;
        objestToparentPrompt = GameObject.Find("HUDCanvas").transform;
        if (outline == null) {
            outline= gameObject.GetComponent<Outline>();
        }
    }


    public bool IsCloseEnough() {
        if (Vector3.Distance(this.transform.position, distanceTo.position) < maxDistance)
            return true;
        else return false;
    }
    void OnMouseOver() {
        isMouseOver = true;

        HighlightObject();
    }

    void OnMouseExit() {
        isMouseOver = false;
        UnhighlightObject(); 
    }

    public void SetActive(bool state) {
        isActive = state;
    }

    public void HighlightObject() {
        if (isActive && IsCloseEnough()) {
            CursorManager.ChangeCursor(CursorStyle.Hand);
            isHighlighted = true;
            if (outline != null)
                outline.OutlineWidth = outlineWidth;
            foreach (Renderer r in objectsToHighlight) {
                r.material.color = highlightColor;
            }
        }
    }

    public void UnhighlightObject() {
        isHighlighted = false;
        CursorManager.ChangeCursor(CursorStyle.Basic);
        if (outline != null)
            outline.OutlineWidth = 0;
        foreach (Renderer r in objectsToHighlight) {
            r.material.color = new Color(1, 1, 1, 1);
        }
    }

    protected virtual void Clicked() {
        if (objectCllicked != null)
            objectCllicked.Raise();
        GameObject o = Instantiate(prompt, objestToparentPrompt);
        PromptTwoOptions promptManager = o.GetComponent<PromptTwoOptions>();
        promptManager.SetData(data);
    }

    private void Update() {
        if (!IsCloseEnough() && isHighlighted) {
            UnhighlightObject();
            //CursorManager.ChangeCursor(CursorStyle.Basic);
        }

        if (Input.GetMouseButtonDown(0)&&isMouseOver&& isActive && IsCloseEnough()) {
            Clicked();
            //o.transform.parent = objestToparentPrompt;
        }
    }
}
