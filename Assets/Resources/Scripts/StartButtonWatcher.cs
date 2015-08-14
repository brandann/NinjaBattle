using UnityEngine;
using System.Collections;

public class StartButtonWatcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButton("Start"))
        {
            GetComponentInParent<SceneLoader>().StartSceneLoad();
        }
	}
}
