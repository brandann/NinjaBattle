using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    [Header("Object For Camera To Follow")]
    public GameObject GameObjectToFollow;

    [Header("Level Boundries")]
    public GameObject PlatformLeft;
    public GameObject PlatformRight;
    public GameObject PlatformBottom;
    public GameObject PlatformTop;

    [Header("Controls")]
    public bool AllowLeftMovement;

    private float MinX;
    private float MaxX;
    private float MinY = 5;
    private float MaxY = 100;
	// Use this for initialization
	void Start () {
        MinX = PlatformLeft.transform.position.x + 17.77777777777778f;
        MaxX = PlatformRight.transform.position.x - 17.77777777777778f;
        MinY = PlatformBottom.transform.position.y + 10;
        MaxY = PlatformTop.transform.position.y - 10;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void LateUpdate()
    {
        float X = Mathf.Clamp(GameObjectToFollow.transform.position.x + 5.925926f, MinX, MaxX);
        float Y = Mathf.Clamp(GameObjectToFollow.transform.position.y, MinY, MaxY);
        this.transform.position = new Vector3(X, Y, -10);

        if(!AllowLeftMovement)
        {
            MinX = this.transform.position.x;
        }

    }
}
