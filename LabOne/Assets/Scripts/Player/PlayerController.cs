using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private InputReader input;

    void Start()
    {
        input = FindObjectOfType<InputReader>();
    }

    void Update()
    {
        Vector3 move = new Vector3(input.Horizontal, 0, input.Vertical);
        transform.Translate(move * speed * Time.deltaTime);
    }
}