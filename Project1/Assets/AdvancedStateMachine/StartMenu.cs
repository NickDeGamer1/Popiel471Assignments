using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    void OnStart()
    {
        StartGame();
    }

    void OnExit()
    {
        ExitGame();
    }

    void StartGame()
    {
        SceneManager.LoadScene("AdvancedStateMachine");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
