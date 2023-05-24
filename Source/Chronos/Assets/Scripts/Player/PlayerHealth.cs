using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 10;

    public void GetDamage(int value)
    {
        _health -= value;

        if (_health <= 0)
        {
            Remove();
        }
    }

    private void Remove()
    {
        // todo: gameover
    }
}
