using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool _alive = true;
    private int _currentHealth;
    private int _maxHealth = 10;

    [SerializeField] private ProgressBar _healthBar;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.UpdateProgress(_currentHealth, _maxHealth);
    }

    public void GetDamage(int value, Vector2 fromDirection)
    {
        if (_alive)
        {
            _currentHealth -= value;
            _healthBar.UpdateProgress(_currentHealth, _maxHealth);
            GetComponent<PlayerMovement>().Recoil(fromDirection);

            if (_currentHealth <= 0)
            {
                Remove();
            }
        }
    }

    public void Heal(int value)
    {

        _healthBar.UpdateProgress(_currentHealth, _maxHealth);
    }

    private void Remove()
    {
        _alive = false;
        this.gameObject.SetActive(false);
    }
}
