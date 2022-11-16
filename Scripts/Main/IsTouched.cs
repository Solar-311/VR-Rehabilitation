using System.Collections;
using UnityEngine;

public class IsTouched : MonoBehaviour
{
    private float dist;
    public GameObject plane;
    public GameObject hand;
    public GameObject cube;
    public float sensi;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Touched());
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(plane.transform.position, hand.transform.position);
        if (dist <= sensi)
        {
                cube.GetComponent<Renderer>().material.color = new Color(0, 255, 225);
                Debug.Log("Cube has been touched");
        }
        else
        {
            cube.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
        }
    }
}
