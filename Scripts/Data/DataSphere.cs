using System.Collections;
using UnityEngine;
using System.IO;
using System;
using Vector3 = UnityEngine.Vector3;

public class DataSphere : MonoBehaviour
{
    // Variables
    public GameObject currentObject;
    public GameObject controller;
    public string inputReset;
    public float r;
    public float theta;
    public float y;

    // Timer
    private float timer;

    // Variables internes
    private float speed;
    private float dist;
    private string distance;
    private Vector3 stopPos;
    private float distanceController;
    private float distanceOrigine;
    private float distanceFin;
    private string messageA;
    private string messageB;
    private string messageEnter;
    private string messageSpace;

    // Csv Writer variables
    StreamWriter writer;
    string filename;

    // Start is called before the first frame update
    void Start()
    {
        // Calculs
        StartCoroutine(CalcSpeed());
        StartCoroutine(CalcSens());
        StartCoroutine(IfPressedA());
        StartCoroutine(IfPressedB());
        StartCoroutine(CalcDist());
        StartCoroutine(IfPressedEnter());
        StartCoroutine(IfPressedSpace());
        StartCoroutine(CalcDistOrigine());
        StartCoroutine(CalcDistFin());

        // Path of CSV file
        filename = Application.dataPath + "/Scripts/Data/DataSphere.csv";

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
                        "Speed; " +
                        "Sens de deplacement; " +
                        "Position stop;" + 
                        "BoutonA;" + 
                        "BoutonB;" + 
                        "Enter;" + 
                        "Space;" + 
                        "Distance de l origine;" + 
                        "Distance de la fin;" + 
                        "Distance Sphere/Camera");
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
            delimiter + (speed) +
            delimiter + (distance) +
            delimiter + (stopPos) +
            delimiter + (messageA) +
            delimiter + (messageB) +
            delimiter + (messageEnter) +
            delimiter + (messageSpace) +
            delimiter + (distanceOrigine) +
            delimiter + (distanceFin) +
            delimiter + (distanceController);

        // Write in CSV File
        writer.WriteLine(dataText);

        // When the scene is reset, the file is reset too
        if (Input.GetKey(inputReset))
        {
            writer.Flush();
            writer.Close();
            Debug.Log("DataSphere file / Statement : Flushed and Closed");
            timer = 0;
        }
    }

    IEnumerator CalcDistOrigine()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            Vector3 origine = new Vector3(0, 0.75f, 0.4f);
            distanceOrigine = Vector3.Distance(origine, currentObject.transform.position);
            yield return distanceOrigine;
        }
    }


    IEnumerator CalcDistFin()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            Vector3 pointB = new Vector3(r * Mathf.Cos(theta * Mathf.Deg2Rad), y, r * Mathf.Sin(theta * Mathf.Deg2Rad));
            distanceFin = Vector3.Distance(pointB, currentObject.transform.position);
            yield return distanceFin;
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

    // Calcul Sens
    IEnumerator CalcSens()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            Vector3 prevPos = currentObject.transform.position;
            yield return new WaitForFixedUpdate();
            dist = currentObject.transform.position.z - prevPos.z;

            if (dist > 0)
            {
                distance = "Positif";
            }

            else if (dist < 0)
            {
                distance = "Negatif";
            }

            else if (dist == 0)
            {
                distance = "Null";
            }

            else
            {
                yield return null;
            }
        }
    }

    // Calcul Stop Position
    IEnumerator IfPressedA()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            stopPos = new Vector3(0.0f, 0.0f, 0.0f);

            if (OVRInput.Get(OVRInput.Button.One))
            {
                stopPos = currentObject.transform.position;
                messageA = "Bouton A";
            }

            else
            {
                messageA = "Null";
                yield return null;
            }

            yield return null;
        }
    }

    // Calcul Distance
    IEnumerator CalcDist()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            distanceController = Vector3.Distance(currentObject.transform.position, controller.transform.position);
            yield return distanceController;
        }
    }

    IEnumerator IfPressedB()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            if (OVRInput.Get(OVRInput.Button.Two))
            {
                messageB = "Bouton B";
            }

            else
            {
                messageB = "Null";
                yield return null;
            }

            yield return null;
        }
    }

    IEnumerator IfPressedEnter()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                messageEnter = "Bouton Return";
            }

            else
            {
                messageEnter = "Null";
                yield return null;
            }

            yield return null;
        }
    }

    IEnumerator IfPressedSpace()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                messageSpace = "Bouton Space";
            }

            else
            {
                messageSpace = "Null";
                yield return null;
            }

            yield return null;
        }
    }
}
