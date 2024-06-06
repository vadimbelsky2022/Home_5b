using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 CameraOffset = new Vector3(0f, 3.0f, -6.0f);
    private Transform _target;
    bool rotate_down = false;
    bool rotate_up = false;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find("Alien").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rotate_down = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rotate_up = true;
        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            rotate_down = false;
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            rotate_up = false;
        }

        if (rotate_up)
        {
            if (this.transform.rotation.x > -0.25f)
            {
                this.transform.Rotate(-0.08f, 0, 0);
            }
            
        }

        if (rotate_down)
        {
            if(this.transform.rotation.x < 0.5f)
            {
                this.transform.Rotate(0.08f, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log(this.transform.rotation);
        }
    }

    private void LateUpdate()
    {
        this.transform.position = _target.TransformPoint(CameraOffset);
        if(!rotate_down && !rotate_up)
        {
            this.transform.LookAt(_target);
        }
    }

}
