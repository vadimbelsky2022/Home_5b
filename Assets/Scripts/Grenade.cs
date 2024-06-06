using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float OnscreenDelay = 3f;
    public GameObject Splinter;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, OnscreenDelay);
        Invoke("Blust", 2.9f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Blust()
    {

        for(int i = 0; i < 50; i++)
        {
            GameObject splinter = Instantiate(Splinter,
                this.transform.position, this.transform.rotation);
            Rigidbody splinter_rb = splinter.GetComponent<Rigidbody>();
            Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f),
            Random.Range(0, 0.5f), Random.Range(-1.0f, 1.0f));
            float splinter_speed = Random.Range(20f, 60f);
            splinter_rb.velocity = direction * splinter_speed;
            Destroy(splinter, 1.0f);
        }
    }

}
