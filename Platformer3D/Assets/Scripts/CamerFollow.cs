using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    // Start is called before the first frame update

    //This is the target object
    public Transform target;

    //This is the offset value, vector3 is the 3 directions
    public Vector3 offset;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the target is null, do nothing
        if(target == null)
        {
            return;
        }

//The transform.position is the position of the object that we are currently looking at, the target.transform.position is the position of the object that we are looking at, the offset is a distance thats added to offset the camera
        transform.position = target.transform.position + offset;


    }
}
