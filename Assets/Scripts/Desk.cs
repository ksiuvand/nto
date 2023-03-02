using UnityEngine;

public class Desk : MonoBehaviour
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
            if(_playerController.onLader)
            {
                _playerController.onLader = false;
                return;
            }
            Vector3 _newPlayerPosition = new Vector3(_player.transform.position.x,
                0f, _player.transform.position.z);

            _player.transform.position = _newPlayerPosition;
            _playerController.fall = true;
            _playerController.onFloor = true;
            //Debug.Log(_newPlayerPosition);
        }
    }
}
