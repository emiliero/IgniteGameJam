using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Slider volumeSlider;

    void Awake()
    {
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        volumeSlider.value = LoadVolume();

            // Kun et eksempel på hvordan man debugger verdier i consollen.
        Debug.Log("Demo Debug. Volumet er satt til " + volumeSlider.value);           
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

    public void LoadLevel(int lvl)
    {
        SceneManager.LoadScene("Level" + lvl.ToString());
    }
}
