
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Helth playerHealth;
    [SerializeField] private Image toatalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        toatalhealthBar.fillAmount = playerHealth.currentHealth / 10;

    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

}
