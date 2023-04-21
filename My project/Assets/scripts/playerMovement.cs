

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed1;
    [SerializeField] private float fly;

    [SerializeField] private LayerMask grouundLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    public bool disableMovememnt = false;
   // public float pushBack;
    
    private float direction = 1f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Debug.Log("damn");
       
        

    }


     void FixedUpdate()
    {
        if (!disableMovememnt)
        {
            MovePlayer();
        }


    }

    void MovePlayer()
    {
        

        body.velocity = new Vector2(horizontalInput * speed1, body.velocity.y);


        //flip
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.06114f, 0.06411367f, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.06114f, 0.06411367f, 1);


        if (Input.GetKey(KeyCode.Space) && isGrounded())

            Jump();

        anim.SetBool("walk", horizontalInput != 0);
        // first argument is transition and second is the condition
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump()
    {
        anim.SetTrigger("jump");
        body.velocity = new Vector2(body.velocity.x, fly);
       

    }

   public void Deady() //working good but still dying at same position,,,cant move player dk why
    {
        //Vector3 currentPos = transform.position;

        body.velocity = new Vector2(body.velocity.x, fly);
        // body.AddForce(-transform.forward * pushBack, ForceMode2D.Impulse);
   
      //  Debug.Log("hmm");
        //  GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
            float _direction = Mathf.Sign(transform.localScale.x);
            
            direction = _direction;
          //  gameObject.SetActive(true);
           // hit = false;//false
            //boxCollider.enabled = true;

            float localScaleX = transform.localScale.x;
        if (localScaleX > 0)
        {
            direction = 0.07f;
            transform.localScale = new Vector3(direction, 0.07f, 0);
            body.AddForce(new Vector2(-200, 0));
        }
        else if (localScaleX <= -0.06114)
        {
            direction = -0.07f;
            transform.localScale = new Vector3(direction, 0.07f, 0);
            body.AddForce(new Vector2(200, 0));
        }

        
            anim.SetTrigger("dead");
            // transform.position = new Vector3(-2f, -0.3f, 1);
            // currentPos = new Vector3(-12f, -0.3f, 1);
            //  speed1 = 0;
            // fly = 0;
            horizontalInput = 0;
            //gameObject.SetActive(false);



        }

   
    

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }*/

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, grouundLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return isGrounded();
  
    }
}