using UnityEngine;
using UnityEngine.UI;

public class StoneCollectible : MonoBehaviour
{
    //public GameObject PlayerAttack;
  

    //public Text ammoDisplay;
    [SerializeField] private float StoneValue;



    private void Awake()
    {
        //GetComponent<PlayerAttack>().ammoDisplay.enabled = false;
        //   PlayerAttack attackScript = GetComponent<PlayerAttack>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "player")
        {
            
         // GetComponent<PlayerAttack>().ammoDisplay.text = ammoNum.ToString();
            //ammoDisplay.text = ammo.ToString();
            //GetComponent<Inventory>().ammoDisplay.text = GetComponent<Inventory>().ammo.ToString();
            collision.GetComponent<Inventory>().AddStone(StoneValue);
           // ammoDisplay.text = attackScript.ammo.ToString();
            //GetComponent<PlayerAttack>().StoneDisable = true;
            gameObject.SetActive(false);
          //   ammoNum--;
        }
        //GetComponent<PlayerAttack>().ammoDisplay.enabled = false;
    }
}