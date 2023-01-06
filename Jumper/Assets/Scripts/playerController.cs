using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    Collider2D coll;

    [SerializeField] private HealthController healthController;
    [SerializeField] private float jumpforce, jumpheldforce, speed, fuel;
    [SerializeField] private bool jumpPressed, jumpHeld, flyJetpack;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private GameObject Wings1, Wings2, jetPack, jetpackflame, gameoverMenu;
    /*[SerializeField] private Slider fuelmeter;*/
    [SerializeField] private GameObject fuelmeter;
    private float horizontal;
    public bool wingsEnabled, jetpackEnabled;


    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        wingsEnabled = false;
        jetpackEnabled = false;
        fuel = 10;

    }


    private void InputsAndAnimations()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
        jumpHeld = Input.GetKey(KeyCode.Space);
        flyJetpack = Input.GetKey(KeyCode.LeftControl);

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
                Wings1.SetActive(true); Wings2.SetActive(true);
            }
            else { Wings1.SetActive(false); Wings2.SetActive(false); }

        }
    }
    private void JetPack()
    {
        if (jetpackEnabled)
        {
            fuelmeter.gameObject.GetComponentInChildren<Slider>().value = fuel;
            //fuelmeter.value = fuel;

            fuelmeter.SetActive(true);
            jetPack.SetActive(true);

            if (flyJetpack)
            {
                fuel -= Time.deltaTime;
                jetpackflame.SetActive(true);
                rb2d.AddForce(new Vector2(0, jumpheldforce * 2), ForceMode2D.Force);
                if (fuel < 0)
                {
                    fuel = 0;
                    jetPack.SetActive(false);
                    jetpackEnabled = false;
                }
            }
            else jetpackflame.SetActive(false);
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
        JetPack();
    }

    private bool OnGround()
    {
        //RaycastHit2D raycastHit = 
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void PlayerDead()
    {
        Time.timeScale = 0f;
        gameoverMenu.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthController.TakeDamage(1);
        }
    }
}
