using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    [Header("Object For Camera To Follow")]
    public GameObject GameObjectToFollow;

    [Header("Level Boundry")]
    public GameObject Boundry;
	
	public float CameraSize;
	
    private bool AllowLeftMovement = true;

    private float MinX;
    private float MaxX;
    private float MinY;
    private float MaxY;
	private float _cameraHeight;
    private float CameraRatio = 16 / 9;

	// Use this for initialization
	void Start () {
		_cameraHeight = CameraSize * 2;
        MinX = (Boundry.transform.position.x - (Boundry.transform.localScale.x / 2)) + ((_cameraHeight / 2) * CameraRatio);
        MaxX = (Boundry.transform.position.x + (Boundry.transform.localScale.x / 2)) - ((_cameraHeight / 2) * CameraRatio);
        MinY = (Boundry.transform.position.y - (Boundry.transform.localScale.y / 2)) + (_cameraHeight / 2);
        MaxY = (Boundry.transform.position.y + (Boundry.transform.localScale.y / 2)) - (_cameraHeight/2);
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
