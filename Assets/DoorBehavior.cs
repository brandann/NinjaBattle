using UnityEngine;
using System.Collections;

public class DoorBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.LogWarning("Player Hit Door");
        if (coll.gameObject.tag == "Player")
        {
            Debug.LogWarning("Player Hit Door");
            var go = coll.gameObject.transform.parent.GetComponent<Player>();
            if (go.GainHeart())
            {
                go.GetComponent<PlatformerMotor2D>().ToggleLayerMask();
            }
        }
    }
}
