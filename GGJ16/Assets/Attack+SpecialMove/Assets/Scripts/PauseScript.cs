using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    GameObject PauseMenu;
    bool paused;



    //Use this for initialization
    void Start()
    {
        

        paused = false;
        PauseMenu = GameObject.Find("PauseMenu");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            paused = !paused;

        }

        if (paused)
        {

            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        else if (!paused)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void Resume()
    {
        paused = false;

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void QuitGame()
    {
        Application.Quit();

    }


}
