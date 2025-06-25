using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    // Commenting the below logic of adding listeners for the buttons on main menu (as we did for GameoverUI in LevelUI.cs)
    // as we are using the 2nd method of doing it for smaller projects, i.e., adding listeners via the Unity Inspector

    // public Button playButton;
    // public Button quitButton;
    // private const int firstLevel = 1;
    // private void Awake()
    // {
    //     AddListeners();
    // }
    // private void AddListeners()
    // {
    //     playButton.onClick.AddListener(Play);
    //     quitButton.onClick.AddListener(Quit);
    // }

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        if (soundManager == null)
        {
            Debug.LogError("SoundManager not found in the scene.");
        }
    }
    private const int firstLevel = 1;  // Define the first level to load

    public void Play()
    {
        soundManager.PlayButtonClickAudio();
        SceneManager.LoadScene(firstLevel);  // Load the first level
    }

    public void Quit()
    {
        soundManager.PlayButtonClickAudio();
        Application.Quit();  // Quit the game
      //  Debug.Log("Game quit"); // Unity doesn't quit in the editor, so we log it
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}