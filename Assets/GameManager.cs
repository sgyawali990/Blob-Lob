using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerHealth player1;
    public PlayerHealth player2;

    public GameObject winScreen;

    [Header("Win UI Elements")]
    public Image winHeadImage;
    public TextMeshProUGUI winLabelText;
    public Sprite redBlobHead;
    public Sprite blueBlobHead;

    private bool gameOver = false;

    void Update()
    {
        if (gameOver) return;

        if (player1.GetCurrentLives() <= 0)
        {
            ShowWinScreen(player2Won: true);
        }
        else if (player2.GetCurrentLives() <= 0)
        {
            ShowWinScreen(player2Won: false);
        }
    }

    void ShowWinScreen(bool player2Won)
    {
        gameOver = true;
        winScreen.SetActive(true);

        if (player2Won)
        {
            winHeadImage.sprite = blueBlobHead;
        }
        else
        {
            winHeadImage.sprite = redBlobHead;
        }

        winLabelText.text = "WINS!";

        player1.enabled = false;
        player2.enabled = false;
    }

    public void Rematch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Quit Game");
    }
}