using UnityEngine;
using UnityEngine.UI;

public class StoneBar : MonoBehaviour
{
    [SerializeField] private Inventory playerStone;
    [SerializeField] private Image totalStone;
    [SerializeField] private Image currentStone;

    private void Start()
    {
        totalStone.fillAmount = playerStone.currentStone;
    }
    private void Update()
    {
       currentStone.fillAmount = playerStone.currentStone;
    }
}