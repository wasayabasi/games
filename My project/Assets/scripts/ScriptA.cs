using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScrptA : MonoBehaviour
{
    public int stonesInInventory = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && stonesInInventory > 0)
        {
            // Throw the stone here

            stonesInInventory--;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "stone")
        {
            ScriptB stone = collision.GetComponent<ScriptB>();
            stonesInInventory += stone.stonesInInventory;
            stone.stonesInInventory = 0;
        }
    }
}