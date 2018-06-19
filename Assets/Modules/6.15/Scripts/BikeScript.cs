using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeScript : MonoBehaviour {
    private Manager manager = Manager.instance;
    public Transform basePos;
    public Transform target;

    public GameObject wheelForward;
    public GameObject wheelBack;

	// Use this for initialization
	void Start () {
	}



    // Update is called once per frame
    void Update() {
        if (manager.IsActive())
        {
            GetComponent<Rigidbody>().AddForce((target.position - transform.position) * 2f, ForceMode.Acceleration);
            SwitchAnim(true);
        }

        else
        {
            SwitchAnim(false);
        }

        if (manager.isReset())
        {
            manager.SetReset(false);
            manager.SetActive(false);
            transform.position = basePos.position;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Finish")) {
            manager.SetActive(false);
            SwitchAnim(false);
        }
    }

    public void SwitchAnim(bool option) {
        wheelForward.GetComponent<Animation>().enabled = option;
        wheelBack.GetComponent<Animation>().enabled = option;
    }

    void OnDestroy() {
        manager = null; 
    }
}
