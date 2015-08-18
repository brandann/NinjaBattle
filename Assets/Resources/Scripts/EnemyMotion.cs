using UnityEngine;
using System.Collections;

public class EnemyMotion : MonoBehaviour {

    int direction;

	// Use this for initialization
	void Start () {
        direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(transform.position.x + direction *Time.deltaTime, -3.011f, 0);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 14 || coll.gameObject.layer == 10)
        {
            direction *= -1;
        }
    }
}
