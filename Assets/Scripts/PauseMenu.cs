using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private PlayerInput _playerInput;
    private bool _isPaused;

    private void Awake()
    {
        _playerInput = FindFirstObjectByType<PlayerInput>();
    }

    private void Start()
    {
        _pausePanel.SetActive(false);
        _isPaused = false;

        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (_playerInput.actions["Pause"].WasPressedThisFrame())
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        _isPaused = true;

        _pausePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        _isPaused = false;

        _pausePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;

        Application.Quit();
    }
}