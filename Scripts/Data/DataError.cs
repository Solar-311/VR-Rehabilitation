using System.Collections;
using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

public class DataError : MonoBehaviour
{
    // Variables
    public GameObject doigt;
    public GameObject sphere;
    public string inputReset;

    [SerializeField]
    public List<GameObject> cubes = new List<GameObject>();

    [SerializeField]
    public List<GameObject> cubesFront = new List<GameObject>();

    [SerializeField]
    public List<GameObject> cubesBack = new List<GameObject>();

    // Settings
    private float speed;
    public float sensi;

    // Timer
    private float timer;

    // Csv Writer variables
    StreamWriter writer;
    string filename;

    // Variables internes
    private float distanceFront;
    private float distanceBack;
    private float distancePos;
    private string result;
    private string messageDistFront;
    private string messageDistBack;
    private string messagePos;

    // Start is called before the first frame update
    void Start()
    {

        // Speed Calcul
        StartCoroutine(CalcSpeed());
        StartCoroutine(CalcDistErrorFront());
        StartCoroutine(CalcDistErrorBack());
        StartCoroutine(CalcPos());

        // Path of CSV file
        filename = Application.dataPath + "/Scripts/Data/DataError.csv";

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
                        "Speed;" +
                        "Success;" +
                        "Distance Cubes avant;" + 
                        "Distance Cubes loin;" + 
                        "IsOrigin;");
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
            (doigt.transform.position.x) +
            delimiter + (doigt.transform.position.y) +
            delimiter + (doigt.transform.position.z) +
            delimiter + (timer) +
            delimiter + (speed) +
            delimiter + (result) +
            delimiter + (messageDistFront) +
            delimiter + (messageDistBack) +
            delimiter + (messagePos);

        // Write in CSV File
        writer.WriteLine(dataText);

        // When the scene is reset, the file is reset too
        if (Input.GetKey(inputReset))
        {
            writer.Flush();
            writer.Close();
            Debug.Log("DataError file / Statement : Flushed and Closed");
            timer = 0;
        }
    }

    // Calcul Speed
    IEnumerator CalcSpeed()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            Vector3 prevPos = doigt.transform.position;
            yield return new WaitForFixedUpdate();
            speed = (Vector3.Distance(doigt.transform.position, prevPos) / Time.deltaTime);
        }
    }

    IEnumerator CalcDistErrorFront()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            for (int i = 0; i < cubesFront.Count; i++)
            {
                distanceFront = Vector3.Distance(doigt.transform.position, cubesFront[i].transform.position);
                if (distanceFront <= sensi)
                {
                    if (doigt.transform.position.z <= cubesFront[i].transform.position.z)
                    {
                        messageDistFront = cubesFront[i].name + " + " + distanceFront;
                    }
                    else
                    {
                        messageDistFront = cubesFront[i].name + " - " + distanceFront;
                    }
                }

                else
                {
                    messageDistFront = " ";
                }
                yield return messageDistFront;
            }
        }
    }

    IEnumerator CalcDistErrorBack()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            for (int i = 0; i < cubesBack.Count; i++)
            {
                distanceBack = Vector3.Distance(doigt.transform.position, cubesBack[i].transform.position);
                if (distanceBack <= sensi)
                {                    
                    if (doigt.transform.position.z <= cubesBack[i].transform.position.z)
                    {
                        messageDistBack = cubesBack[i].name + " + " + distanceBack;
                    }
                    else
                    {
                        messageDistBack = cubesBack[i].name + " - " + distanceBack;
                    }
                }

                else
                {
                    messageDistBack = " ";
                }
                yield return messageDistFront;
            }
        }
    }

    IEnumerator CalcPos()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            distancePos = Vector3.Distance(doigt.transform.position, sphere.transform.position);
            if (distancePos <= sensi)
            {
                messagePos = "Doigt a l origine";
            }

            else
            {
                messagePos = " ";
            }
            yield return distancePos;
        }
    }
}
