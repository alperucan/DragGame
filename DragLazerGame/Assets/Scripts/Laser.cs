using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody2D rb;

    Vector3 lastVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
         lastVelocity = rb.velocity;
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") { 
        //change rotation
        transform.eulerAngles = new Vector3(
             transform.eulerAngles.x,
             transform.eulerAngles.y,
             (180-transform.eulerAngles.z)
        );

        //save speed before hit!
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);
      
        rb.velocity = direction;
         
        }
        else if (collision.gameObject.tag == "Robot")
        {
            //Debug.Log("robot Laser dest");
            Destroy(this.gameObject);
            
        }
        else if (collision.gameObject.tag == "BorderWall")
        {
            //Debug.Log("Bordor laser dest");
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Turbine")
        {
            //Debug.Log("Bordor laser dest");
            Destroy(this.gameObject);
        }

    }

}
