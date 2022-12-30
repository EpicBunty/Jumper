using UnityEngine;

public class flymanController : MonoBehaviour
{
    Animator animator;
    Collider2D coll;
    Rigidbody2D rb2d;

    [SerializeField] private float movespeed;
    [SerializeField] private float flyDistance;
    [SerializeField] private bool ReverseDirection;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        ReverseDirection = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ReverseDirection = true;
            Debug.Log("touching ground");
        }
    }
   

    void Update()
    {
        TakeOff();
        if ( (ReverseDirection) || (transform.position.y >= flyDistance))
        {
            Debug.Log("direction reversed");
            ReverseDirection = false;
            movespeed = -movespeed;
            //TakeOff();
        }
        animator.SetFloat("movespeed", movespeed);
    }

    private void TakeOff()
    {
        Vector3 move = transform.position;
        move.y = move.y + movespeed * Time.deltaTime;
        transform.position = move;
    }
}
