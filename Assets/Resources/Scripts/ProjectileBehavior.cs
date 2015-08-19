using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour {

	public float speed;
	
	private float killstart;
	private float killwait;
	private bool holdwait;
	
	// Use this for initialization
	void Start () {
		holdwait = false;
		killwait = .5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(!holdwait)
		{
			this.transform.position += transform.right * speed * Time.timeScale * Time.deltaTime;
		}
		else
		{
			if(Time.timeSinceLevelLoad - killstart >= killwait)
			{
                GameObject.Destroy(this.gameObject);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag != "projectile")
		{
			holdwait = true;
			killstart = Time.timeSinceLevelLoad;
			var rb2d = GetComponent<BoxCollider2D>();
			rb2d.enabled = false;
			GetComponent<Rigidbody2D>().isKinematic = true;
		}
	}
}
