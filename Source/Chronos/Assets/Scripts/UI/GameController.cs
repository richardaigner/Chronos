using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool _gameOver = false;

    [SerializeField] private InfoText _uiInfoTextMain;
    [SerializeField] private InfoText _uiInfoText;

    private void Start()
    {
        StartCoroutine(LateStart(1.0f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _uiInfoText.ShowText(1, 5, "w a s d -> move | shift -> dash");
    }

    private void Update()
    {
        if (!_gameOver && Input.GetButtonDown("Escape") && Time.timeScale == 1)
        {
            PauseGame();
        }
        else if (!_gameOver && Input.GetButtonDown("Escape") && Time.timeScale == 0)
        {
            UnPauseGame();
        }
        else if (!_gameOver && Input.GetButtonDown("Quit") && Time.timeScale == 0)
        {
            SceneManager.LoadScene("Menu");
        }
        else if (_gameOver && (Input.GetButtonDown("Escape") || Input.GetButtonDown("Quit")))
        {
            SceneManager.LoadScene("Menu");
        }
        else if (_gameOver && Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void PauseGame()
    {
        _uiInfoTextMain.ShowTextNow("Game Paused");
        _uiInfoText.ShowTextNow("press esc to resume | press q to go back to main menu");
        Time.timeScale = 0;
    }

    private void UnPauseGame()
    {
        _uiInfoTextMain.HideText();
        _uiInfoText.HideText();
        Time.timeScale = 1;
    }

    public void SetGameOver()
    {
        _gameOver = true;
        _uiInfoTextMain.ShowText(1, 100000, "GAMEOVER");
        _uiInfoText.ShowText(2, 100000,"press r to restart | press esc to quit");
    }
}
