using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class JetpackPowerUp : MonoBehaviour
{

    [SerializeField] PlayerController playerController;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //SoundManager.Instance.Play(Sounds.Collectible);
            //UItextcontroller.ScoreIncrement(10);
            gameObject.SetActive(false);
            playerController.jetpackEnabled = true;
        }
    }
}
