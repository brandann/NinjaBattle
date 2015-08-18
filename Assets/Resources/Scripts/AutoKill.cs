using UnityEngine;
using System.Collections;

public class AutoKill : MonoBehaviour {

    public float WaitTime;
    float starttime;

	// Use this for initialization
	void Start () {
        starttime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad - starttime > WaitTime)
        {
            GameObject.Destroy(this.gameObject);
        }
	}
}
