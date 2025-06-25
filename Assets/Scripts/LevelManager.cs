using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public int CurrentSceneIndex { get; private set; }

    public LevelUI levelUI;

    private const int mainMenuIndex = 0;
    private const int firstLevelBuildIndex = 1; 

    public int CurrentLevelNumber => CurrentSceneIndex - firstLevelBuildIndex + 1;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
	public void OnLevelComplete() => LoadNextLevel();
		
    private void LoadNextLevel()
		{
	    int nextSceneIndex = CurrentSceneIndex + 1;
	    int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;
       // Debug.Log("next scene index: " + nextSceneIndex);
       // Debug.Log("total number of scenes: " + totalNumberOfScenes);
	    
	    if (nextSceneIndex < totalNumberOfScenes)
	    {
	        SceneManager.LoadScene(nextSceneIndex);
	    }
	    else
	    {
	         levelUI.ShowGameWinUI();
	    }
		}

    public void OnPlayerDeath()
    {
        levelUI.ShowGameLoseUI();
    }

	public void RestartLevel() => SceneManager.LoadScene(CurrentSceneIndex);

    public void LoadMainMenu() => SceneManager.LoadScene(mainMenuIndex);
}