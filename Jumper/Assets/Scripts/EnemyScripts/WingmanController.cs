using UnityEngine;

public class WingmanController : MonoBehaviour
{

    [SerializeField] private float movespeed, directionX, directionY, flyDistance;
    [SerializeField] private bool TouchingGround;
    [SerializeField] private Vector3 startPos;

    private void Awake()
    {
        TouchingGround = false;
        startPos = transform.position;
        //currentPos = startPos;
        RandomizeDirection();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            TouchingGround = true;
        }
    }

    private void Update()
    {
        // if it flies further than fly distance from starting position
        if ((transform.position.x > startPos.x + flyDistance) || (transform.position.x < startPos.x - flyDistance) || (transform.position.y > startPos.y + flyDistance) || (transform.position.y < startPos.y - flyDistance)
            || (TouchingGround))
        {
            RandomizeDirection();
            TouchingGround = false;

        }

        transform.Translate(directionX * Time.deltaTime * movespeed, directionY * Time.deltaTime * movespeed, 0);
    }

    private void RandomizeDirection()
    {
        directionX = Random.Range(-1, 2);
        directionY = Random.Range(-1, 2);
        if (directionX == 0 && directionY == 0)
        { 
        directionX = Random.Range(-1, 2);
        directionY = Random.Range(-1, 2);
        }
    }
}
