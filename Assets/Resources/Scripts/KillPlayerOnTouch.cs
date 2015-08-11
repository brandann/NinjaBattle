using UnityEngine;
using System.Collections;

public class KillPlayerOnTouch : MonoBehaviour {

    private GameObject Spawnpoint;

    private float killstart;
    private float killwait;
    private bool holdwait;

    // Use this for initialization
    void Start()
    {
        Spawnpoint = GameObject.Find("SpawnPoint");
        holdwait = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(holdwait)
        {
            if(killstart - Time.timeSinceLevelLoad >= killwait)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Player hit: " + coll.gameObject.tag);
            coll.gameObject.transform.position = Spawnpoint.transform.position;
        }

        if (this.tag == "projectile")
        {
            holdwait = true;
        }
    }
}
