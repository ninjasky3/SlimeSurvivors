using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Terresquall;
using static UnityEngine.GraphicsBuffer;
using System;

public class PlayerMovement : MonoBehaviour
{

    public const int DEFAULT_MOVESPEED = 5;

    //Movement
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Boolean mouseMoving = false;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 lastMovedVector;

    //References
    Rigidbody2D rb;
    PlayerStats player;
    public Vector2 targets;
    public Vector2 targetPos;
    public Camera cam;
    void Start()
    {
        cam = FindAnyObjectByType<Camera>();
        player = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();

        targetPos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
       
        targets = targetPos;
        Debug.Log(targets);
        lastMovedVector = new Vector2(1, 0f); //If we don't do this and game starts up and don't move, the projectile weapon will have no momentum
    }

    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
        MouseMove();
    }

    void InputManagement()
    {
        if(GameManager.instance.isGameOver)
        {
            return;
        }

        float moveX, moveY;
        if (VirtualJoystick.CountActiveInstances() > 0)
        {
            moveX = VirtualJoystick.GetAxisRaw("Horizontal");
            moveY = VirtualJoystick.GetAxisRaw("Vertical");
        }
        else
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
        }
        

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);    //Last moved X
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);  //Last moved Y
        }

        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);    //While moving
        }
    }

    void Move()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        rb.velocity = moveDir * DEFAULT_MOVESPEED * player.Stats.moveSpeed;
    }

    void MouseMove()
    {
        
        
        if (Input.GetMouseButton(0))
        {
            mouseMoving = true;
            targetPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            targets = targetPos;
            if ((Vector2)transform.position != targetPos)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, player.Stats.moveSpeed * 5 * Time.deltaTime);

                var offset = 90f;
                Vector2 direction = targets - (new Vector2(transform.position.x,transform.position.y));
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
            }
        }
        else
        {
            mouseMoving = false;
        }
    }
}
