using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] PlayerController playerController;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            SoundManager.Instance.Play(Sounds.Collectible);
            gameObject.SetActive(false);
            if (gameObject.CompareTag("WingsPowerup"))
            {
                playerController.WingsEnabled = true;
            }
            else if (gameObject.CompareTag("JetpackPowerup"))
            {
                playerController.JetpackEnabled = true;
            }
        }
    }
}
