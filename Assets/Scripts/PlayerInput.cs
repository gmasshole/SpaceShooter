﻿using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    PlayerController controller;
    PlayerAttack attack;

    float horizontalDirection;
    float verticalDirection;
    Vector2 direction;

    bool warpActive = false;
    bool machinegunActive = false;
    bool rocketsActive = false;
    bool reloadActive = false;

    private void Awake() {
        controller = GetComponent<PlayerController>();
        attack = GetComponent<PlayerAttack>();
        direction = Vector2.zero;
    }

    private void Update() {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontalDirection, verticalDirection);

        if (Input.GetKey(KeyCode.X)) {
            warpActive = true;
        }

        if (Input.GetKey(KeyCode.C)) {
            machinegunActive = true;
        }

        if (Input.GetKey(KeyCode.V)) {
            rocketsActive = true;
        }

        //if (Input.GetKeyDown(KeyCode.R)) {
        //    reloadActive = true;
        //}

        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    private void FixedUpdate() {
        controller.Move(direction, warpActive);
        attack.Attack(machinegunActive, rocketsActive, reloadActive);

        warpActive = false;
        machinegunActive = false;
        rocketsActive = false;
        reloadActive = false;
    }
}
