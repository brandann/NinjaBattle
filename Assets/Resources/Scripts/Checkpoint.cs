using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    private GameObject Spawnpoint;

	// Use this for initialization
	void Start () 
    {
        Spawnpoint = GameObject.Find("SpawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Player hit: " + coll.gameObject.tag);
            Spawnpoint.transform.position = this.transform.position;
            GameObject.Destroy(this.gameObject);
        }
    }
}
