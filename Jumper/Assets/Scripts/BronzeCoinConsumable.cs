using UnityEngine;

public class BronzeCoinConsumable : MonoBehaviour
{

    [SerializeField] private UIcontroller uicontroller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uicontroller.BronzeCoinIncrement(1);
            gameObject.SetActive(false);

        }
    }
}
