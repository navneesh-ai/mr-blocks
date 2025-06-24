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