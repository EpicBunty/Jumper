using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    [SerializeField] private Image[] health;
    // [SerializeField] private Sprite emptyheartsprite;
    [SerializeField] private int MaxHealth, PlayerHealth;
    [SerializeField] PlayerController playerController;

    private void Start()
    {
        PlayerHealth = MaxHealth;
        RefreshHealthUI();
    }

    public void TakeDamage(int Damage)
    {
        playerController.gameObject.GetComponent<Animator>().SetTrigger("tookdamage");
        PlayerHealth -= Damage;
        //SoundManager.Instance.Play(Sounds.PlayerTakeDamage);
        RefreshHealthUI();


        if (PlayerHealth > MaxHealth)
        {
            PlayerHealth = MaxHealth;
        }
        else if (PlayerHealth < 1)
        {
            PlayerHealth = 0;
            playerController.PlayerDead();
        }
        Debug.Log("player health = " + PlayerHealth);
    }

    public int GetPlayerHealth()
    {
        return PlayerHealth;
    }

    void RefreshHealthUI()
    {
        for (int i = 0; i < health.Length; i++)
        {
            if (i < PlayerHealth)
                health[i].gameObject.SetActive(true);
            else
            {
                health[i].gameObject.SetActive(false);
            }
        }
    }

}

