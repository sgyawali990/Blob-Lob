using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public PlayerHealth player1;
    public PlayerHealth player2;
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    public void UpdateLives()
    {
        if (player1 != null && player1Text != null)
            player1Text.text = " " + player1.GetCurrentLives();

        if (player2 != null && player2Text != null)
            player2Text.text = " " + player2.GetCurrentLives();
    }
}
