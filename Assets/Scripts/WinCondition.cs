using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [Header("Puntaje")]
    [SerializeField] private int _scoreToWin;

    private int _currentScore;

    public void AddScore(int score)
    {
        _currentScore += score;

        Debug.Log("Puntaje: " + _currentScore);

        if (_currentScore >= _scoreToWin)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        SceneManager.LoadScene(3);
    }

    public int GetScore()
    {
        return _currentScore;
    }
}