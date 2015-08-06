using UnityEngine;
using System.Collections;

public class SawbladeBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Player hit: " + coll.gameObject.tag);
    }
}
