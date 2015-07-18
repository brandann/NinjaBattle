using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject Hearts;
    public int PlayerNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool GainHeart()
    {
        var ph = Hearts.GetComponent<PlayerHeartManager>();
        return ph.GainHeart();

    }
}
