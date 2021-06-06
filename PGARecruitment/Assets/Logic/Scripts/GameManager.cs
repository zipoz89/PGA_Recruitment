using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//skips menu if needed and udate end game screen
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menuObject;
    [SerializeField] private GameObject hudObject;
    [SerializeField] private CharacterController playerObject;
    [SerializeField] private LevelGeneratorRectangle level;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject endScreen;

    public void Start() {

        switch (GameStateManager.Instance.startGameFrom)
        {
            case RestartFrom.Menu:
                break;
            case RestartFrom.Game:
                StartGame();
                break;
            default:
                break;
        }
    }


    public void StartGame()
    {
        menuObject.SetActive(false);
        hudObject.SetActive(true);
        playerObject.enabled = true;
        level.RandomizeArea();
        timer.StartTimer();
    }

    public void EndGame()
    {

        endScreen.SetActive(true);
        endScreen.GetComponent<EndScreenPrompt>().DisplayAdditionalData();
    }


}
