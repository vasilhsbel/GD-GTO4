using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

    public Resource myResource;

    public void increaseButton()
    {
        myResource.increaseAmmount(10);
    }

    public void decreaseButton()
    {
        myResource.reduceAmmount(10);
    }
}
