using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager {
    private float friction;
    bool active = false;
    bool reset = false;

    public static Manager instance = new Manager();
    private float acceleration;

    static Manager()
    {

    }

    public static Manager Instance
    {
        get
        {
            return instance;
        }
    }

    public void SetFriction(float friction) {
        this.friction = friction;
    }

    public float GetFriction() {
        return friction;
    }

    public void SetAcceleration(float acceleration) {
        this.acceleration = acceleration;
    }

    public float GetAcceleration() {
        return acceleration;
    }

    public void SetActive(bool active)
    {
        this.active = active;
    }

    public bool IsActive()
    {
        return active;
    }

    public void SetReset(bool reset)
    {
        this.reset = reset;
    }

    public bool isReset()
    {
        return reset;
    }
}
