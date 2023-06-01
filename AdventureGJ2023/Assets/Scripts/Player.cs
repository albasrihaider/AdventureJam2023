using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float shootHorizontal = Input.GetAxis("Shoot Sideways");
        float shootVertical = Input.GetAxis("Shoot Up");

        rigidbody.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
