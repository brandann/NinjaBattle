using UnityEngine;
using System.Collections;

public class ShootSpawner : MonoBehaviour {

	public GameObject projectileObject;
	public float Frequency;
	
	float starttime;
	
	// Use this for initialization
	void Start () {
		starttime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad - starttime > Frequency)
		{
			var go = Instantiate(projectileObject);
			go.transform.position = this.transform.position;
			go.transform.up = this.transform.up;
			starttime = Time.timeSinceLevelLoad;
		}
	}
}
