using UnityEngine;
using System.Collections;

public class StartingTimer : MonoBehaviour {

    private Global global;
    private float starttime;
	// Use this for initialization
	void Start () {
        global = GameObject.Find("Global").GetComponent<Global>();
        starttime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.timeSinceLevelLoad - starttime >= 5)
        {
            //global.CurrentGameState = Global.GameState.Game;
        }

        if(Input.GetAxis("Start") == 1)
        {
            global.CurrentGameState = Global.GameState.Game;
        }
	}
}
