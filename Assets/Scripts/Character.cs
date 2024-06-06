using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    public float gravity = -9.81f;
    public float speed = 10.0f;
    public float jump_impulse = 50.0f;
    public float jump_speed = 0f;
    private bool is_jump = false;

    CharacterController controller;

    private Touch touch;
    private Vector2 oldTouchPosition;
    private Vector2 NewTouchPosition;
    private float touch_rotation_speed = 100f;

    public Button turn_right;
    public Button turn_left;
    public Button move_forward;
    public Button move_backward;

    private int rotate;

    public CharacterController Controller
    {
        get
        {
            return controller = controller ?? GetComponent<CharacterController>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //turn_right.onClick.AddListener(RotateRight);
        //turn_left.onClick.AddListener(RotateLeft);
        //move_forward.onClick.AddListener(MoveForward);
        //move_backward.onClick.AddListener(MoveBackward);
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horisontal = Input.GetAxis("Horizontal");

        float rotation = Input.GetAxis("Mouse X");

        if(jump_speed > -jump_impulse)
        {
            jump_speed += gravity / 10.0f;
        }
        else
        {
            jump_speed = 0f;
            is_jump = false;
        }

        Vector3 movement = new Vector3(horisontal * speed, gravity + jump_speed, vertical * speed);
        Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        Controller.transform.Rotate(Vector3.up, rotation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!is_jump)
            {
                jump_speed = jump_impulse;
            }

            is_jump = true;
        }

        RotateAlien();
        MoveAlien();
    }

    private void FixedUpdate()
    {
        //hInput = joystick.Horizontal * moveSpeed;
        //vInput = joystick.Vertical;
        //if (vInput > 100.0)
        //{
        //    transform.Translate(0, 0, 0.1f);
        //}

        //transform.Translate(0, 0, 0.1f);

        //if (Input.touchCount > 0)
        //{
        //    Debug.Log(Input.touchCount);
        //    touch = Input.GetTouch(0);
        //    MoveForward();
        //}
    }

    private void RotateAlien()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                oldTouchPosition = touch.position;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                NewTouchPosition = touch.position;
            }

            Vector2 rotDirection = oldTouchPosition - NewTouchPosition;
            //Debug.Log(rotDirection);
            Debug.Log($"{touch.position.x}, {touch.position.y}");

            //if (touch.position.x > 800 || touch.position.x < 400) {
            //    if (rotDirection.x < 0)
            //    {
            //        RotateRight();
            //    }

            //    else if (rotDirection.x > 0)
            //    {
            //        RotateLeft();
            //    }
            //}

            if (touch.position.x > turn_right.transform.position.x -50
                && touch.position.x < turn_right.transform.position.x + 50 &&
                touch.position.y > turn_right.transform.position.y -30 && 
                touch.position.y < turn_right.transform.position.y + 30)
            {
                RotateLeft();
            }
            if (touch.position.x > turn_left.transform.position.x - 50
                && touch.position.x < turn_left.transform.position.x + 50 &&
                touch.position.y > turn_left.transform.position.y - 30 &&
                touch.position.y < turn_left.transform.position.y + 30)
            {
                RotateRight();
            }

        }
    }

    private void MoveAlien()
    {
        if(Input.touchCount > 0)
        {
            if (touch.position.x > move_forward.transform.position.x - 30
                && touch.position.x < move_forward.transform.position.x + 30 &&
                touch.position.y > move_forward.transform.position.y - 50 &&
                touch.position.y < move_forward.transform.position.y + 50)
            {
                MoveForward();
            }
            if (touch.position.x > move_backward.transform.position.x - 30
                && touch.position.x < move_backward.transform.position.x + 30 &&
                touch.position.y > move_backward.transform.position.y - 50 &&
                touch.position.y < move_backward.transform.position.y + 50)
            {
                MoveBackward();
            }
        }
    }

    void RotateLeft()
    {
        float x = touch_rotation_speed * Time.deltaTime;
        this.transform.Rotate(Vector3.up * x);
    }

    void RotateRight()
    {
        float x = touch_rotation_speed * Time.deltaTime;
        this.transform.Rotate(Vector3.up * (-x));
    }

    private void MoveForward()
    {
        transform.Translate(0, 0, 0.12f);
    }
    private void MoveBackward()
    {
        transform.Translate(0, 0, -0.07f);
    }

    void OnMouseDown()
    {
        Debug.Log("Unity");
        float x = touch_rotation_speed * Time.deltaTime;
        this.transform.Rotate(Vector3.up * x * rotate);
    }
}
