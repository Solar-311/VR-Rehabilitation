using UnityEngine;

public class AdjustHandTracking : MonoBehaviour
{
    // Variables
    public GameObject hand;

    // Settings
    public float speedMovement;
    public float timeSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Up
        if (Input.GetKey(KeyCode.PageUp))
        {
            hand.transform.Translate(0, speedMovement * Time.deltaTime, 0);
            print("The hand has been moved from " + speedMovement);
        }

        // Down
        if (Input.GetKey(KeyCode.PageDown))
        {
            hand.transform.Translate(0, - speedMovement * Time.deltaTime, 0);
            print("The table has been moved from " + speedMovement);
        }

        // Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            hand.transform.Translate(speedMovement * Time.deltaTime, 0, 0);
            print("The table has been moved from " + speedMovement);
        }

        // Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hand.transform.Translate(- speedMovement * Time.deltaTime, 0, 0);
            print("The table has been moved from " + speedMovement);
        }

        // Front
        if (Input.GetKey(KeyCode.UpArrow))
        {
            hand.transform.Translate(0, 0, speedMovement * Time.deltaTime);
            print("The table has been moved from " + speedMovement);
        }

        // Back
        if (Input.GetKey(KeyCode.DownArrow))
        {
            hand.transform.Translate(0, 0, - speedMovement * Time.deltaTime);
            print("The table has been moved from " + speedMovement);
        }

    }
}
