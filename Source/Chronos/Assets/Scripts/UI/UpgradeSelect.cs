using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSelect : MonoBehaviour
{
    [SerializeField] private GameObject _button; // temp - for testing only

    private void Start()
    {
        HideUpgradeWindow();
    }

    private void Update()
    {
        // for testing
        if (Input.GetAxisRaw("Select1") == 1 || Input.GetAxisRaw("Select2") == 1 || Input.GetAxisRaw("Select3") == 1 || Input.GetAxisRaw("Dash") == 1)
        {
            _button.GetComponent<ButtonAttack>().IncreaseAttackSpeed();
            //_button.GetComponent<>
            HideUpgradeWindow();
        }
    }

    private void HideUpgradeWindow()
    {
        ResumeGame();
        this.gameObject.SetActive(false);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
