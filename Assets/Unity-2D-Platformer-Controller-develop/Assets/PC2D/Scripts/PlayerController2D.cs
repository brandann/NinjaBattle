
using UnityEngine;

/// <summary>
/// This class is a simple example of how to build a controller that interacts with PlatformerMotor2D.
/// </summary>
[RequireComponent(typeof(PlatformerMotor2D))]
public class PlayerController2D : MonoBehaviour
{
    private PlatformerMotor2D _motor;
    public string PlayerNumberID;

    // Use this for initialization
    void Start()
    {
        _motor = GetComponent<PlatformerMotor2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis(PC2D.Input.HORIZONTAL + PlayerNumberID)) > PC2D.Globals.INPUT_THRESHOLD)
        {
            _motor.normalizedXMovement = Input.GetAxis(PC2D.Input.HORIZONTAL + PlayerNumberID);
        }
        else
        {
            _motor.normalizedXMovement = 0;
        }

        // Jump?
        if (Input.GetButtonDown(PC2D.Input.JUMP + PlayerNumberID))
        {
            _motor.Jump();
        }

        _motor.jumpingHeld = Input.GetButton(PC2D.Input.JUMP + PlayerNumberID);

        if (Input.GetAxis(PC2D.Input.VERTICAL + PlayerNumberID) < -PC2D.Globals.FAST_FALL_THRESHOLD)
        {
            _motor.fallFast = true;
        }
        else
        {
            _motor.fallFast = false;
        }

        if (Input.GetButtonDown(PC2D.Input.DASH + PlayerNumberID))
        {
            _motor.Dash();
        }
    }
}
