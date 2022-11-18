using UnityEngine;

public class IsCubeTouched : MonoBehaviour
{
    private float dist;
    public GameObject hand;
    public GameObject cube;
    public float sensi;
    public float R;
    public float G;
    public float B;
    public float Rtouch;
    public float Gtouch;
    public float Btouch;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Touched());
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(cube.transform.position, hand.transform.position);
        if (dist <= sensi)
        {
            cube.GetComponent<Renderer>().material.color = new Color(R, G, B);
            Debug.Log("Cube has been touched");
        }
        else
        {
            cube.GetComponent<Renderer>().material.color = new Color(Rtouch, Gtouch, Btouch);
        }
    }
}
