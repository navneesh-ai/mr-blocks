using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class LevelUI : MonoBehaviour
{
    public GameObject levelPanel;
    public TextMeshProUGUI levelText;
    public int levelNumber = 1;

    public GameObject gameOverPanel;

    public Button restartButton;
    public Button menuButton;
    public LevelManager levelManager;

    public TextMeshProUGUI gameOverText;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        if (soundManager == null)
        {
            Debug.LogError("SoundManager not found in the scene.");
        }
    }

    private void Start()
    {
        // Set levelNumber using LevelManager's property
        levelNumber = levelManager.CurrentLevelNumber;
        UpdateLevelText();
        AddListeners(); // This sets up the click event ONCE at the start

    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + levelNumber;
    }

    private void HideLevelPanel()
    {
        levelPanel.SetActive(false);
    }

    private void SetGameOverPanel(bool isActive) => gameOverPanel.SetActive(isActive);

    private void AddListeners()
    {
        restartButton.onClick.AddListener(RestartButton);
        menuButton.onClick.AddListener(MainMenuButton);
    }

    private void RestartButton()
    {
        //Debug.Log("Restart button clicked!");
        soundManager.PlayButtonClickAudio();
        levelManager.RestartLevel();
    }

    private void MainMenuButton()
    {
        soundManager.PlayButtonClickAudio();
        soundManager.DestroySoundManager();  // Destroy the current SoundManager
        levelManager.LoadMainMenu();
    }

    public void ShowGameWinUI()
    {
        SetGameOverPanel(true);
        
        gameOverText.text = "Game Completed!!";
        gameOverText.color = Color.green;
        HideLevelPanel();
    }

    public void ShowGameLoseUI()
    {
        SetGameOverPanel(true);
        
        gameOverText.text = "Game Over!!";
        gameOverText.color = Color.red;
        HideLevelPanel();
    }
}