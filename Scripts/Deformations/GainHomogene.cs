using UnityEngine;

public class GainHomogene : MonoBehaviour
{
    // Variables
    public GameObject hand;
    public GameObject mark;
    private Vector3 posOrigin;

    // Settings
    public float gain;

    // Start is called before the first frame update
    void Start()
    {
        posOrigin = mark.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx = transfo(mark.transform.position.x, posOrigin.x);
        float dz = transfo(mark.transform.position.z, posOrigin.z);
        Vector3 d = new Vector3(dx - mark.transform.position.x, 0, dz - mark.transform.position.z);
        hand.transform.position = posOrigin + d;
    }

    float transfo(float actual, float origin)
    {
        return gain * (actual - origin);
    }
}
