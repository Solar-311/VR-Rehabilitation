using System.Collections;
using UnityEngine;

// Enums
public class Movement : MonoBehaviour
{
    // GameObject
    public GameObject sphere;

    // Inputs
    public string inputRight;
    public string inputLeft;
    public string inputFront;
    public string inputBack;

    // Settings
    public float speedMovement;
    private bool spam = false;

    // Positions
    public Vector3 pointA = new Vector3(0, 0.75f, 0.2f);
    public float r;
    public float theta;
    //public float phi;

    //public float x;
    public float y;
    //public float z;

    // Timer
    private float timer;

    void Start()
    {

    }

    void Update()
    {
        // Mouvements manuels
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sphere.transform.Translate(0, speedMovement * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            sphere.transform.Translate(0, - speedMovement * Time.deltaTime, 0);
        }

        if (Input.GetKey(inputRight))
        {
            sphere.transform.Translate(speedMovement * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(inputLeft))
        {
            sphere.transform.Translate(- speedMovement * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(inputFront))
        {
            sphere.transform.Translate(0, 0, speedMovement * Time.deltaTime);
        }

        if (Input.GetKey(inputBack))
        {
            sphere.transform.Translate(0, 0, - speedMovement * Time.deltaTime);
        }

        // Movement auto
        if ((Input.GetKey(KeyCode.Return) || OVRInput.Get(OVRInput.Button.Two))
            // Security
            && !OVRInput.Get(OVRInput.Button.One) && !Input.GetKey(KeyCode.Space))
        {
            if (spam == false)
            {
                StartCoroutine(MoveObject());
                spam = true;
            }
        }

        // Hide the ball
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (sphere.GetComponent<Renderer>().enabled == true)
            {
                sphere.GetComponent<Renderer>().enabled = false;
            }
            
            else if (sphere.GetComponent<Renderer>().enabled == false)
            {
                sphere.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    IEnumerator MoveObject()
    {
        // Point B in spheric system
        //Vector3 pointB = new Vector3(r * Mathf.Sin(theta /** (180 / Mathf.PI)*/) * Mathf.Cos(phi /** (180 / Mathf.PI)*/),
        //r * Mathf.Cos(theta /** (180 / Mathf.PI)*/),
        //r * Mathf.Sin(theta /** (180 / Mathf.PI)*/) * Mathf.Sin(phi /** (180 / Mathf.PI)*/));

        // Point B in rectangular system
        Vector3 pointB = new Vector3(r * Mathf.Cos(theta * Mathf.Deg2Rad), y, r * Mathf.Sin(theta * Mathf.Deg2Rad));

        bool isPlaying = true;
        while (isPlaying)
        {
            timer += 0.01f;
            sphere.transform.position = Vector3.Lerp(pointA, pointB, (Mathf.Sin((speedMovement * timer) - Mathf.PI/2) + 1f) / 2f);

            if ((OVRInput.Get(OVRInput.Button.One) || Input.GetKey(KeyCode.Space))
                // Security
                && !OVRInput.Get(OVRInput.Button.Two) && !Input.GetKey(KeyCode.Return))
            {
                Debug.Log("Button.One was pressed");
                isPlaying = false;
                spam = false;
                yield return null;
            }

            yield return null;
        }
    }
}
