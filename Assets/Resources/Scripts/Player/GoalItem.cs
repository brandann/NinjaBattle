﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoalItem : MonoBehaviour {

    [Header("Players")]
    public GameObject Player1;
    public GameObject Player2;

    [Header("Audio")]
    public AudioSource hit;
    public AudioClip hitSound;

    [Header("HeatOptions")]
    public bool small;
    public bool randomLocations;
    public bool SlowDownActive;

    #region Private Members
    private float minDistance;
    private Global global;
    private bool heartisactive = true;
    private bool foreground = false;
    private List<Vector3> Locations;
    private Vector3 initialLocation;
    #endregion

    // Use this for initialization
	void Start () {

        global = GameObject.Find("Global").GetComponent<Global>();
        goals = new List<GoalLocations>();
        minDistance = (small) ? 4 : 10;

        Locations = new List<Vector3>();

        //FillLocations(small);
        
        //Initilize();

        this.gameObject.SetActive(false);
	}

    private void FillLocations(bool sm)
    {
        if (small)
        {
            Locations.Add(new Vector3(0f, .25f, 0f));
            Locations.Add(new Vector3(-4f, 2.25f, 0f));
            Locations.Add(new Vector3(4f, 2.25f, 0f));
            Locations.Add(new Vector3(-5.5f, -3f, 0f));
            Locations.Add(new Vector3(5.5f, -3f, 0f));
        }
        else
        {
            Locations.Add(new Vector3(0f, 11.5f, 0f));

            Locations.Add(new Vector3(-13f, -3f, 0f));
            Locations.Add(new Vector3(13f, -3f, 0f));

            Locations.Add(new Vector3(-2f, -3f, 0f));
            Locations.Add(new Vector3(2f, -3f, 0f));

            Locations.Add(new Vector3(-13.75f, 6.5f, 0f));
            Locations.Add(new Vector3(13.75f, 6.5f, 0f));

            Locations.Add(new Vector3(-8.5f, 9.5f, 0f));
            Locations.Add(new Vector3(8.5f, 9.5f, 0f));

            Locations.Add(new Vector3(0f, 6.5f, 0f));
        }
    }
	
	// Update is called once per frame
    public float ProximtiyRadius;
	void Update () {

        if (SlowDownActive)
        {
            var PlayerPosition1 = Player1.transform.position;
            var PlayerPosition2 = Player2.transform.position;
            var HeartPosition = this.transform.position;
            var Magnitude1 = (PlayerPosition1 - HeartPosition).magnitude;
            var Magnitude2 = (PlayerPosition2 - HeartPosition).magnitude;
            var Magnitude = (Magnitude1 <= Magnitude2) ? Magnitude1 : Magnitude2;
            var Distance = Magnitude / ProximtiyRadius;
            Distance = Mathf.Clamp(Distance, 0.3f, ProximtiyRadius);
            //Time.timeScale = Distance / ProximtiyRadius;
            Player1.GetComponent<PlatformerMotor2D>().timeScale = Distance / ProximtiyRadius;
        }
        else
        {
            Time.timeScale = 1;
        }
        
	}

    public void Initilize()
    {
        //this.transform.position = Locations[0];
        for(int i = 0; i < goals.Count; i++)
        {
            if(goals[i].initial)
            {
                this.transform.position = goals[i].position;
                this.gameObject.SetActive(true);
                return;
            }
        }
        //this.gameObject.SetActive(true);
    }

    public void Move()
    {
        if(randomLocations)
        {
            MoveRandom();
            return;
        }

        float LargestDistance = 0;
        int indexoflargest = 0;

        List<Distance> Distances = GetDistance();

        for (int i = 0; i < Distances.Count; i++ )
        {
            if (Distances[i].Sum >= LargestDistance)
            {
                LargestDistance = Distances[i].Sum;
                indexoflargest = i;
            }
        }

        this.transform.position = Locations[indexoflargest];
    }

    private void MoveRandom()
    {
        if (initialLocation != Vector3.zero)
        {
            this.transform.position = initialLocation;
            initialLocation = Vector3.zero;
            return;
        }

        float delta1 = 0;
        float delta2 = 0;
        while (true)
        {
            int index = Random.Range(0, goals.Count);
            var position = goals[index].position;
            delta1 = (position - Player1.transform.position).magnitude;
            delta2 = (position - Player2.transform.position).magnitude;
            if (delta1 >= minDistance && delta2 >= minDistance)
            {
                this.transform.position = position;
                goals.RemoveAt(index);
                return;
            }
        }
        
    }

    private List<Distance> GetDistance()
    {
        Vector3 Player1Location = Player1.transform.position;
        Vector3 Player2Location = Player2.transform.position;
        List<Distance> Distances = new List<Distance>();

        for (int i = 0; i < Locations.Count; i++)
        {
            Distance d = new Distance();

            d.Index = i;
            d.Player1Distance = (Locations[i] - Player1Location).magnitude;
            d.Player2Distance = (Locations[i] - Player2Location).magnitude;
            d.Sum = d.Player1Distance + d.Player2Distance;
            d.Average = d.Sum / 2f;
            d.Difference = Mathf.Abs(d.Player1Distance - d.Player2Distance);
            Distances.Add(d);
        }

        return Distances;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(!heartisactive)
        {
            return;
        }

        if (coll.gameObject.tag == "Player")
        {
            var go = coll.gameObject.transform.parent.GetComponent<Player>();
            if(go.IsForeground() == foreground)
            {
                hit.PlayOneShot(hitSound);

                if (go.GainHeart())
                {
                    global.CurrentGameState = Global.GameState.End;
                    return;
                }
                Move();
            }
            
        }
    }

    public void SetColliderActive(bool b)
    {
        heartisactive = b;
        SlowDownActive = b;
    }

    List<GoalLocations> goals;
    public void SetSpawnLocations(Vector3 position, bool fore, bool first)
    {
        GoalLocations gl = new GoalLocations();
        gl.position = position;
        gl.foreground = fore;
        gl.initial = first;

        goals.Add(gl);
    }

    private sealed class GoalLocations
    {
        public Vector3 position;
        public bool foreground = false;
        public bool initial = false;
    }

    private sealed class Distance
    {
        public int Index;
        public float Player1Distance;
        public float Player2Distance;
        public float Sum;
        public float Average;
        public float Difference;
        public float GetDistanceCalc() { return Sum - Difference; }
    }
}