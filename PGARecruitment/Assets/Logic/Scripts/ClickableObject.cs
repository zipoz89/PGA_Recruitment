using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Outline))]
public class ClickableObject : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    [SerializeField] private Transform objestToparentPrompt;
    [SerializeField] private VoidEvent onObjectClicked;
    [SerializeField] private Renderer[] objectsToHighlight;
    [SerializeField] private Color highlightColor;
    [SerializeField] private Outline outline;
    [SerializeField] private float outlineWidth=5;

    [SerializeField] private PromptData data;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private Transform distanceTo;

    [SerializeField] private bool isActive = false;
    bool isMouseOver = false;

    void Start()
    {
        if (outline == null) {
            Debug.Log("halo??");
            outline= gameObject.GetComponent<Outline>();
        }
    }

    void OnMouseOver() {
        isMouseOver = true;
        if (isActive  && IsCloseEnough()) {
            if(outline!=null)
                outline.OutlineWidth = outlineWidth;
            HighlightObject();
        }

    }

    public bool IsCloseEnough() {
        if (Vector3.Distance(this.transform.position, distanceTo.position) < maxDistance)
            return true;
        else return false;
    }

    void OnMouseExit() {
        isMouseOver = false;
        if (outline != null)
            outline.OutlineWidth = 0;
        UnhighlightObject();
        
    }

    public void SetActive(bool state) {
        isActive = state;

    }

    public void HighlightObject() {
        foreach (Renderer r in objectsToHighlight) {
            r.material.color = highlightColor;
        }
    }

    public void UnhighlightObject() {
        foreach (Renderer r in objectsToHighlight) {
            r.material.color = new Color(1, 1, 1, 1);
        }
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)&&isMouseOver&& isActive && IsCloseEnough()) {
            if(onObjectClicked!=null)
                onObjectClicked.Raise();
            GameObject o = Instantiate(prompt, objestToparentPrompt);
            PromptManager2Options promptManager = o.GetComponent<PromptManager2Options>();
            promptManager.SetData(data);
            //o.transform.parent = objestToparentPrompt;
        }
    }
}
