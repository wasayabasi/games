using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackCooldown2;
    [SerializeField] private Transform firepoint;
    [SerializeField] public GameObject[] stones;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
   // public Inventory inventory;
    public bool StoneDisable = false;
    public int ammoNum;
    public Text ammoDisplay;

    private void Awake()
    {
        anim = GetComponent<Animator>();
//        inventory = GetComponent<Inventory>();
        playerMovement = GetComponent<PlayerMovement>();
      //  ammoDisplay.enabled = true;
       
    }

    private void Update()
    {
        
       ammoDisplay.text = ammoNum.ToString();
        if (Input.GetKey(KeyCode.B) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack1();
            
        }
        if(Input.GetKey(KeyCode.C) && GetComponent<Inventory>().ammo > 0 && cooldownTimer > attackCooldown2 && playerMovement.canAttack())
        {
           
            //
            if (StoneDisable)
            {
               
                StartCoroutine(StoneUI());
                Attack2();
          
               GetComponent<Inventory>().ammo--;
              ammoNum--;
               
            }
        }

        if (GetComponent<Inventory>().ammo == 0)
        {
          //  ammoDisplay.enabled = false;
            GetComponent<Inventory>().StoneImage2.gameObject.SetActive(false);
            GetComponent<Inventory>().StoneImage.gameObject.SetActive(false);
           ammoDisplay.enabled = false;
        }
      
        // updates the time in every frame
        cooldownTimer += Time.deltaTime;
    }


    public IEnumerator StoneUI()
   {
        GetComponent<Inventory>().StoneImage2.gameObject.SetActive(true);
      //  ammoDisplay.enabled = true;
        yield return new WaitForSeconds(3);
        GetComponent<Inventory>().StoneImage2.gameObject.SetActive(false);

   }
  

    private void Attack1()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }
   public void Attack2()
    {

        //GetComponent<Inventory>.AddStone().currentStone = null;
      

        anim.SetTrigger("throw");
        cooldownTimer = 0;
       // GetComponent<AmmoDisplay>().isFiring = true;  //
        //stones[FindStone()].transform.position = firepoint.position;
        stones[0].transform.position = firepoint.position;
        stones[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        GetComponent<Inventory>().StoneImage2.gameObject.SetActive(true);
        GetComponent<Inventory>().StoneImage.gameObject.SetActive(true);
      
        //GetComponent<AmmoDisplay>().isFiring = false; //
    }
   
    /*private int FindStone()
    {
        for (int i = 0; i < stones.Length; i++)
        {
            if (!stones[i].activeInHierarchy)
                return i;
        }
        return 0;
    }*/
}

