using UnityEngine;
using System.Collections;

public class KillPlayerOnTouch : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Player hit: " + coll.gameObject.tag);
            coll.gameObject.SendMessage("KillPlayer", null, SendMessageOptions.RequireReceiver);
        }
    }
}
