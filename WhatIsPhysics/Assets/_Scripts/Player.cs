using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameController gameController;

    [System.Serializable]
    public enum HeroAnimState
    {
        IDLE,
        WALK,
        JUMP
    }

    public HeroAnimState heroAnimState;

    [Header("Object Properties")]
    public Animator heroAnimator;
    public SpriteRenderer heroSpriteRenderer;
    public Rigidbody2D heroRigidBody;

    [Header("Physics Related")]
    public float moveForce;
    public float jumpForce;

    public bool isGrounded;
    public Transform groundTarget;

    public AudioSource jumpSound;
 
    public Vector2 maxVelocity = new Vector2(20, 20);
    // Start is called before the first frame update
    void Start()
    {
        heroAnimState = HeroAnimState.IDLE;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {


        isGrounded = Physics2D.BoxCast(
            transform.position, new Vector2(2.0f, 1.0f), 0.0f, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("Ground"));

        // Idle State
        if (Input.GetAxis("Horizontal") == 0)
        {
            heroAnimState = HeroAnimState.IDLE;
            heroAnimator.SetInteger("AnimState", (int)HeroAnimState.IDLE);
        }


        // Move Right
        if (Input.GetAxis("Horizontal") > 0)
        {
            heroSpriteRenderer.flipX = false;
            if (isGrounded)
            {
                heroAnimState = HeroAnimState.WALK;
                heroAnimator.SetInteger("AnimState", (int)HeroAnimState.WALK);
                heroRigidBody.AddForce(Vector2.right * moveForce);
            }
        }

        // Move Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            heroSpriteRenderer.flipX = true;
            if (isGrounded)
            {
                heroAnimState = HeroAnimState.WALK;
                heroAnimator.SetInteger("AnimState", (int)HeroAnimState.WALK);
                heroRigidBody.AddForce(Vector2.left * moveForce);
            }
        }

        // Jump
        if ((Input.GetAxis("Jump") > 0) && (isGrounded))
        {
            heroAnimState = HeroAnimState.JUMP;
            heroAnimator.SetInteger("AnimState", (int)HeroAnimState.JUMP);
            heroRigidBody.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
           jumpSound.Play();
        }

        heroRigidBody.velocity = new Vector2(
            Mathf.Clamp( heroRigidBody.velocity.x, -maxVelocity.x, maxVelocity.x),
            Mathf.Clamp(heroRigidBody.velocity.y, -maxVelocity.y, maxVelocity.y)
            );

    }

    // Detecting collisions between the player and other objects and substracting the amount of hearts that each enemy/obsticle hurt the player.
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Spikes":
                gameController.Hearts -= 1;
                break;

            case "Coin":       
                gameController.Score += 50;      
                break;

            case "Enemy":
                gameController.Hearts -= 2;
                break;



        }

    }
}

