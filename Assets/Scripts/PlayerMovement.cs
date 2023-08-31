using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator anim;
    public int manaSpend = 30;
    float run;
    string[] runDirections = { "Run S", "Run SW", "Run W", "Run NW", "Run N", "Run NE", "Run E", "Run SE", };
    public Joystick joystick;

    public ProjectileController projectileController;
    public Transform LaunchOffset;
    public PlayerController playerController;

    [SerializeField] private AudioSource attackEffect;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        moveX += joystick.Horizontal;
        float moveY = Input.GetAxisRaw("Vertical");
        moveY += joystick.Vertical;
        run = Mathf.Abs(moveX) + Mathf.Abs(moveY);

        moveDirection = new Vector2(moveX, moveY);
        anim.SetFloat("Speed", run);

        if(run > 0)
        {
            anim.Play(runDirections[DirectionToIndex(moveDirection)]);
            anim.SetInteger("Step", DirectionToIndex(moveDirection));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(playerController.currentMana > manaSpend)
            {
                Attack();
            }
        }       
    }
 
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2 (moveDirection.x * speed, moveDirection.y * speed);
    }
    public void Attack()
    {
        attackEffect.Play();
        anim.SetTrigger("Attack");

        Instantiate(projectileController, LaunchOffset.position, transform.rotation);
        playerController.spendMana(manaSpend);
    }
    private int DirectionToIndex(Vector2 dir)
    {
        Vector2 norDir = dir.normalized;
        float step = 360 / 8;
        float offset = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, norDir);

        angle += offset;
        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }

    


}
