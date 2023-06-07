using System.Collections;
using System.Collections.Generic;
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
    private DataController _dataController;

    private void Start()
    {
        _dataController = GetComponent<DataController>();
        _buttonLevel01.GetComponent< Button>().onClick.AddListener(OnClickLevel01);
        _buttonLevel02.GetComponent<Button>().onClick.AddListener(OnClickLevel02);
        _buttonLevel03.GetComponent<Button>().onClick.AddListener(OnClickLevel03);
        _buttonBack.GetComponent<Button>().onClick.AddListener(OnClickBack);

        LoadData();
    }

    private void OnClickLevel01()
    {
        SceneManager.LoadScene("Level01");
    }

    private void OnClickLevel02()
    {
        SceneManager.LoadScene("Level02");
    }

    private void OnClickLevel03()
    {
        SceneManager.LoadScene("Level03");
    }

    private void OnClickBack()
    {
        _main.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void LoadData()
    {
        if (_dataController.LevelProgress == 1)
        {
            _buttonLevel02.GetComponent<Button>().interactable = true;
            _buttonLevel02.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            _buttonLevel02.GetComponent<Button>().interactable = false;
            _buttonLevel02.GetComponent<BoxCollider2D>().enabled = false;
        }
        
        if (_dataController.LevelProgress == 2)
        {
            _buttonLevel03.GetComponent<Button>().interactable = true;
            _buttonLevel03.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            _buttonLevel03.GetComponent<Button>().interactable = false;
            _buttonLevel03.GetComponent<BoxCollider2D>().enabled = false;
        }

        // set keys value
        // set upgrades
    }
}
