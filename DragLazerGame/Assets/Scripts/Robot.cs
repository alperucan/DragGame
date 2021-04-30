using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Robot : MonoBehaviour
{
    

    [SerializeField]
    private bool gameOver = false;
   
    public float leftBorder = 6.0f;
    public float rightBorder = -6.0f;
    private void Start()
    {
        
    }

    private void Update()
    {
       // stayInBorder();
    }
    /*
    void stayInBorder() {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontalInput, verticalInput,0);

        transform.Translate(dir * Time.deltaTime);

        if (transform.position.x > 6.0f) {
            transform.position = new Vector3(-leftBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -6.0f)
        {
            transform.position = new Vector3(-rightBorder, transform.position.y, transform.position.z);
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish") 
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(waitForOneSec());
        }
    }
 
    IEnumerator waitForOneSec() {

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }
}
