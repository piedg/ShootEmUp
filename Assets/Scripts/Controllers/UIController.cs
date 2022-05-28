using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoSingleton<UIController>
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject startGamePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject inGamePanel;
    [SerializeField] Image healthBar;

    private void Start()
    {
        ActiveStartGamePanel(true);
    }

    public void ActiveStartGamePanel(bool isActive)
    {
        startGamePanel.SetActive(isActive);
    }

    public void ActiveGameOverPanel(bool isActive)
    {
        gameOverPanel.SetActive(isActive);
    }

    public void ActiveHUD(bool isActive)
    {
        inGamePanel.SetActive(isActive);
    }

    public void UpdateScoreText(int scoreValue)
    {
        scoreText.text = "Score: " + scoreValue;
    }

    public void UpdateHealthbar(float healthValue)
    {
        healthBar.fillAmount = healthValue;
    }
}