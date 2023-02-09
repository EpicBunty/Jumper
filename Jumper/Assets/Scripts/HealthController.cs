using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    [SerializeField] private Image[] healthImage;
    [SerializeField] private int maxHealth, playerHealth;

    private void Start()
    {
        playerHealth = maxHealth;
        RefreshHealthUI();
    }

    public void IncreaseHealth(int value)
    {
        playerHealth += value;
        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }
        RefreshHealthUI();
    }

    public void TakeDamage(int Damage)
    {
        playerHealth -= Damage;
        
       if (playerHealth < 1)
        {
            playerHealth = 0;
            playerController.PlayerDead();
        }
        RefreshHealthUI();
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    void RefreshHealthUI()
    {
        for (int i = 0; i < healthImage.Length; i++)
        {
            if (i < playerHealth)
                healthImage[i].gameObject.SetActive(true);
            else
            {
                healthImage[i].gameObject.SetActive(false);
            }
        }
    }

}

