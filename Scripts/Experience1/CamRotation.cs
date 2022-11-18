using UnityEngine;

public class CamRotation : MonoBehaviour
{
	// Settings
    public string RotationToLeft;
    public string RotationToRight;
    public float angle;

    // Spam prevention
    public float spamDelay;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }


    // Update is called once per frame
    void Update ( )
	{
        // Timer initalisation
        timer += Time.deltaTime;
        if (timer >= spamDelay)
        {
            if (Input.GetKey(RotationToLeft))
            {
                transform.Rotate(0, angle, 0);
                Debug.Log("Experience 1 / Camera : The Main Camera has rotated from : " + angle + "°");
                timer = 0;

            }

            if (Input.GetKey(RotationToRight))
            {
                transform.Rotate(0, -angle, 0);
                Debug.Log("Experience 1 / Camera : The Main Camera has rotated from : - " + angle + "°");
                timer = 0;
            }
        }
	}
}
