using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject levelcompleteMenu;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            Debug.Log("collided with portal");
            LevelManager.Instance.LevelComplete();
            levelcompleteMenu.SetActive(true);
            //Time.timeScale = 0;
        }
    }
}
