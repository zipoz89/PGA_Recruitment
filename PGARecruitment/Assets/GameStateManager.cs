using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//!!!!Beware this class is a singleton :)!!!!
public enum GameState { 
    Menu,
    Game,
    Summary
}

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager instance = null;

    public static GameStateManager Instance {
        get {
            if (instance == null) {
                instance = (GameStateManager)FindObjectOfType(typeof(GameStateManager));
            }
            return instance;
        }
    }
    void Awake() {
        if (Instance != this) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    //actual class
    [SerializeField] private GameState gameState = GameState.Menu;
    [SerializeField] private GameObject menuObject;
    [SerializeField] private GameObject hudObject;
    [SerializeField] private GameObject playerObject;


    public void StartGame() {
        menuObject.SetActive(false);
        hudObject.SetActive(true);
        playerObject.transform.position = new Vector3(0,0,0);
        playerObject.GetComponent<CharacterController>().enabled = true;
    }


}
