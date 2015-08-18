using UnityEngine;
using System.Collections;

public class ShootSpawner : MonoBehaviour {

	public GameObject projectileObject;
	public float Frequency;
    private float WaitTime;
    public bool randomize;
	
	float starttime;
	
	// Use this for initialization
	void Start () {
		starttime = Time.timeSinceLevelLoad;
        if (randomize)
        {
            WaitTime = Frequency * (Random.Range(1, 200) / 100f);
        }
        else
        {
            WaitTime = Frequency;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad - starttime > WaitTime)
		{
			var go = Instantiate(projectileObject);
			go.transform.position = this.transform.position;
            go.transform.rotation = this.transform.rotation;
			//go.transform.up = this.transform.up;
            if(randomize)
            {
                WaitTime = Frequency * (Random.Range(1, 200) / 100f);
            }
            starttime = Time.timeSinceLevelLoad;			
		}
	}
}
