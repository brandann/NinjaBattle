using UnityEngine;
using System.Collections;

public class FanRotation : MonoBehaviour {

    public int RotationDirection;
    public float RotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0, 0, -1 * RotationDirection * RotationSpeed * Time.deltaTime));
	}
}
