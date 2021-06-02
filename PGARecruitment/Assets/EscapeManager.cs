using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EscapeState {
    Ingame,
    ChestOpened
}
public class EscapeManager : MonoBehaviour
{


    EscapeState state;
    public void SetState(EscapeState state) {
        this.state = state;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) { 
            
        }
    }
}
