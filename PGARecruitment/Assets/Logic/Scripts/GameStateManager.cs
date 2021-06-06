using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this class store inforamton about game state between games

//!!!!Beware this class is a singleton :)!!!!
public enum RestartFrom { 
    Menu,
    Game
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

    private void Start()
    {
        if (HighScore.GetHighScore() == 0)
            HighScore.SetHighScoreMax();
        if (startGameFrom == RestartFrom.Game) {
            FindObjectOfType<GameManager>().StartGame();
        }
        if (PlayerPrefs.GetInt("RoomSize") == 0)
            PlayerPrefs.SetInt("RoomSize", 8);
        if (PlayerPrefs.GetFloat("MusicVolume") == 0)
            PlayerPrefs.SetFloat("MusicVolume", 8);
    }

    public RestartFrom startGameFrom = RestartFrom.Menu;



    public void Retry() {
        startGameFrom = RestartFrom.Game;
        SceneManager.LoadScene("MainGame");
        //FindObjectOfType<GameManager>().PrcesGameState();
    }

    public void  Menu() {
        startGameFrom = RestartFrom.Menu;
        SceneManager.LoadScene("MainGame");
        //FindObjectOfType<GameManager>().PrcesGameState();
    }


}
