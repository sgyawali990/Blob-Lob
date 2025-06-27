using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownUI : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject controlsImage;
    public float countdownTime = 10f;

    void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        Time.timeScale = 0f;

        controlsImage.SetActive(true);
        countdownText.gameObject.SetActive(true);

        float remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            countdownText.text = Mathf.CeilToInt(remainingTime).ToString();
            yield return new WaitForSecondsRealtime(1f);
            remainingTime -= 1f;
        }

        countdownText.text = "GO";
        yield return new WaitForSecondsRealtime(1f);

        controlsImage.SetActive(false);
        countdownText.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }
}
