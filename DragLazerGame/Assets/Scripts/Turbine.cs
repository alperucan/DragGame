using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
  //  public float speed = 5f;

    public GameObject obj;
    // Update is called once per frame
    void Update()
    {
        obj.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }
}
