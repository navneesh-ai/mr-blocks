using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public GameObject levelPanel;
    public TextMeshProUGUI levelText;
    public int levelNumber = 1;

    private void Start()
    {
        // Set levelNumber to the current scene's build index + 1 (if you want Level 1 for build index 0)
        levelNumber = SceneManager.GetActiveScene().buildIndex + 1;
        UpdateLevelText();
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + levelNumber;
    }

    private void HideLevelPanel()
    {
        levelPanel.SetActive(false);
    }
}