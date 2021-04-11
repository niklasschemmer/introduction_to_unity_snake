using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var movementForward = Vector3.forward * Time.deltaTime * 3;
        var rotation = Vector3.up * Time.deltaTime * 30;
        //transform.Translate(Input.GetAxis("Vertical") * movementForward);
        //transform.Rotate(Input.GetAxis("Horizontal") * rotation);
    }
}
