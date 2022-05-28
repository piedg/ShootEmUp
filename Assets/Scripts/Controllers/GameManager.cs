using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    bool isPlaying = false;
    public bool IsPlaying { get { return isPlaying; } }
    bool isPaused = false;
    public bool IsPaused { get { return isPaused; } }

    int score = 0;
    public GameObject flameFXPrefab;

    Player player;
    Health playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerHealth = player.GetComponent<Health>();

        PauseGame();
        UIController.Instance.UpdateScoreText(score);
        UIController.Instance.UpdateHealthbar(playerHealth.currentHealth / playerHealth.maxHealth);
        UIController.Instance.ActiveGameOverPanel(false);
        UIController.Instance.ActiveHUD(false);
    }

    void Update()
    {
        UIController.Instance.UpdateScoreText(score);
        UIController.Instance.UpdateHealthbar((float)playerHealth.currentHealth / (float)playerHealth.maxHealth);

        if (playerHealth.isDead)
        {
            GameOver();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;

        if (isPlaying)
        {
            // TODO
        }
    }

    public void StartGame()
    {
        isPlaying = true;
        UIController.Instance.ActiveStartGamePanel(false);
        UIController.Instance.ActiveHUD(true);
        UnpauseGame();

        player.gameObject.SetActive(true);
        player.transform.position = player.initalPos;
        playerHealth.isDead = false;
        playerHealth.currentHealth = playerHealth.maxHealth;
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    private void GameOver()
    {
        isPlaying = false;
        UIController.Instance.ActiveGameOverPanel(true);
        PauseGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void AddScore(int _value)
    {
        score += _value;
    }
}
