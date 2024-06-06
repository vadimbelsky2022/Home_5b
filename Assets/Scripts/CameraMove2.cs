using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraMove2 : MonoBehaviour
{
    public Vector3 CameraOffset = new Vector3(0f, 3.0f, -6.0f);
    private Transform _target;
    bool rotate_down = false;
    bool rotate_up = false;

    public Button button_camera_up;
    public Button button_camera_down;
    public Button button_camera_reset;

    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find("Alien").transform;
        button_camera_up.onClick.AddListener(MoveCameraUp);
        button_camera_down.onClick.AddListener(MoveCameraDown);
        button_camera_reset.onClick.AddListener(ResetCamera);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    rotate_down = true;
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    rotate_up = true;
        //}

        //if (Input.GetKeyUp(KeyCode.Alpha1))
        //{
        //    rotate_down = false;
        //}

        //if (Input.GetKeyUp(KeyCode.Alpha2))
        //{
        //    rotate_up = false;
        //}

        //if (rotate_up)
        //{
        //    if (this.transform.rotation.x > -0.25f)
        //    {
        //        this.transform.Rotate(-0.08f, 0, 0);
        //    }

        //}

        //if (rotate_down)
        //{
        //    if (this.transform.rotation.x < 0.5f)
        //    {
        //        this.transform.Rotate(0.08f, 0, 0);
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    Debug.Log(this.transform.rotation);
        //}

    }

    private void MoveCameraUp()
    {
        rotate_up = true;
        if (this.transform.rotation.x > -0.2f)
        {
            this.transform.Rotate(-2.5f, 0, 0);
        }
    }
    private void MoveCameraDown()
    {
        Debug.Log(this.transform.rotation.x);
        rotate_down = true;
        if (this.transform.rotation.x < 0.36f)
        {
            this.transform.Rotate(+2.5f, 0, 0);
        }
    }

    private void ResetCamera()
    {
        rotate_down = false;
        rotate_up = false;
    }

    private void LateUpdate()
    {
        this.transform.position = _target.TransformPoint(CameraOffset);
        if (!rotate_down && !rotate_up)
        {
            this.transform.LookAt(_target);
        }

    }
}
