using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot_Input : StateEffect
{
    private PlayerInputActions playerInputActions;
    private Character user;

    private Camera cam;
    private Vector2 mousePos;

    Vector3 rot;

    // Adjust this sensitivity factor to control the accelerometer sensitivity
    public float accelerometerSensitivity = 0.5f;

    private void Start()
    {
        rot = Vector3.zero;
        Input.gyro.enabled = false; // Disable gyro
    }
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        playerInputActions.Player.Shoot.started += Shoot_performed;
        playerInputActions.Player.Shoot.canceled += Shoot_performed;
        playerInputActions.Player.ChangeWeapon.performed += ChangeWeapon_performed;
        cam = Camera.main;
    }

    private void ChangeWeapon_performed(InputAction.CallbackContext obj)
    {
        //user.GetComponent<Character>().ChangeWeaponScroll(obj.ReadValue<float>() > 0 ? 1 : -1);
        if (user == null) playerInputActions.Player.ChangeWeapon.performed -= ChangeWeapon_performed;
        user.GetComponent<Character>().ChangeWeapon(Mathf.Clamp((int)obj.ReadValue<float>(), 0, 1));
    }

    private void OnDisable()
    {
        playerInputActions.Player.Shoot.started -= Shoot_performed;
        playerInputActions.Player.Shoot.canceled -= Shoot_performed;
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        user.shooting = obj.ReadValue<float>() == 0 ? false : true;
    }

    public override void OnEnd(GameObject user, GameObject target, GameObject moveTarget) { }

    public override void OnStart(GameObject user, GameObject target, GameObject moveTarget)
    {
        this.user = user.GetComponent<Character>();
    }

    public override State OnUpdate(GameObject user, GameObject target, GameObject moveTarget)
    {
        // Calculate aim direction based on accelerometer input
        Vector3 accelerometerInput = new Vector3(-Input.acceleration.y, Input.acceleration.x, 0f) * accelerometerSensitivity;

        // Apply accelerometer input to the user's look direction
        this.user.lookDir = Quaternion.Euler(accelerometerInput) * user.transform.forward;

        return null;
    }
}


