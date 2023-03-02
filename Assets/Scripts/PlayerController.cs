using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool lowHealth = false;
    public bool lowSatiety = false;
    public bool onDesk = false;
    public bool onFloor = true;
    public bool fall = false;
    public bool onLader = false;
    public float currentHealth;
    public float currentSatiety;

    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _deltaHealth = 1;
    [SerializeField] private float _limitHealth = 10;
    
    [SerializeField] private float _maxSatiety = 100;
    [SerializeField] private float _deltaSatiety = 0.1f;
    [SerializeField] private float _limitSatiety = 10;

    [SerializeField] private GameObject _gameControllerObject;

    private GameController _gameController;

    private float _currentDeltaHealth;

    private void Start()
    {
        currentSatiety = _maxSatiety;

        currentHealth = _maxHealth;
        _currentDeltaHealth = _deltaHealth;

        if (_gameControllerObject.TryGetComponent(out GameController gameController) == false)
        {
            Debug.LogError("Uncorrect game controller");
        }
        _gameController = gameController;
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        if (lowHealth)
        {
            Debug.Log("Low health");
        }

        if (lowSatiety)
        {
            Debug.Log("Low satiety");
        }
        if (fall)
        {
            currentHealth -= _deltaHealth * 10;
            fall = false;
        }
        if (onFloor == false && onDesk == false)
        {
            currentHealth -= _currentDeltaHealth;
        }
    }
    private void FixedUpdate()
    {
        currentSatiety -= _deltaSatiety * Time.deltaTime;
        if (currentSatiety <= 0)
        {
            _gameController.GameOver();
        }
        else if (currentSatiety <= _limitSatiety)
        {
            lowSatiety = true;
        }

        if (currentHealth <= 0)
        {
            _gameController.GameOver();
        }
        else if (currentHealth <= _limitHealth)
        {
            lowSatiety = true;
        }
    }
}
