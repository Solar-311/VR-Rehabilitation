using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerHome : MonoBehaviour
{
    public Material skybox;

    // Spam delay Timer
    public float spamDelay;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Timer set
        timer = Time.time;

        Scene scene = SceneManager.GetActiveScene();
        RenderSettings.skybox = skybox;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spamDelay)
        {
            // Scene 1
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (SceneManager.GetActiveScene().name == "Home")
                {
                    SceneManager.LoadScene("Experience1");
                }
                else
                {
                    SceneManager.LoadScene("Home");
                }
                timer = 0;
            }

            // Scene 2
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (SceneManager.GetActiveScene().name == "Home")
                {
                    SceneManager.LoadScene("Experience2");
                }
                else
                {
                    SceneManager.LoadScene("Home");
                }
                timer = 0;
            }

            // Scene 3
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (SceneManager.GetActiveScene().name == "Home")
                {
                    SceneManager.LoadScene("Experience3");
                }
                else
                {
                    SceneManager.LoadScene("Home");
                }
                timer = 0;
            }

            // Scene Main -> Get all scene in one
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (SceneManager.GetActiveScene().name == "Home")
                {
                    SceneManager.LoadScene("Main");
                }
                else
                {
                    SceneManager.LoadScene("Home");
                }
                timer = 0;
            }
        }
    }
}
