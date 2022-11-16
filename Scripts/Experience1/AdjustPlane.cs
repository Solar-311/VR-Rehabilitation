using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustPlane : MonoBehaviour
{
    // Settings
	public string moveTop;
	public string moveBottom;
    public float speedMovement;

    // Spam prevention
    public float spamDelay;
    public float timer = 0;
    
	
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Timer initalisation
        timer += Time.deltaTime;
        if (timer >= spamDelay)
        {
            if (Input.GetKey(moveTop))
            {
                transform.Translate(0, speedMovement * Time.deltaTime, 0);
                Debug.Log("Experience 1 / Table : Moved from : " + speedMovement);
                timer = 0;
            }

            if (Input.GetKey(moveBottom))
            {
                transform.Translate(0, - speedMovement * Time.deltaTime, 0);
                Debug.Log("Experience 1 / Table : Moved from : - " + speedMovement);
                timer = 0;
            }
        }
    }
}
