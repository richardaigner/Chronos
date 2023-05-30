using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool _alive = true;
    private int _curHealth;
    private int _maxHealth = 10;

    [SerializeField] private ProgressBar _healthBar;

    private void Start()
    {
        _curHealth = _maxHealth;
        _healthBar.SetProgress(_curHealth, _maxHealth);
    }

    public void GetDamage(int value, Vector2 fromDirection)
    {
        if (_alive)
        {
            _curHealth -= value;
            _healthBar.SetProgress(_curHealth, _maxHealth);
            GetComponent<PlayerMovement>().Recoil(fromDirection);

            if (_curHealth <= 0)
            {
                Remove();
            }
        }
    }

    public void Heal(int value)
    {

        _healthBar.SetProgress(_curHealth, _maxHealth);
    }

    private void Remove()
    {
        _alive = false;
        this.gameObject.SetActive(false);
    }
}
