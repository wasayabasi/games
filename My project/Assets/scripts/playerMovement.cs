
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float walk;
    private Rigidbody2D body;

  


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Vertical") * speed, body.velocity.y);
        body.velocity = new Vector2(Input.GetAxis("Vertical") * speed, body.velocity.y);
        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.y, speed);
        }

       
        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity = new Vector2(body.velocity.x, walk);
        }
    }
}
