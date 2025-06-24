using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public int CurrentSceneIndex { get; private set; }


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
        Debug.Log("next scene index: " + nextSceneIndex);
        Debug.Log("total number of scenes: " + totalNumberOfScenes);
	    
	    if (nextSceneIndex < totalNumberOfScenes)
	    {
	        SceneManager.LoadScene(nextSceneIndex);
	    }
	    else
	    {
	        Debug.Log("You've completed all levels!");
	    }
		}

    public void OnPlayerDeath() => RestartLevel();

	public void RestartLevel() => SceneManager.LoadScene(CurrentSceneIndex);
}