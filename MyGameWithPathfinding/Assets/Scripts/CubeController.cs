using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    public GameObject Cube; 
    public float speed;    
        

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Cube.transform.position = new Vector3(XSpeed, YSpeed, ZSpeed);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        Cube.transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
}
