using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLevelSelectController : MonoBehaviour
{
    [SerializeField] private GameObject _buttonLevel01;
    [SerializeField] private GameObject _buttonLevel02;
    [SerializeField] private GameObject _buttonLevel03;
    [SerializeField] private GameObject _buttonBack;

    [SerializeField] private GameObject _main;
    [SerializeField] private Text _keysText;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private DataController _dataController;

    private void Start()
    {
        _buttonLevel01.GetComponent< Button>().onClick.AddListener(OnClickLevel01);
        _buttonLevel02.GetComponent<Button>().onClick.AddListener(OnClickLevel02);
        _buttonLevel03.GetComponent<Button>().onClick.AddListener(OnClickLevel03);
        _buttonBack.GetComponent<Button>().onClick.AddListener(OnClickBack);
        UpdateTextAndButtons();
    }

    private void Update()
    {
        if (Input.GetButton("Dash") && Input.GetButton("Select2") && Input.GetButton("Restart") && Input.GetButtonDown("Hidden"))
        {
            _dataController.LevelProgress = 3;
            _dataController.Keys = 100;
            _dataController.SaveData();
            UpdateTextAndButtons();
        }
    }

    private void OnClickLevel01()
    {
        _cameraController.ActivateFadeOut();
        StartCoroutine(StartLevel01(0.5f));
    }

    IEnumerator StartLevel01(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Level01");
    }

    private void OnClickLevel02()
    {
        _cameraController.ActivateFadeOut();
        StartCoroutine(StartLevel02(0.5f));
    }

    IEnumerator StartLevel02(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Level02");
    }

    private void OnClickLevel03()
    {
        _cameraController.ActivateFadeOut();
        StartCoroutine(StartLevel03(0.5f));
    }

    IEnumerator StartLevel03(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Level03");
    }

    private void OnClickBack()
    {
        _main.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void UpdateTextAndButtons()
    {
        _keysText.text = _dataController.Keys.ToString();

        if (_dataController.LevelProgress >= 1)
        {
            _buttonLevel02.GetComponent<Button>().interactable = true;
            _buttonLevel02.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            _buttonLevel02.GetComponent<Button>().interactable = false;
            _buttonLevel02.GetComponent<BoxCollider2D>().enabled = false;
        }
        
        if (_dataController.LevelProgress >= 2)
        {
            _buttonLevel03.GetComponent<Button>().interactable = true;
            _buttonLevel03.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            _buttonLevel03.GetComponent<Button>().interactable = false;
            _buttonLevel03.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
