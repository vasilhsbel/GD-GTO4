using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicator : MonoBehaviour {

    public MouseManager mm;
    public bool trackHover;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (trackHover)
        {
            if (mm.hoveredObject != null)
            {
                this.transform.position = mm.hoveredObject.transform.position;
            }
        }
        else
        {
            if (mm.selectedObject != null)
            {
                this.transform.position = mm.selectedObject.transform.position;
            }
        }
    }

    public void activateSelection()
    {
        gameObject.SetActive(true);
    }

    public void disableSelection()
    {
        gameObject.SetActive(false);
    }
}
