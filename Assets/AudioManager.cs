using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip menuMusic;
    public AudioClip inGameMusic;
    public AudioClip victoryMusic;

    public AudioClip gunshotSE;
    public AudioClip deathSE;
    public AudioClip respawnSE;

    public bool MusicEnabled { get; private set; } = true;
    public bool SFXEnabled { get; private set; } = true;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusicForScene(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    void PlayMusicForScene(string sceneName)
    {
        if (!MusicEnabled) return;

        AudioClip clipToPlay = null;

        if (sceneName == "MainMenu")
            clipToPlay = menuMusic;
        else if (sceneName == "GameScene")
            clipToPlay = inGameMusic;
        else if (sceneName == "VictoryScene")
            clipToPlay = victoryMusic;

        if (clipToPlay != null && musicSource.clip != clipToPlay)
        {
            musicSource.Stop();
            musicSource.clip = clipToPlay;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void ToggleMusic(bool isOn)
    {
        MusicEnabled = isOn;
        musicSource.mute = !isOn;

        if (isOn && !musicSource.isPlaying)
        {
            PlayMusicForScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ToggleSFX(bool isOn)
    {
        SFXEnabled = isOn;
        sfxSource.mute = !isOn;
    }

    public void PlayMenuMusic()
    {
        PlayMusic(menuMusic);
    }

    public void PlayGameMusic()
    {
        PlayMusic(inGameMusic);
    }

    public void PlayVictoryMusic()
    {
        PlayMusic(victoryMusic);
    }

    void PlayMusic(AudioClip clip)
    {
        if (!MusicEnabled || clip == null) return;

        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (SFXEnabled && clip != null)
            sfxSource.PlayOneShot(clip);
    }
}