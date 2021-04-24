using UnityEngine;
using UnityEngine.WSA;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Awake()
    {
        // TODO
        // pauseMenu = GameObject.Find("PauseMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;

            // TODO
            // pauseMenu.activeSelf = true;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        // pauseMenu.activeSelf = false;
    }
}
