using UnityEngine;


public class BronzeCoinConsumable : MonoBehaviour
{
    [SerializeField] private UiController uiController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            SoundManager.Instance.Play(Sounds.Collectible);
            uiController.BronzeCoinIncrement(1);
            gameObject.SetActive(false);

        }
    }
}

