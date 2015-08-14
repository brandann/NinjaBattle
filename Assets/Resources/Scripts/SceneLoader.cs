using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

    public enum GameScenes { Start, Map, Level0, Level1, Level2}
    public GameScenes GameSceneToLoad;
    public float TransitionTime;

    private bool startloading;
    private float starttime;

	// Use this for initialization
	void Start () {
        startloading = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(startloading)
        {
            if(Time.timeSinceLevelLoad - starttime >= TransitionTime)
            {
                Application.LoadLevel(GameSceneToLoad.ToString());
            }
        }
	}

    public void StartSceneLoad()
    {
        startloading = true;
        starttime = Time.timeSinceLevelLoad;
    }
}
