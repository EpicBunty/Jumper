using UnityEngine;

public class FlymanController : MonoBehaviour
{
    Animator animator;

    [SerializeField] private float movespeed, flyDistance;
    [SerializeField] private bool TouchingGround;
    [SerializeField] private Vector3 currentPos, startPos;

    private void Awake()
    {
        // rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       // TouchingGround = false;
        startPos = transform.position;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            TouchingGround = true;
        }
        else TouchingGround = false;
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * movespeed);


        if (transform.position.y >= startPos.y + flyDistance || (TouchingGround) || transform.position.y <= startPos.y - flyDistance)
        {
            startPos = transform.position;
            TouchingGround = false;

            movespeed = -movespeed;
            //transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * movespeed);
            animator.SetFloat("movespeed", movespeed);

        }

    }

    private void LateUpdate()
    {

        // transform.Translate(0, movespeed * Time.deltaTime, 0);
    }

}
