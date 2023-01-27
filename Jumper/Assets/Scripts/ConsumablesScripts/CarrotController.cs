using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotController : MonoBehaviour
{
    public HealthController healthController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthController.IncreaseHealth(1);
            gameObject.SetActive(false);
        }
    }
}
