using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;
    private Collider2D coll;
    private const string Y_VELOCITY = "y_velocity";
    private const string X_VELOCITY = "x_velocity";
    [SerializeField] private HealthController healthController;
    [SerializeField] private Vector3 lastCheckpoint;

    [SerializeField] private float speed, jumpForce, jumpheldForce, fuel, jetpackForce, fueldepletionRate;
    //[SerializeField] 
    private bool jumpPressed, jumpHeld, flyJetpack;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private GameObject Wings, jetPack, jetpackflame, gameoverMenu;
    [SerializeField] private GameObject fuelMeter;
    private float horizontal, vertical;
    public bool WingsEnabled, JetpackEnabled;



    private void Awake()
    {
        Time.timeScale = 1;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        WingsEnabled = false;
        JetpackEnabled = false;
        fuel = 100;
        lastCheckpoint = transform.position;

    }


    private void InputsAndAnimations()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        jumpPressed = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0);
        jumpHeld = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button0);
        flyJetpack = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.Joystick1Button5); ;

        animator.SetFloat(Y_VELOCITY, rb2d.velocity.y);
        animator.SetFloat(X_VELOCITY, rb2d.velocity.x);
        animator.SetBool("onground", OnGround());
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        animator.SetBool("jetpackjump", flyJetpack);
    }

    private void RunAndFlip()
    {
        if (horizontal != 0)
        {

            Vector2 position = transform.position;
            position.x += horizontal * speed * Time.deltaTime;
            transform.position = position;



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
        if (jumpPressed)
        {

            if (OnGround())
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void JumpHold()
    {
        if ((WingsEnabled) && (jumpHeld))
        {
            Wings.SetActive(true);
            animator.SetBool("wingsjump", true);
            rb2d.AddForce(new Vector2(0, jumpheldForce), ForceMode2D.Force);
        }
        else
        {

            Wings.SetActive(false);
            animator.SetBool("wingsjump", false);

        }
    }
    private void JetPack()
    {
        if (JetpackEnabled)
        {
            fuelMeter.GetComponentInChildren<Slider>().value = fuel;
            fuelMeter.SetActive(true);
            jetPack.SetActive(true);

            if (flyJetpack)
            {
                fuel -= Time.deltaTime * fueldepletionRate;
                jetpackflame.SetActive(true);
                rb2d.AddForce(new Vector2(0, jetpackForce * Time.deltaTime), ForceMode2D.Impulse);
                if (fuel < 0)
                {
                    fuel = 0;
                    jetPack.SetActive(false);
                    fuelMeter.SetActive(false);
                    JetpackEnabled = false;
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
        JumpHold(); JetPack();

    }

    private bool OnGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void PlayerDead()
    {
        Time.timeScale = 0f;
        this.enabled = false;
        fuelMeter.SetActive(false);
        gameoverMenu.SetActive(true);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            healthController.TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("Checkpoint"))
        {
            lastCheckpoint = collision.gameObject.transform.position;

        }
        else if (collision.gameObject.CompareTag("Respawn"))
        {
            transform.position = lastCheckpoint;
            rb2d.velocity = new Vector2(0, 0);
            healthController.TakeDamage(1);
        }
    }
}
