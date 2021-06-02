using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuObject;
    [SerializeField] private GameObject HudObject;

    public void ToggleMenu() {
        if (MenuObject.activeSelf) {
            MenuObject.SetActive(false);
            HudObject.SetActive(true);
        }
        else { 
            MenuObject.SetActive(true);
            HudObject.SetActive(false);
        }
    }
}
