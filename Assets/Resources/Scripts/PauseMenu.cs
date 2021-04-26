using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject deadMenu;

    private void Awake()
    {
        deadMenu = GameObject.Find("PauseMenu");
        deadMenu.SetActive(false);
    }

    public void DeadMenuActivate()
    {
        deadMenu.SetActive(true);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
