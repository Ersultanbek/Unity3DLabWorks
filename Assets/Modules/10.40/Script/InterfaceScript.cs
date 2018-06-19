using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceScript : MonoBehaviour {
    Manager manager = Manager.instance;

    public Button startButton;
    public GameObject blockObject;

    public void StartAction()
    {
        float angle = (Mathf.Rad2Deg * Mathf.Atan(manager.GetFriction()));
        startButton.interactable = false;
        manager.SetAcceleration(10f * (Mathf.Sin((angle * Mathf.PI) / 180)));
        manager.SetActive(true);
    }

    public void ResetScene()
    {
        startButton.interactable = true;
        manager.SetReset(true);
    }

    public void SetFrictionValue(string str) {
        manager.SetFriction(float.Parse(str));
    }
}
