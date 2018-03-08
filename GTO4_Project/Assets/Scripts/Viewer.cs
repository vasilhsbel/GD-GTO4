using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Viewer : MonoBehaviour {

    public Resource[] myResources = new Resource[7];
    public Text[] resourceText = new Text[7];
	// Use this for initialization
	void Start () {

        foreach (Resource element in myResources)
        {
            element.OnVariableChange += updateGUI;
        }
       
        updateGUI();

    }

    public void updateGUI()
    {
        for (int i = 0; i < 7; i++)
        {
            resourceText[i].text = string.Format("{0}", myResources[i].ammount);
        }
        
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
