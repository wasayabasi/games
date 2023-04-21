using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareflash : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private bool dead;


    [Header("iFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private float iFrameDuration2;
    [SerializeField] private float numberofflashes;
    private SpriteRenderer spriteRend;



    // Start is called before the first frame update

    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
  /*  void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }
*/
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
           
            //iframes
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
            
                StartCoroutine(Invunerability());
                GetComponent<PlayerMovement>().Deady();
                // transform.localScale = new Vector3(0.07114f, 0.07411367f, 1); //orig script removed by my gen

                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public IEnumerator Invunerability()
        {
       
        Physics2D.IgnoreLayerCollision(7, 16, true);
            for (int i = 0; i < numberofflashes; i++)
            {
                spriteRend.color = new Color(1, 0, 0);
                yield return new WaitForSeconds(iFrameDuration / (numberofflashes * 2));
                spriteRend.color = Color.white;
              //  yield return new WaitForSeconds(iFrameDuration / (numberofflashes * 2));
            }
            Physics2D.IgnoreLayerCollision(7, 16, false);
        }

    
}
