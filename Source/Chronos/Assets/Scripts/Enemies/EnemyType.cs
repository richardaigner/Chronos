using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    [SerializeField] private AnimatorController[] _enemies;
    [SerializeField] private Animator _animator;

    public void LoadEnemy(int enemyId)
    {
        _animator.runtimeAnimatorController = _enemies[enemyId];
    }
}
