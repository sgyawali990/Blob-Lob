using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public AudioManager audioManager;
    public Toggle musicToggle;
    public Toggle sfxToggle;

    void Start()
    {
        musicToggle.isOn = audioManager.MusicEnabled;
        sfxToggle.isOn = audioManager.SFXEnabled;

        musicToggle.onValueChanged.AddListener(OnMusicToggle);
        sfxToggle.onValueChanged.AddListener(OnSFXToggle);
    }

    public void PlayGame()
    {
        audioManager.StopMusic();
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit!");
    }

    void OnMusicToggle(bool isOn)
    {
        audioManager.ToggleMusic(isOn);
    }

    void OnSFXToggle(bool isOn)
    {
        audioManager.ToggleSFX(isOn);
    }
}