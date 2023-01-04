using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    Collider2D coll;

    [SerializeField] private float jumpforce, jumpheldforce, speed;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private GameObject[] Wings;
    private float horizontal;
    [SerializeField] private bool jumpPressed, jumpHeld;
    public bool wingsEnabled;


    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        wingsEnabled = false;
    }


    private void InputsAndAnimations()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
        jumpHeld = Input.GetKey(KeyCode.Space);

        animator.SetFloat("y_velocity", rb2d.velocity.y);
        animator.SetFloat("x_velocity", rb2d.velocity.x);
        animator.SetBool("onground", OnGround());
        animator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void RunAndFlip()
    {
        if (horizontal != 0)
        {

            Vector2 position = transform.position;
            position.x = position.x + horizontal * speed * Time.deltaTime;
            transform.position = position;
            /*if (SoundManager.Instance.soundEffect.isPlaying == false)
            {
                SoundManager.Instance.Play(Sounds.PlayerMove);
            }*/

            Vector2 scale = transform.localScale;
            if (scale.x != horizontal)
            {
                scale.x = horizontal;
                transform.localScale = scale;
            }
        }
    }

    private void JumpPress()
    {
        if (OnGround())
        {
            if (jumpPressed)
            {
                rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            }
        }
    }

    private void JumpHold()
    {
        if (wingsEnabled)
        {
            if (jumpHeld)
            {
                rb2d.AddForce(new Vector2(0, jumpheldforce), ForceMode2D.Force);
                //jumpholdParticle.Play();
                Wings[1].SetActive(true); Wings[0].SetActive(true);
            }
            else { Wings[1].SetActive(false); Wings[0].SetActive(false); }

        }
    }

    void Update()
    {
        InputsAndAnimations();
        RunAndFlip();
        JumpPress();
    }

    private void FixedUpdate()
    {
        JumpHold();
    }

    private bool OnGround()
    {
        //RaycastHit2D raycastHit = 
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    /*private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wings"))
        {
            wingsEnabled = true;
            //collision.gameObject.SetActive(false);
        }
    }*/

}
