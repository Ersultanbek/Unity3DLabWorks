using System;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Scrtipt : MonoBehaviour {
    Manager manager = Manager.instance;

    public Transform target;

    Vector3 dir;
    private Rigidbody block;
    public Transform basePos;
    private bool isCoroutineExecuting;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().isKinematic = true;
        block = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().isKinematic = false;


    }
	
	// Update is called once per frame
	void Update () {
        if (manager.IsActive())
        {
            GetComponent<Rigidbody>().isKinematic = false;
            if (target == null)
                dir = Vector3.forward;
            else
                dir = target.position - block.position;

            float delta = Time.deltaTime;
            block.AddForce(dir * manager.GetAcceleration(), ForceMode.Acceleration);
        }
        if (manager.isReset()) {
            manager.SetReset(false);
            manager.SetActive(false);
            transform.position = basePos.position;  
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);

        if (collision.collider.tag.Equals("Finish"))
        {
            manager.SetActive(false);

            StartCoroutine(ExecuteAfterTime(0.5f, ()=> GetComponent<Rigidbody>().isKinematic = true));
        }
    }

    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }

    void OnDestroy()
    {
        manager = null;
    }
}
