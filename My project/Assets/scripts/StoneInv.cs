using UnityEngine;

public class StoneInv : MonoBehaviour
{
    private const string StoneCountKey = "StoneCount";
    private int stoneCount = 0;

    void Awake()
    {
        stoneCount = PlayerPrefs.GetInt(StoneCountKey, 0);
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt(StoneCountKey, stoneCount);
        PlayerPrefs.Save();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("stone"))
        {
            stoneCount++;
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && stoneCount > 0)
        {
            // Throw the stone
            stoneCount--;
        }
    }
}
