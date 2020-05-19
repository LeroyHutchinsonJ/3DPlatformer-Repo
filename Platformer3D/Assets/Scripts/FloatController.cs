using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloatController : MonoBehaviour
{
    //This is the speed variable
    public float speed;
    //This is the offset for the end position
    public Vector3 offsetEndPos;

    //This is the start position, it is a private variable
    private Vector3 startPos;
    //This is the target position, it is a private variable
    private Vector3 targetPos;

    private Rigidbody rb;
    private void Awake()
    {
        startPos = transform.position;
        targetPos = startPos + offsetEndPos;

        //This gets the current rigidbody of the component
        rb = GetComponent<Rigidbody>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Gradually increase the transform position until it gets to the target position from the current position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        

        //If the object is at the target position
        if (transform.position == targetPos)
        {
            //If the object is back where it started
            if (targetPos == startPos)
            {
                //Set the target position to the end
                targetPos = startPos + offsetEndPos;
            }
            else if (targetPos == startPos + offsetEndPos) //If the object is at the end
            {
                //Set the target position to the place where the box started
                targetPos = startPos;
            }
        }
  
       // rb.MovePosition(startPos + targetPos * Time.fixedDeltaTime);

    }

}
