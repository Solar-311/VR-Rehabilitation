using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence3 : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> cubes = new List<GameObject>();

    public float height;
    public float delay;

    private bool spam = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (spam == false)
            {
                StartCoroutine(UpCube3());
                spam = true;
            }
        }
    }

    IEnumerator UpCube3()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            for (int i = 0; i < cubes.Count; i++)
            {
                cubes[i].transform.Translate(0, height, 0);
                yield return new WaitForSeconds(delay);
                cubes[i].transform.Translate(0, -height, 0);
                yield return new WaitForSeconds(delay);
                isPlaying = false;
            }
        }
    }
}
