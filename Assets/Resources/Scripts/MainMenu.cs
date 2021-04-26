using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Slider volumeSlider;

    void Awake()
    {
        if (PlayerPrefs.GetFloat("Volume") == null)
        {
            PlayerPrefs.SetFloat("Volume", 1);
        }

        if (GameObject.Find("VolumeSlider"))
        {
            volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
            volumeSlider.value = LoadVolume();

            // Kun et eksempel på hvordan man debugger verdier i consollen.
            Debug.Log("Demo Debug. Volumet er satt til " + volumeSlider.value);
        }
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", GameObject.Find("VolumeSlider").GetComponent<Slider>().value);
    }

    public float LoadVolume()
    {
        return PlayerPrefs.GetFloat("Volume");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
