using System.Collections;
using UnityEngine;
using System.IO;
using System;

public class DataCollect : MonoBehaviour
{
    // Variables
    public GameObject currentObject;
    public string inputReset;

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

        // Path of CSV file
        filename = Application.dataPath + "/Scripts/Data/Data.csv";

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
            delimiter + (speed);

        // Write in CSV File
        writer.WriteLine(dataText);

        // When the scene is reset, the file is reset too
        if (Input.GetKey(inputReset))
        {
            writer.Flush();
            writer.Close();
            Debug.Log("Data file / Statement : Flushed and Closed");
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
}
