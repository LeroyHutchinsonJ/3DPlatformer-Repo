using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    
    public float bobSpeed;
    public float rotateSpeed;
    public float bobHeight;


    private Vector3 startPos;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        //Sets the start pos to the current object position
        startPos = transform.position;

        //Set the target position
        targetPos = startPos + new Vector3(0, bobHeight, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Move the transform position toward the target position, bob speed* the time is the max distance that it can travel
        transform.position = Vector3.MoveTowards(transform.position, targetPos, bobSpeed * Time.deltaTime);

        //This is to rotate the coin
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        if(transform.position == targetPos)
        {
            if(targetPos == startPos)
            {
                targetPos = startPos + new Vector3(0, bobHeight, 0);
            }
            else if(targetPos == startPos + new Vector3(0, bobHeight, 0))
            {
                targetPos = startPos;
            }
           
        }

    }
    
}
