using UnityEngine;

public class ScriptB : MonoBehaviour
{
    public int stonesInInventory = 0;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "player")
        {
            stonesInInventory++;
            Destroy(gameObject);
        }
    }
}
