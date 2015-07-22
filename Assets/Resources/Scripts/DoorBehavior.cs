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
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<PlatformerMotor2D>().ToggleLayerMask();
            bool foreground = coll.gameObject.GetComponentInParent<Player>().IsForeground();
            if(foreground)
            {
                coll.gameObject.GetComponent<TrailRenderer>().enabled = false;
                var renderer = coll.gameObject.GetComponentInChildren<SpriteRenderer>();
                var orgcolor = renderer.color;
                var newcolor = new Color(orgcolor.r, orgcolor.g, orgcolor.b, .6f);
                renderer.color = newcolor;
                renderer.sortingOrder = 9;
            }
            else
            {
                coll.gameObject.GetComponent<TrailRenderer>().enabled = true;
                var renderer = coll.gameObject.GetComponentInChildren<SpriteRenderer>();
                var orgcolor = renderer.color;
                var newcolor = new Color(orgcolor.r, orgcolor.g, orgcolor.b, 1);
                renderer.color = newcolor;
                renderer.sortingOrder = 11;
            }
            coll.gameObject.GetComponentInParent<Player>().SetForeground(!foreground);
        }
    }
}
