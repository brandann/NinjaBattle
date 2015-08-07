using UnityEngine;
using System.Collections;

public class GoalSpawner : MonoBehaviour {

    public bool initial;
    public bool foreground;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        var goal = GameObject.Find("heart");
        
        if(null != goal)
        {
            var goalObject = goal.GetComponent<GoalItem>();
            goalObject.SetSpawnLocations(this.transform.position, foreground, initial);
            GameObject.Destroy(this.gameObject);
        }
    }
}
