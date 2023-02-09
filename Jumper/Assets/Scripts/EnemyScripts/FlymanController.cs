using UnityEngine;

public class FlymanController : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private float moveSpeed, flyDistance;
    [SerializeField] private bool touchingGround;
    [SerializeField] private Vector3 currentPos, startPos;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        startPos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchingGround = true;
        }
        else touchingGround = false;
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * moveSpeed);


        if (transform.position.y >= startPos.y + flyDistance || (touchingGround) || transform.position.y <= startPos.y - flyDistance)
        {
            startPos = transform.position;
            touchingGround = false;
            moveSpeed = -moveSpeed;
            animator.SetFloat("movespeed", moveSpeed);

        }

    }

}
