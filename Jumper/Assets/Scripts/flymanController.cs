using UnityEngine;

public class FlymanController : MonoBehaviour
{
    Animator animator;

    [SerializeField] private float movespeed, direction, flyDistance;
    [SerializeField] private bool TouchingGround;
    [SerializeField] private Vector3 currentPos, startPos;

    private void Awake()
    {
       // rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        TouchingGround = false;
        startPos = transform.position;
        direction = 1;

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
        if (transform.position.y >= startPos.y + flyDistance || (TouchingGround))
        {
            startPos = transform.position;
            TouchingGround = false;
            direction *= -1;
           // Debug.Log("limit Reached");
            animator.SetFloat("movespeed", transform.position.y);

        }
        // transform.Translate(0, movespeed*Time.deltaTime * direction, 0);
    }

    private void LateUpdate()
    {
        transform.Translate(0, movespeed * Time.deltaTime * direction, 0);
    }

}
