using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
    

//play sounds on mouse hoover and click
public class ButtonSFX : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler ,IPointerDownHandler
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clipClick;
    [SerializeField] private AudioClip clipEnter;
    [SerializeField] private AudioClip clipExit;
    [SerializeField] private string audioSourceObjectName;

    private void Start()
    {
        audioSource = GameObject.Find(audioSourceObjectName).gameObject.GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (clipClick != null) {
            audioSource.clip = clipClick;
            audioSource.Play();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (clipEnter != null) {
            audioSource.clip = clipEnter;
            audioSource.Play();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (clipExit != null) {
            audioSource.clip = clipClick;
            audioSource.Play();
        }
    }
}
