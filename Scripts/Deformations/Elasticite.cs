using UnityEngine;

public class Elasticite : MonoBehaviour
{
    // Variables
    public GameObject hand;
    public GameObject mark;
    private Vector3 posOrigin;

    // Settings
    public float gain1;
    public float gain2;
    public float gain3;
    public float angle1;
    public float angle2;
    private float alpha;

    // Start is called before the first frame update
    void Start()
    {
        posOrigin = mark.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = mark.transform.position.x;
        float y = mark.transform.position.y;
        float z = mark.transform.position.z;
        float r = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(z, 2));

        if (x >= 0 && z >= 0)
        {
            alpha = Mathf.Asin(z / r) * Mathf.Rad2Deg;
        }
        
        else if (x < 0 && z > 0)
        {
            alpha = 180 - ((Mathf.Asin(z / r) * Mathf.Rad2Deg));
        }

        else
        {
            alpha = 0;
        }

        // alpha < angle1 = 75
        if (alpha > 0 && alpha < angle1)
        {
            float dx = transfo1(mark.transform.position.x, posOrigin.x);
            float dz = transfo1(mark.transform.position.z, posOrigin.z);
            Vector3 d = new Vector3(dx - mark.transform.position.x, 0, dz - mark.transform.position.z);
            hand.transform.position = posOrigin + d;
            print("secteur3");
        }

        // 105° > alpha > 75°
        else if (alpha > angle1 && alpha < angle2)
        {
            float dx = transfo2(mark.transform.position.x, posOrigin.x);
            float dz = transfo2(mark.transform.position.z, posOrigin.z);
            Vector3 d = new Vector3(dx - mark.transform.position.x, 0, dz - mark.transform.position.z);
            hand.transform.position = posOrigin + d;
            print("secteur2");
        }

        // alpha > 135°
        else if (alpha > angle2 && alpha <= 180)
        {
            float dx = transfo3(mark.transform.position.x, posOrigin.x);
            float dz = transfo3(mark.transform.position.z, posOrigin.z);
            Vector3 d = new Vector3(dx - mark.transform.position.x, 0, dz - mark.transform.position.z);
            hand.transform.position = posOrigin + d;
            print("secteur1");
        }
    }

    float transfo1(float actual, float origin)
    {
        return gain1 * (actual - origin);
    }

    float transfo2(float actual, float origin)
    {
        return gain2 * (actual - origin);
    }

    float transfo3(float actual, float origin)
    {
        return gain3 * (actual - origin);
    }
}
