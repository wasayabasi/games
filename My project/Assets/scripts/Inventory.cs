using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour

{

    [SerializeField] private float startStone;
    public float currentStone { get; private set; }
    Animator anim;
    SpriteRenderer spriteRend;
 private PlayerAttack playerAttackScript;
    public Image StoneImage;
    public Image StoneImage2;
   // public Text ammoDisplay;
   public int ammo;


    // Start is called before the first frame update

    private void Awake()
    {
        currentStone = startStone;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        playerAttackScript = GetComponent<PlayerAttack>();
        StoneImage.gameObject.SetActive(false);
        StoneImage2.gameObject.SetActive(false);
        GetComponent<PlayerAttack>().ammoDisplay.enabled = false;
       
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddStone(float _value)
    {
        anim.SetTrigger("objpick");
        //StartCoroutine(Stronger());
       // StartCoroutine(StoneUI());
       //playerAttackScript.StartCoroutine(playerAttackScript.StoneUI());
       
        currentStone = Mathf.Clamp(currentStone + _value, 0, startStone);
        GetComponent<PlayerAttack>().StoneDisable = true ;
      //  GetComponent<AmmoDisplay>().disAllowStone = true ;
        StoneImage.gameObject.SetActive(true);
        GetComponent<PlayerAttack>().ammoDisplay.enabled = true;
        StoneImage2.gameObject.SetActive(false);
        //StartCoroutine(StoneUI());
    }

   /* private IEnumerator StoneUI()
    {
       
            yield return new WaitForSeconds(4);
        GetComponent<PlayerAttack>().StoneImage.gameObject.SetActive(false);

    }
   */


    public void StoneMinus(float Minus) { }
}
