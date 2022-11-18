using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
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
            // Scene Home
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (SceneManager.GetActiveScene().name == "Experience2")
                {
                    SceneManager.LoadScene("Home");
                }
                else
                {
                    SceneManager.LoadScene("Experience2");
                }
                timer = 0;
            }
            // Scene 1
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (SceneManager.GetActiveScene().name == "Experience2")
                {
                    SceneManager.LoadScene("Experience1");
                }
                else
                {
                    SceneManager.LoadScene("Experience2");
                }
                timer = 0;
            }

            // Scene 3
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (SceneManager.GetActiveScene().name == "Experience2")
                {
                    SceneManager.LoadScene("Experience3");
                }
                else
                {
                    SceneManager.LoadScene("Experience2");
                }
                timer = 0;
            }

            // Scene Main -> Get all scene in one
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (SceneManager.GetActiveScene().name == "Experience2")
                {
                    SceneManager.LoadScene("Main");
                }
                else
                {
                    SceneManager.LoadScene("Experience2");
                }
                timer = 0;
            }
        }
    }
}
