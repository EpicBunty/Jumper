using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteMenu;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("collided with portal");
            LevelManager.Instance.LevelComplete();
            levelCompleteMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
