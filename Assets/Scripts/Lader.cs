using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lader : MonoBehaviour
{
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private Transform _positionDeck;
    [SerializeField] private GameObject _player;

    private PlayerController _playerController;

    private void Start()
    {
        if (_player.TryGetComponent(out PlayerController playerController) == false)
        {
            Debug.LogError("Player not specified");
        }
        _playerController = playerController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _playerCollider)
        {
            _player.transform.position = _positionDeck.position;
            _playerController.onDesk = true;
            _playerController.onFloor = false;
        }
    }
}
