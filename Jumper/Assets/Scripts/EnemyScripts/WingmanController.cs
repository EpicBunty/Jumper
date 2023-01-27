using UnityEngine;

public class WingmanController : MonoBehaviour
{

    [SerializeField] private float movespeed, directionX, directionY, flyDistance;
    [SerializeField] private bool TouchingGround;
    [SerializeField] private Vector3 currentPos, startPos;

    private void Awake()
    {
        TouchingGround = false;
        startPos = transform.position;
        currentPos = startPos;
        RandomizeDirection();
        //transform.Translate(RandomValue(-1, 1) * Time.deltaTime * movespeed, RandomValue(-1, 1) * Time.deltaTime * movespeed, 0);
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
        if (transform.position.x >= startPos.x + flyDistance || transform.position.x <= startPos.x - flyDistance || transform.position.y >= startPos.y + flyDistance || transform.position.y <= startPos.y - flyDistance || (TouchingGround))
        {
            RandomizeDirection();
            //startPos = transform.position;
            TouchingGround = false;

        }
    }

    private void LateUpdate()
    {
        transform.Translate(directionX * Time.deltaTime * movespeed, directionY * Time.deltaTime * movespeed, 0);
    }

   /* private int RandomValue(int min, int max)
    {
        return Random.Range(min, max);
    }*/
    private void RandomizeDirection()
    {

        directionX = Random.Range(-1, 2);//RandomValue(-1, 2);
        directionY = Random.Range(-1, 2);

        if (directionX == 0 && directionY == 0)
        {
            RandomizeDirection();
        }
    }
}
