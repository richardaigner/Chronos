using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private enum GameState { Play, Pause, Gameover, LevelFinished }
    private GameState _gameState = 0;

    [SerializeField] private InfoText _uiInfoTextMain;
    [SerializeField] private InfoText _uiInfoUpgrade;
    [SerializeField] private InfoText _uiInfoText;

    [SerializeField] private UpgradeSelect _upgradeSelect;
    [SerializeField] private CameraController _cameraController;

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
        if (!_upgradeSelect.Active)
        {
            if (Input.GetButtonDown("Escape"))
            {
                if (_gameState == GameState.Play)
                {
                    PauseGame();
                }
                else if (_gameState == GameState.Pause)
                {
                    UnPauseGame();
                }
                else if (_gameState == GameState.Gameover || _gameState == GameState.LevelFinished)
                {
                    UnPauseGame();
                    _cameraController.ActivateFadeOut();
                    StartCoroutine(GotoMenu(0.5f));
                }

            }
            else if (Input.GetButtonDown("Quit"))
            {
                if (_gameState == GameState.Pause)
                {
                    UnPauseGame();
                    _cameraController.ActivateFadeOut();
                    StartCoroutine(GotoMenu(0.5f));
                }
            }
            else if (Input.GetButtonDown("Restart"))
            {
                if (_gameState == GameState.Gameover)
                {
                    UnPauseGame();
                    _cameraController.ActivateFadeOut();
                    StartCoroutine(RestartLevel(0.5f));
                }
            }
        }
    }

    IEnumerator GotoMenu(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator RestartLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PauseGame()
    {
        _gameState = GameState.Pause;
        _uiInfoTextMain.ShowTextNow("Game Paused");
        _uiInfoText.ShowTextNow("press esc to resume | press q to go back to main menu");
        Time.timeScale = 0;
    }

    private void UnPauseGame()
    {
        _gameState = GameState.Play;
        _uiInfoTextMain.HideText();
        _uiInfoText.HideText();
        Time.timeScale = 1;
    }

    public void SetGameOver()
    {
        _gameState = GameState.Gameover;
        _uiInfoTextMain.ShowText(1, 100000, "GAMEOVER");
        _uiInfoUpgrade.ShowText(2, 100000, "upgrade your skills with collected keys and try again");
        _uiInfoText.ShowText(2, 100000,"press r to restart | press esc to quit");
    }

    public void SetLevelFinished()
    {
        _gameState = GameState.LevelFinished;
        _uiInfoTextMain.ShowTextNow("LEVEL FINISHED!");
        _uiInfoUpgrade.ShowText(2, 100000, "upgrade your skills with collected keys");
        _uiInfoText.ShowTextNow("press esc to quit");
    }
}
