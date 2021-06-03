using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isActive = false;
    [SerializeField] private float walkingSpeed = 12f;
    [SerializeField] private float rotateSpeed = 12f;
    CharacterController controller;

    private void Start() {
        controller = this.GetComponent<CharacterController>();
    }

    private void Update() {
        if (isActive && controller.enabled) {
            MovePlayer();
            RotatePlayer();
        }
    }


    private void MovePlayer() {
        
        Vector3 moveTowards = this.transform.right * Input.GetAxis("Horizontal") + this.transform.forward * Input.GetAxis("Vertical");
        moveTowards = Vector3.ClampMagnitude(moveTowards, 1f);
        controller.Move(moveTowards * walkingSpeed * Time.deltaTime);

    }
    private void RotatePlayer() {
        Vector3 rotatation = Vector3.zero;
        if (Input.GetKey(KeyCode.Q))
            rotatation -= new Vector3(0, 1, 0);
        if (Input.GetKey(KeyCode.E))
            rotatation += new Vector3(0, 1, 0);

        this.transform.Rotate(rotatation* rotateSpeed* Time.deltaTime);

    }

    public void SetActive(bool state) { 
        isActive = state;
    }

    public bool GetActiveState() {
        return isActive;
    }
}
