using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
    
{
    // public float lifetime;
    public float walkspeed;
    public float jumppower;
    public float jumppower2;
    public Sprite punch;
    public Sprite idle;
    public float leanForward;
    public float movedown;
    Vector3 punchInstance;
    // public GameObject objecttospawn;
    //  private SpriteRenderer rend;
    // Start is called before the first frame update
    private void Awake()
    {
       // Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaa");
    }
    void Start()
    {
        //  rend = GetComponent<SpriteRenderer>();
        // rend.color= Color.blue;
        //Instantiate(objecttospawn, Vector3.zero, Quaternion.identity);
       // Debug.Log("sssssssssssssss");
    }

    // Update is called once per frame
    void Update()

    {
        Vector3 playerInput2 = new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        transform.position = transform.position + playerInput.normalized * walkspeed * Time.deltaTime;
        transform.position = transform.position + playerInput2.normalized * jumppower * Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            jumppower = 0;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumppower = jumppower2;
        }

        if (Input.GetKeyDown(KeyCode.B)) //GetKeyDown
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = punch;
            punchInstance = transform.position;
            punchInstance.x += leanForward;
            transform.position = punchInstance;
           /* if (Input.GetKeyUp(KeyCode.B))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = punch;
                punchInstance = transform.position;
                punchInstance.x -= leanForward;
                transform.position = punchInstance;
            }
           /* else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = punch;
                punchInstance = transform.position;
                punchInstance.x -= leanForward;
                transform.position = punchInstance;
            }*/

        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idle;
            punchInstance = transform.position;
            punchInstance.x -= leanForward;
            transform.position = punchInstance;
        }
        // Destroy(gameObject, lifetime);

       
       // Debug.Log("uuuuuuuuuuuuuuuu");
    }
     void LateUpdate()
    {
        //Debug.Log("lullululuuluullluluululululul");
    }
     void FixedUpdate()
    {
        /* if (Input.GetKeyDown(KeyCode.B)) //GetKeyDown
      {
          this.gameObject.GetComponent<SpriteRenderer>().sprite = punch;
          punchInstance = transform.position;
          punchInstance.x += no;
          transform.position = punchInstance;


      }*/
        // Debug.Log("fuufufufufuffuffuufuf");
    }
}
