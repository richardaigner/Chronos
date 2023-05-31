using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool _alive = true;
    private int _curHealth;
    private int _maxHealth = 10;

    private float _regenarationTimeCounter = 0;
    private float _regenerationTimeLength = 10;
    private int _regenerationValue = 1;

    [SerializeField] private ProgressBar _healthBar;

    private void Start()
    {
        _curHealth = _maxHealth;
        _healthBar.SetProgress(_curHealth, _maxHealth);
        _regenarationTimeCounter = _regenerationTimeLength;
    }

    private void Update()
    {
        Regeneration();
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

    public void GetDamage(int value, Vector2 fromDirection)
    {
        if (_alive)
        {
            _curHealth -= value;
            _healthBar.SetProgress(_curHealth, _maxHealth);
            GetComponent<PlayerMovement>().Knockback(fromDirection);

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

    private void Remove()
    {
        _alive = false;
        this.gameObject.SetActive(false);
    }
}
