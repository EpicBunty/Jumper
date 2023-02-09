using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotController : MonoBehaviour
{
    [SerializeField] private HealthController healthController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            SoundManager.Instance.Play(Sounds.Collectible);
            healthController.IncreaseHealth(1);
            gameObject.SetActive(false);
        }
    }
}
