using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
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
        if (Input.GetButtonDown("Escape") && Time.timeScale == 1)
        {
            PauseGame();
        }
        else if (Input.GetButtonDown("Escape") && Time.timeScale == 0)
        {
            UnPauseGame();
        }
        else if (Input.GetButtonDown("q") && Time.timeScale == 0)
        {
            // todo -> quit -> go back to main menu
            Debug.Log("todo -> quit -> go back to main menu");
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
}
