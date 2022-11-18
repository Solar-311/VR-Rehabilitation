using System.Collections;
using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

public class DataIndex : MonoBehaviour
{
    // Variables
    public GameObject currentObject;
    public string inputReset;
    private float distance;
    private string result;
    public float sensi;

    [SerializeField]
    public List<GameObject> cubes = new List<GameObject>();

    // Settings
    private float speed;

    // Timer
    private float timer;

    // Csv Writer variables
    StreamWriter writer;
    string filename;

    // Start is called before the first frame update
    void Start()
    {

        // Speed Calcul
        StartCoroutine(CalcSpeed());
        StartCoroutine(CalcError());

        // Path of CSV file
        filename = Application.dataPath + "/Scripts/Data/DataIndex.csv";

        //Output
        Debug.Log("DataFile / DataPath : " + filename);
        writer = new StreamWriter(filename);

        // Title in CSV File
        writer.WriteLine("Experience made the : " + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss"));

        // Column
        writer.WriteLine("Pos X; " +
                        "Pos Y; " +
                        "Pos Z; " +
                        "Timer; " +
                        "Is Touched; " +
                        "Speed");
    }

    // Update is called once per frame
    void Update()
    {
        // Timer initalisation
        timer += Time.deltaTime;

        // Matrix
        string delimiter = "; ";
        string dataText =
            // Unity referential
            (currentObject.transform.position.x) +
            delimiter + (currentObject.transform.position.y) +
            delimiter + (currentObject.transform.position.z) +
            delimiter + (timer) +
            delimiter + (result) +
            delimiter + (speed);

        // Write in CSV File
        writer.WriteLine(dataText);

        // When the scene is reset, the file is reset too
        if (Input.GetKey(inputReset))
        {
            writer.Flush();
            writer.Close();
            Debug.Log("DataIndex file / Statement : Flushed and Closed");
            timer = 0;
        }
    }

    // Calcul Speed
    IEnumerator CalcSpeed()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            Vector3 prevPos = currentObject.transform.position;
            yield return new WaitForFixedUpdate();
            speed = (Vector3.Distance(currentObject.transform.position, prevPos) / Time.deltaTime);
        }
    }

    IEnumerator CalcError()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            for (int i = 0; i < cubes.Count; i++)
            {
                distance = Vector3.Distance(currentObject.transform.position, cubes[i].transform.position);
                if (distance <= sensi)
                {
                    result = cubes[i].name + " : Touched";
                }

                else
                {
                    result = "Missed";
                }
                yield return result;
            }
        }
    }
}
