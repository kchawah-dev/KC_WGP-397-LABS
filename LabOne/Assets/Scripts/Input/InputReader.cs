using UnityEngine;

public class InputReader : MonoBehaviour
{
    public float Horizontal => Input.GetAxis("Horizontal");
    public float Vertical => Input.GetAxis("Vertical");
}