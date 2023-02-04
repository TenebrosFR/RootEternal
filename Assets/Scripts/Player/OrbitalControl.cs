using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OrbitalControl : MonoBehaviour
{
    [SerializeField] GameObject PlayerBody;
    [SerializeField] Rigidbody rb;
    [SerializeField] Camera cam;
    [Range(0.1f, 9f)][SerializeField] float sensivity = 2f;
    [Range(-180, 180)][SerializeField] float maxY;
    [Range(-180, 180)][SerializeField] float minY;
    //Conversion d'une valeur input d'axis en °
    private float convertorRotate = 0.04f;
    public Vector3 rotation = Vector3.zero;

    private void Start() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate() {
        var timeSensivity = sensivity * Time.fixedDeltaTime;
        PlayerBody.transform.rotation = Quaternion.Euler(0,rotation.y * timeSensivity,0);
        cam.transform.localRotation = Quaternion.Euler(rotation.x * timeSensivity, 2, 0);
    }
    public void OnRotateY(InputAction.CallbackContext context) {
        rotation.y += context.ReadValue<float>();
    }
    public void OnRotateX(InputAction.CallbackContext context) {
        rotation.x -= context.ReadValue<float>();
        rotation.x = Mathf.Clamp(rotation.x, minY * 1/convertorRotate, maxY * 1 / convertorRotate);
        Debug.Log("iv vhiopi^jhbhv bvbjkokpijhjvbv bvbjkokpoijhbhvbbvbjkjopo$iojhjbvbn vbvbjhkjokipiijhlbvn vbvbjhjkoi^jhbvbbvbjhkoipjhgvbcbhjhjoi");
    }
}