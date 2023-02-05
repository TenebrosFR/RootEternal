using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using utils;

public class OrbitalControl : MonoBehaviour
{
    [SerializeField] GameObject PlayerBody;
    [SerializeField] Rigidbody rb;
    [SerializeField] Camera cam;
    [Range(0.1f, 9f)][SerializeField] float sensivity = 2f;
    [Range(-90, 90)][SerializeField] float maxY;
    [Range(-90, 90)][SerializeField] float minY;
    //Conversion d'une valeur input d'axis en °
    private float convertorRotate = 0.04f;
    public Quaternion rotation = Quaternion.identity;

    private void Start() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate() {
        var timeSensivity = sensivity * Time.fixedDeltaTime;
        PlayerBody.transform.rotation = Quaternion.Euler(0,rotation.y * timeSensivity,0);
        cam.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotation.x * convertorRotate, minY, maxY), 0, 0);
    }
    public void OnRotateY(InputAction.CallbackContext context) {
        if (ManagePlayer.isLocked) return;
        rotation.y += context.ReadValue<float>();
    }
    public void OnRotateX(InputAction.CallbackContext context) {
        if (ManagePlayer.isLocked) return;
        rotation.x -= context.ReadValue<float>();
    }
}