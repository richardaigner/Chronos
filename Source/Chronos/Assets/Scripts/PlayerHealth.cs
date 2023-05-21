using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;

    public void GetDamage(int value)
    {
        health -= value;

        if (health <= 0)
        {
            Remove();
        }
    }

    private void Remove()
    {
        // todo: gameover
    }
}
