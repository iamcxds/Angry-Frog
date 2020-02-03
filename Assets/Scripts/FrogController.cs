using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogController : MonoBehaviour {
    private Rigidbody rb;
    public float jumpForward, jumpUp, rotspeed;
    float t = 0;
    public  int lifetime;
    public Text showLife;
    float timer = 0;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        lifetime = 0;
        SetText();
	}
    void Update()
    {
        SetText();
        if (transform.position.y <= -10)
        {   timer=timer+Time.deltaTime;
            if (timer >= 1)
            {
                timer--;
                lifetime--;
            }
        }
    }

    void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.W) && (rb.velocity.y == 0))
        {
            t += Time.deltaTime;
            if (t >= 0.2f)
            {
                t = 0.2f;
            }
        }
        if (Input.GetKeyUp(KeyCode.W)&&(rb.velocity.y == 0))
        {
            rb.AddRelativeForce(new Vector3 (0 ,t*jumpUp,t* jumpForward));
            t = 0;
        }
        if (Input.GetKey(KeyCode.D) )
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotspeed);

        }
        if (Input.GetKey(KeyCode.A) )
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotspeed);
        }
    }
    public void Plus1s()
    {
        lifetime++;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            lifetime -= other.GetComponent<AI>().attack;

            timer = timer + Time.deltaTime;
                if (timer >= 1)
                {
                    timer--;
                    lifetime-=other.GetComponent<AI>().attack;
                }
            
        }

    }
    void SetText()
    { if(lifetime >= 0)
        {
            showLife.text = "你已经续了" + lifetime + "s";
        }
        else
        {
            showLife.text = "你命被续完了" ;
        }
    }
}
