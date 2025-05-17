using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Transform player;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private float fallThresholdOffset = 6f;

    private bool isGameOver = false;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        if (isGameOver || player == null) return;

        float deathY = Camera.main.transform.position.y - fallThresholdOffset;

        if (player.position.y < deathY)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Game Over");

        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }

    // Call this from a UI button to restart
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}