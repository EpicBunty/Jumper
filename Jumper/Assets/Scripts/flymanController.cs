using UnityEngine;

public class FlymanController : MonoBehaviour
{
    Animator animator;
    Collider2D coll;
    Rigidbody2D rb2d;

    [SerializeField] private float movespeed, direction;
    [SerializeField] private float flyDistance;
    [SerializeField] private bool TouchingGround;
    [SerializeField] private Vector3 currentPos, startPos;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        TouchingGround = false;
        startPos = transform.position;
        direction = 1;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            TouchingGround = true;
            // Debug.Log("touching ground");
        }

    }

    private void Update()
    {
        //        TakeOff();
        if (transform.position.y >= startPos.y + 10 || (TouchingGround))
        {
            TouchingGround = false;
            direction *= -1;
            Debug.Log("limit Reached");
            animator.SetFloat("movespeed", transform.position.y);

        }
        // transform.Translate(0, movespeed*Time.deltaTime * direction, 0);
    }

    private void LateUpdate()
    {
        transform.Translate(0, movespeed * Time.deltaTime * direction, 0);
    }

    private void TakeOff()
    {
        Vector3 move = transform.position;
        move.y = move.y + movespeed * Time.deltaTime;
        transform.position = move;
    }
}
