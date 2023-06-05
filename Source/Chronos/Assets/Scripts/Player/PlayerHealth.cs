using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private bool _alive = true;
    private int _curHealth;
    private int _maxHealth = 5;

    private float _regenarationTimeCounter = 0;
    private float _regenerationTimeLength = 10;
    private int _regenerationValue = 0;
    public int RegenerationValue { get { return _regenerationValue; } set { _regenerationValue = value; } }

    private float _invincibleCounter = 0;
    private float _invincibleLength = 1;

    [SerializeField] private ProgressBar _healthBar;
    [SerializeField] private SpawnSequence _spawnSequence;
    [SerializeField] private InfoText _uiInfoTextMain;
    [SerializeField] private InfoText _uiInfoText;
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameObject _deathEffectPrefab;

    private void Start()
    {
        _curHealth = _maxHealth;
        _healthBar.SetProgress(_curHealth, _maxHealth);
        _regenarationTimeCounter = _regenerationTimeLength;
    }

    private void Update()
    {
        Regeneration();
        UpdateInvincible();
    }

    private void Regeneration()
    {
        if (_regenarationTimeCounter > 0)
        {
            _regenarationTimeCounter -= Time.deltaTime;

            if (_regenarationTimeCounter <= 0)
            {
                _regenarationTimeCounter += _regenerationTimeLength;
                Heal(_regenerationValue);
            }
        }
    }

    private void UpdateInvincible()
    {
        if (_invincibleCounter > 0)
        {
            _invincibleCounter -= Time.deltaTime;
        }
    }

    public bool IsInvincible()
    {
        if (_invincibleCounter > 0)
        {
            return true;
        }

        return false;
    }

    public void GetDamage(int value, Vector2 fromDirection)
    {
        if (_alive && _invincibleCounter <= 0)
        {
            _curHealth -= value;
            _healthBar.SetProgress(_curHealth, _maxHealth);
            GetComponent<PlayerMovement>().Knockback(fromDirection);
            _invincibleCounter = _invincibleLength;
            GameObject.Find("MainCamera").GetComponent<CameraController>().StartScreenShake(0.3f, 0.05f, 15);

            if (_curHealth <= 0)
            {
                Remove();
            }
        }
    }

    public void Heal(int value)
    {
        _curHealth += value;

        if (_curHealth >= _maxHealth)
        {
            _curHealth = _maxHealth;
        }

        _healthBar.SetProgress(_curHealth, _maxHealth);
    }

    public void IncreaseMaxHealth(int value)
    {
        _curHealth += value;
        _maxHealth += value;
        _healthBar.SetProgress(_curHealth, _maxHealth);
    }

    private void Remove()
    {
        _alive = false;

        for (int i = 0; i < 20; i++)
        {
            Vector2 position = transform.position;
            Vector2 rndPosition = new Vector2(Random.Range(-200, 200), Random.Range(-200, 200));
            Instantiate(_deathEffectPrefab, position + rndPosition, Quaternion.identity);
        }

        GameObject.Find("MainCamera").GetComponent<CameraController>().StartScreenShake(0.5f, 0.05f, 30);
        _spawnSequence.StopTime();
        _gameController.SetGameOver();
        Destroy(gameObject);
    }
}
