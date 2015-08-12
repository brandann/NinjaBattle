using UnityEngine;
using System.Collections;

public class KillPlayerOnTouch : MonoBehaviour {

    private GameObject Spawnpoint;

    // Use this for initialization
    void Start()
    {
        Spawnpoint = GameObject.Find("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Player hit: " + coll.gameObject.tag);
            coll.gameObject.transform.position = Spawnpoint.transform.position;
        }
    }
}
