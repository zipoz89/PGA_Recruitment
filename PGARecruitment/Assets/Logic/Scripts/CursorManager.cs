using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CursorStyle { 
    Basic,
    Hand
}

public class CursorManager : MonoBehaviour {
    public CursorStyle currentStyle;
    //need to be in the same order as CursorStyle
    [SerializeField] private Texture2D[] cursors; 
    private void Start() {
        ChangeCursor(currentStyle);
    }
    public void ChangeCursor(CursorStyle style){
        Cursor.SetCursor(cursors[(int)Convert.ChangeType(style, style.GetTypeCode())],Vector2.zero,CursorMode.ForceSoftware);
    }

    public void SetCursorBasic() {
        Cursor.SetCursor(cursors[0], Vector2.zero, CursorMode.ForceSoftware);
    }

    public void SetCursorHand() {
        Cursor.SetCursor(cursors[1], Vector2.zero, CursorMode.ForceSoftware);
    }
}
