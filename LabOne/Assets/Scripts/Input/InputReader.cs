using UnityEngine;

public class InputReader : MonoBehaviour
{
    public Joystick movementJoystick;

    public float Horizontal => movementJoystick.Horizontal;
    public float Vertical => movementJoystick.Vertical;
}