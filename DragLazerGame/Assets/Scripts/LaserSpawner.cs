using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject laserPrefab;
    public GameObject currentLaser;
    public List<GameObject> laserList;

    private Rigidbody2D rb;
    private Vector3 rel;
    private Vector3 offset;
    private Vector3 oldMouse;
    private Vector3 mouseSpeed;
 
    public float speed = 5;
    bool isDragged= false;
    float angle=0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            StartClick();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopClick();
        }
      
        if (isDragged) {
            DestroyLaser();
            Quaternion quaternion = Quaternion.Euler(0, 0, angle);
         
           
            oldMouse.z = 0;
            currentLaser.transform.position = (oldMouse);
            currentLaser.transform.rotation = quaternion;
            currentLaser.GetComponent<Rigidbody2D>().velocity = mouseSpeed * speed ;
            isDragged = false;
        }

    }
    void StartClick()
    {
        isDragged = false;
        oldMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }



    void StopClick()
    {
        
        mouseSpeed = (oldMouse - Camera.main.ScreenToWorldPoint(Input.mousePosition) );
    
        angle = Mathf.Atan2(mouseSpeed.y, mouseSpeed.x) * Mathf.Rad2Deg;
     
        rel = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     
        isDragged = true;

    }
    public void DestroyLaser()
    {

        if (laserList.Count > 0)
        {

            Destroy(laserList[0], 2f);
            laserList.RemoveAt(0);
        }
        currentLaser = Instantiate(laserPrefab);
        laserList.Add(currentLaser);

    }

}
