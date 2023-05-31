public class EnemySpawnInterval
{
    private float _nextSpawnTime;
    private float _startTime;
    private float _endTime;
    private float _spawnInterval;
    private int _enemyId;
    private int _enemyLevel;
    private int _enemyAmount;

    public float NextSpawnTime { get { return _nextSpawnTime; } set { _nextSpawnTime = value; } }
    public float StartTime { get { return _startTime; } }
    public float EndTime { get { return _endTime; } }
    public float SpawnInterval { get { return _spawnInterval; } }
    public int EnemyId { get { return _enemyId; } }
    public int EnemyLevel { get { return _enemyLevel; } }
    public int EnemyAmount { get { return _enemyAmount; } }

    public EnemySpawnInterval(float startTime, float endTime, float spawnInterval, int enemyId, int enemyLevel, int enemyAmount)
    {
        _nextSpawnTime = startTime;
        _startTime = startTime;
        _endTime = endTime;
        _spawnInterval = spawnInterval;
        _enemyId = enemyId;
        _enemyLevel = enemyLevel;
        _enemyAmount = enemyAmount;
    }

    public EnemySpawnInterval(string startTime, string endTime, float spawnInterval, int enemyId, int enemyLevel, int enemyAmount): this(ParseTimeString(startTime), ParseTimeString(endTime), spawnInterval, enemyId, enemyLevel, enemyAmount) { }

    private static float ParseTimeString(string time)
    {
        // format mm:ss
        if (int.TryParse(time.Substring(0, 2), out int minutes) && int.TryParse(time.Substring(3, 2), out int seconds))
        {
            return minutes * 60 + seconds;
        }

        return 0;
    }
}