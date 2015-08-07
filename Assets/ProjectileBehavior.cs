using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour {

	public float speed;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += transform.up * speed * Time.timeScale * Time.deltaTime;
	}
}
