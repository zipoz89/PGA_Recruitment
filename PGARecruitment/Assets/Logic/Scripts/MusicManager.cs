using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//singleton that plays looping music between scenes etc.
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;
    public AudioSource audioSource;

    public static MusicManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (MusicManager)FindObjectOfType(typeof(MusicManager));
            }
            return instance;
        }
    }

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
    }


    void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
