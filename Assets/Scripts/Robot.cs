using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float MoveSpeed = 10.0f;
    public float RotateSpeed = 75.0f;

    public GameObject Bullet;
    public float BulletSpeed = 50f;

    public GameObject Ball;
    public float BallSpeed = 15f;

    public GameObject Grenade;
    public float GrenadeSpeed = 12f;

    private float _vInput;
    private float _hInput;

    private Rigidbody _rb;

    private bool _is_bullet_shot;
    private bool _is_ball_shot;
    private bool _is_grenade_thrown;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;

        _is_bullet_shot |= Input.GetKeyDown(KeyCode.Alpha1);
        _is_ball_shot |= Input.GetKeyDown(KeyCode.Alpha2);
        _is_grenade_thrown |= Input.GetKeyDown(KeyCode.Alpha3);
    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position +
            this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (_is_bullet_shot)
        {
            GameObject bullet = Instantiate(Bullet,
                this.transform.position + new Vector3(1, 0, 0), this.transform.rotation);
            Rigidbody bullet_rb = bullet.GetComponent<Rigidbody>();
            //bullet_rb.velocity = this.transform.forward * BulletSpeed;
            Vector3 correction = new Vector3(0, 0.06f, 0);
            //bullet_rb.velocity = this.transform.forward * BulletSpeed;
            bullet_rb.velocity = (this.transform.forward + correction) * BulletSpeed;
        }

        _is_bullet_shot = false;

        if (_is_ball_shot)
        {
            GameObject ball = Instantiate(Ball,
                this.transform.position + new Vector3(1, 0, 1), this.transform.rotation);
            Rigidbody ball_rb = ball.GetComponent<Rigidbody>();
            //bullet_rb.velocity = this.transform.forward * BulletSpeed;
            Vector3 correction = new Vector3(0, 0.5f, 0);
            //bullet_rb.velocity = this.transform.forward * BulletSpeed;
            ball_rb.velocity = (this.transform.forward + correction) * BallSpeed;
        }

        _is_ball_shot = false;

        if (_is_grenade_thrown)
        {
            GameObject grenade = Instantiate(Grenade,
                this.transform.position + new Vector3(0.5f, 0, 0.5f), this.transform.rotation);
            Rigidbody grenade_rb = grenade.GetComponent<Rigidbody>();
            Vector3 correction = new Vector3(0, 0.4f, 0);
            grenade_rb.velocity = (this.transform.forward + correction) * GrenadeSpeed;

        }

        _is_grenade_thrown = false;
    }
}
