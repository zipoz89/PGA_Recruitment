using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CursorStyle { 
    Basic,
    Hand
}

//Cursor manager with static methods to change its style

public class CursorManager : MonoBehaviour {
    public CursorStyle currentStyle;
    //need to be in the same order as CursorStyle
    [SerializeField] private static List<Texture2D> cursors = new List<Texture2D>();
    [SerializeField] private Texture2D[] nonStaticCursors;
    private void Awake() {

        for (int i = 0; i < nonStaticCursors.Length; i++) {
            cursors.Add(nonStaticCursors[i]);
        }
    }

    private void Start() {
        ChangeCursor(currentStyle);
    }
    public static void ChangeCursor(CursorStyle style){
        Cursor.SetCursor(cursors[(int)Convert.ChangeType(style, style.GetTypeCode())],Vector2.zero,CursorMode.ForceSoftware);
    }

}
