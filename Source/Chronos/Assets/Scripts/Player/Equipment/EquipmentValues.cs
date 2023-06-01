public class EquipmentValues
{
    private int _health;
    private int _regenerationValue;
    private float _moveSpeed;
    private float _dashForce;
    private float _pickUpRange;
    private float _attackSpeed;
    private float _attackRange;
    private float _shotScale;
    private float _shotDamage;
    private float _shotMoveSpeed;
    
    public int Health { get { return _health; } }
    public int RegenerationValue { get { return _regenerationValue; } }
    public float MoveSpeed { get { return _moveSpeed; } }
    public float DashForce { get { return _dashForce; } }
    public float PickUpRange { get { return _pickUpRange; } }
    public float AttackSpeed { get { return _attackSpeed; } }
    public float AttackRange { get { return _attackRange; } }
    public float ShotScale { get { return _shotScale; } }
    public float ShotDamage { get { return _shotDamage; } }
    public float ShotMoveSpeed { get { return _shotMoveSpeed; } }

    public EquipmentValues(int health, int regenerationValue, float moveSpeed, float dashForce, float pickUpRange,  float attackSpeed, float attackRange, float shotScale, float shotDamage, float shotMoveSpeed)
    {
        _health = health;
        _regenerationValue = regenerationValue;
        _moveSpeed = moveSpeed;
        _dashForce = dashForce;
        _pickUpRange = pickUpRange;
        _attackSpeed = attackSpeed;
        _attackRange = attackRange;
        _shotScale = shotScale;
        _shotDamage = shotDamage;
        _shotMoveSpeed = shotMoveSpeed;
        
    }
}