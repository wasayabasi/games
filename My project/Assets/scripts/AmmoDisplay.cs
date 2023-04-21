/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{

    public int ammo;
    public bool isFiring;
    public Text ammoDisplay;
    public bool disAllowStone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(disAllowStone)
        ammoDisplay.text = ammo.ToString();
        if(Input.GetKeyDown(KeyCode.Z) && !isFiring && ammo > 0)
        {
            //  isFiring = true;
           // GetComponent<PlayerAttack>().Attack2();
            ammo--;
           // isFiring = false;
        }
    }
}
*/