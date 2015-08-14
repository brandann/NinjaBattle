using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    public int PlayerNumber;
    private GameObject Spawnpoint;

	// Use this for initialization
	void Start () {
        Spawnpoint = GameObject.Find("SpawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void KillPlayer()
    {
        Respawn();
        if (null != OnPlayerDeath)
            OnPlayerDeath();
    }

    private void Respawn()
    {
        gameObject.transform.position = Spawnpoint.transform.position;
    }
}
