using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private float iFrameDuration2;
    [SerializeField] private float numberofflashes;
    private SpriteRenderer spriteRend;
    public Image avatar;
    //public PlayerAttack playerAttackScript;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
      //  playerAttackScript = GetComponent<PlayerAttack>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0 && currentHealth !=3)
        {
            anim.SetTrigger("hurt");
           // Debug.Log("hurted");
            //iframes
            StartCoroutine(Invunerability());
             
            

        }

       
        else
        {
            if (!dead)
            {
                if (currentHealth == 3)
                {
                    //   Debug.Log("butthurted");

                    anim.SetTrigger("butthurt");

                    //iframes
                    StartCoroutine(DamageDelay());
                    StartCoroutine(Invunerable());
                    
                    // playerAttackScript.enabled = false;

                }
                else
                {

                    anim.SetTrigger("dead");
                    StartCoroutine(Invunerability2());
                    GetComponent<PlayerMovement>().Deady();
                    // transform.localScale = new Vector3(0.07114f, 0.07411367f, 1); //orig script removed by my gen

                    GetComponent<PlayerMovement>().enabled = false;
                    GetComponent<PlayerAttack>().enabled = false;
                    dead = true;
                }
            }
        }
    }
    public void AddHealth(float _value)
    {
        anim.SetTrigger("objpick");
        StartCoroutine(Stronger());
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
           TakeDamage(1);

  }


    public IEnumerator Stronger()
    {
       


        for (int i = 0; i < numberofflashes; i++)
        {
            spriteRend.color = new Color(0, 1, 0);
            avatar.color = Color.green;
            yield return new WaitForSeconds(iFrameDuration / (numberofflashes * 2));
            spriteRend.color = Color.white;
            avatar.color = Color.white;
            // yield return new WaitForSeconds(iFrameDuration / (numberofflashes * 2));
            //   yield return new WaitForSeconds(5);
            
        }
        Physics2D.IgnoreLayerCollision(7, 16, false);

    }


    public IEnumerator Invunerability()
    {
        //GetComponent<PlayerMovement>().disableMovememnt= true;
       
        Physics2D.IgnoreLayerCollision(7, 16, true);
        
        for (int i = 0; i < numberofflashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0);
            avatar.color = Color.red;
            yield return new WaitForSeconds(iFrameDuration / (numberofflashes * 2));
            spriteRend.color = Color.white;
            avatar.color = Color.white;
            // yield return new WaitForSeconds(iFrameDuration / (numberofflashes * 2));
         //   yield return new WaitForSeconds(5);
           GetComponent<PlayerMovement>().disableMovememnt = false;
        }
        Physics2D.IgnoreLayerCollision(7, 16, false);
        
    }

    public IEnumerator DamageDelay()
    {
        GetComponent<PlayerAttack>().enabled = false;
        yield return new WaitForSeconds(2.5f);
        GetComponent<PlayerAttack>().enabled = true;
    }
    public IEnumerator Invunerable()
    {
        GetComponent<PlayerMovement>().disableMovememnt = true;
        Physics2D.IgnoreLayerCollision(7, 16, true);

        for (int i = 0; i <1; i++)
        {
            spriteRend.color = new Color(1, 0, 0);
            avatar.color = Color.red;
           // yield return new WaitForSeconds(2.5f);
              yield return new WaitForSeconds(iFrameDuration / (numberofflashes * 2));
            spriteRend.color = Color.white;
            avatar.color = Color.white;
          
            yield return new WaitForSeconds(2.35f);
            GetComponent<PlayerMovement>().disableMovememnt = false;
        }
     
        Physics2D.IgnoreLayerCollision(7, 16, false);

    }


    private IEnumerator Invunerability2()
    {
        Physics2D.IgnoreLayerCollision(7, 16, true);
        for (int i = 0; i < numberofflashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0);
            avatar.color = Color.red;
            yield return new WaitForSeconds(iFrameDuration2 / (numberofflashes * 9));
            //spriteRend.color = Color.white;
           // avatar.color = Color.white;
            //yield return new WaitForSeconds(iFrameDuration2 / (numberofflashes * 9));
        }
        Physics2D.IgnoreLayerCollision(7, 16, false);
    }

}

