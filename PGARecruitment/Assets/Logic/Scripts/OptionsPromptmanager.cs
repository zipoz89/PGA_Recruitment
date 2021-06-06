using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//specialization for options menu
public class OptionsPromptmanager : PromptOneOption
{
    [SerializeField] private TextMeshProUGUI roomSize;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider roomSlider;

    protected override void Start()
    {
        base.Start();
        SetData(data);
        musicSource = MusicManager.Instance.audioSource;
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        roomSlider.value = PlayerPrefs.GetInt("RoomSize");
        SetRoomSizeText(roomSlider.value);
    }

    public void SetMusicVolume(float value) {
        PlayerPrefs.SetFloat("MusicVolume", value);
        musicSource.volume = value;
    }

    public void SetRoomSize(float value)
    {
        SetRoomSizeText(value);
        PlayerPrefs.SetInt("RoomSize", (int)value);
    }

    public void SetRoomSizeText(float value) {
        if (value < 8)
            roomSize.text = "Room Size: S";
        else if (value < 12)
            roomSize.text = "Room Size: M";
        else
            roomSize.text = "Room Size: L";
    }

    protected override void OnClickButton() {
        this.gameObject.SetActive(false);
    }


    public void ResetHighscore() {
        HighScore.SetHighScoreMax();
        FindObjectOfType<MenuPrompt>().SetHighscoreTMP();
    }
}
