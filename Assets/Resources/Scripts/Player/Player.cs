using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    public GameObject Hearts;
    public int PlayerNumber;
    private bool foreground = true;
    private GameObject Spawnpoint;

	// Use this for initialization
	void Start () {
        Spawnpoint = GameObject.Find("SpawnPoint");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool GainHeart()
    {
        var ph = Hearts.GetComponent<PlayerHeartManager>();
        return ph.GainHeart();
    }

    public bool IsForeground()
    {
        return foreground;
    }

    public void SetForeground(bool isforeground)
    {
        foreground = isforeground;
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
