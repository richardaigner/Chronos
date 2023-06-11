using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] int _value = 1;
    [SerializeField] bool _itemXp;
    [SerializeField] bool _itemKey;
    [SerializeField] bool _itemChest;
    
    [SerializeField] bool _moveOnSpawn;
    private Vector2 _randomDropPosition;

    private bool _moveToPlayer = false;
    private float _moveSpeed = 250;
    private float _moveSpeedIncrease = 1.01f;
    private float _collectRadius = 30;

    private InfoText _uiInfoText;
    private GameObject _player;
    [SerializeField] private GameObject _destroyEffectPrefeb;
    [SerializeField] private GameObject _pickupSoundPrefab;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _uiInfoText = GameObject.Find("InfoText").GetComponent<InfoText>();
        
        if (_itemKey)
        {
            StartCoroutine(MoveToPlayer(10.0f));
        }

        if (_moveOnSpawn )
        {
            _randomDropPosition = transform.position + new Vector3(Random.Range(-50, 50), Random.Range(-50, 50));
        }
    }

    IEnumerator MoveToPlayer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _moveToPlayer = true;
    }

    private void Update()
    {
        if (_player != null)
        {
            CheckRangeToPlayer();

            if (_moveToPlayer)
            {
                MoveToPlayer();
            }
            else if (_moveOnSpawn)
            {
                SpawnMovement();
            }
        }
    }

    private void CheckRangeToPlayer()
    {
        float distance = Vector2.Distance(_player.transform.position, transform.position);

        if (!_moveToPlayer && distance <= _player.GetComponent<PlayerItems>().PickUpRange)
        {
            _moveToPlayer = true;
        }

        if (_moveToPlayer && distance <= _collectRadius)
        {
            PlayerCollected();
        }
    }

    private void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _moveSpeed * Time.deltaTime);
        _moveSpeed += _moveSpeed * _moveSpeedIncrease * Time.deltaTime;
    }

    private void SpawnMovement()
    {
        float distance = Vector2.Distance(transform.position, _randomDropPosition);
        transform.position = Vector2.MoveTowards(transform.position, _randomDropPosition, 5 * distance * Time.deltaTime);

        if (Vector2.Distance(transform.position, _randomDropPosition) <= 1)
        {
            _moveOnSpawn = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCollected();
        }
    }

    private void PlayerCollected()
    {
        RemoveObject();
        Instantiate(_pickupSoundPrefab, transform.position, Quaternion.identity);

        if (_itemXp)
        {
            _player.GetComponent<PlayerLevel>().AddXp(_value);
        }
        if (_itemKey)
        {
            DataController dataController = GameObject.Find("UI").GetComponent<DataController>();
            dataController.Keys++;
            dataController.SaveData();

            GameObject.Find("Level").GetComponent<SpawnSequence>().CollectedKeys--;

            _uiInfoText.ShowText(1, 3, "You collected a key!");
        }
        if (_itemChest)
        {
            _player.GetComponent<PlayerItems>().AddRandomWeapon();
            _uiInfoText.ShowText(1, 3, "You got a new weapon upgrade!");
        }
    }

    private void RemoveObject()
    {
        GetComponent<Collider2D>().enabled = false;
        Instantiate(_destroyEffectPrefeb, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
