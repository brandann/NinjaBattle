using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoalItem : MonoBehaviour {

    public AudioSource hit;
    public AudioClip hitSound;
    public GameObject Player1;
    public GameObject Player1Particle;
    public GameObject Player2;
    public GameObject Player2Particle;

    public GameObject Platforms;

    private List<Vector3> Locations;

    public bool small;
    public bool randomLocations;

    private float minDistance;

	// Use this for initialization
	void Start () {

        minDistance = (small) ? 4 : 10;

        Locations = new List<Vector3>();

        if(small)
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

            Locations.Add(new Vector3(-8.5f,9.5f, 0f));
            Locations.Add(new Vector3(8.5f, 9.5f, 0f));

            Locations.Add(new Vector3(0f, 6.5f, 0f));
        }
        Initilize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initilize()
    {
        this.transform.position = Locations[0];
        this.gameObject.SetActive(true);
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
        float delta1 = 0;
        float delta2 = 0;
        while (true)
        {
            var position = Locations[Random.Range(0, Locations.Count)];
            delta1 = (position - Player1.transform.position).magnitude;
            delta2 = (position - Player2.transform.position).magnitude;
            if (delta1 >= minDistance && delta2 >= minDistance)
            {
                this.transform.position = position;
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

    private bool heartisactive = true;
    public GameObject Cage;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(!heartisactive)
        {
            return;
        }
        if (coll.gameObject.tag == "Player")
        {
            hit.PlayOneShot(hitSound);
            var go = coll.gameObject.transform.parent.GetComponent<Player>();
            if(go.GainHeart())
            {
                //destroy platforms
                GameObject.Destroy(Platforms);
                Cage.SetActive(true);
                //destroy other player
                if(go.PlayerNumber == 1)
                {
                    Player2.transform.position = new Vector3(0, -4, 0);
                    //GameObject.Destroy(Player2);
                    GameObject.Destroy(Player1Particle);
                }
                else
                {
                    Player1.transform.position = new Vector3(0, -4, 0);
                    //GameObject.Destroy(Player1);
                    GameObject.Destroy(Player2Particle);
                }
                //destroy heart
                //GameObject.Destroy(this.gameObject);
                //var heartgo = this.gameObject.GetComponent<CircleCollider2D>();
                //heartgo.enabled = false;
                heartisactive = false;
                this.transform.position = new Vector3(0, 14, 0);
                return;
            }
            Move();
        }
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
