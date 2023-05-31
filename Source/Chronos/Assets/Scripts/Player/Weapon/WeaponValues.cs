using UnityEngine;

public class WeaponValues
{
    private float _lifetime;
    private float _attackSpeed;
    private bool _piercing;
    private int _damage;
    private bool _homing;
    private float _moveSpeed;
    private float _flyRange;
    private int _projectileCount;
    private float _projectileAngleMod;
    private float _knockbackForce;
    private float _rotationSpeed;
    private float _circularDistance;
    private float _rndFactor;

    public float Lifetime { get { return _lifetime; } }
    public float AttackSpeed { get { return _attackSpeed; } }
    public bool Piercing { get { return _piercing; } }
    public int Damage { get { return _damage; } }
    public bool Homing { get { return _homing; } }
    public float MoveSpeed { get { return _moveSpeed; } }
    public float FlyRange { get { return _flyRange; } }
    public int ProjectileCount { get { return _projectileCount; } }
    public float ProjectileAngleMod { get { return _projectileAngleMod; } }
    public float KnockbackForce { get { return _knockbackForce; } }
    public float RotationSpeed { get { return _rotationSpeed; } }
    public float CircularDistance { get { return _circularDistance; } }
    public float RndFactor { get { return _rndFactor; } }

    public WeaponValues(float lifetime, float attackSpeed, bool piercing, int damage, bool homing, float moveSpeed, float flyRange, int projectileCount, float projectileAngleMod, float knockbackForce, float rotationSpeed, float circularDistance, float rndFactor)
    {
        _lifetime = lifetime;
        _attackSpeed = attackSpeed;
        _piercing = piercing;
        _damage = damage;
        _homing = homing;
        _moveSpeed = moveSpeed;
        _flyRange = flyRange;
        _projectileCount = projectileCount;
        _projectileAngleMod = projectileAngleMod;
        _knockbackForce = knockbackForce;
        _rotationSpeed = rotationSpeed;
        _circularDistance = circularDistance;
        _rndFactor = rndFactor;
    }
}
