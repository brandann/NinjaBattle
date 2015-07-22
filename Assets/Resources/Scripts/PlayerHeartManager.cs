using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHeartManager : MonoBehaviour {

    public List<GameObject> Hearts;
    private int index;

	// Use this for initialization
	void Start () {
        ResetHearts();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetScore()
    {
        return index - 1;
    }

    public bool GainHeart()
    {
        if(index < Hearts.Count)
        {
            Hearts[index].SetActive(true);
            index++;
        }

        if(index >= Hearts.Count)
        {
            //win
            return true;
        }
        return false;
    }

    private void ResetHearts()
    {
        index = 0;
        for (int i = 0; i < Hearts.Count; i++)
        {
            Hearts[i].SetActive(false);
        }
    }
}
