using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    public GameObject center;
    public Vector3 direction;

    public void Update()
    {
        transform.RotateAround(center.transform.position, direction, 1f);
    }
}
