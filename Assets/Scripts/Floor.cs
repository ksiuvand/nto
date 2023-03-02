using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Collider _playerCollider;

    private PlayerController _playerController;

    private void Start()
    {
        if (_player.TryGetComponent(out PlayerController playerController) == false)
        {
            Debug.LogError("Player not specified");
        }
        _playerController = playerController;
    }

    private void OnTriggerExit(Collider other)
    {

        if (other == _playerCollider)
        {
            _playerController.onFloor = true;
            //Debug.Log(_newPlayerPosition);
        }
    }
}
