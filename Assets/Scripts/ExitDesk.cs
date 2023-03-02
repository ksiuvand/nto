using UnityEngine;

public class ExitDesk : MonoBehaviour
{
    [SerializeField] private Collider _playerCollider;
    //[SerializeField] private Transform _positionDeck;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == _playerCollider)
        {
            Vector3 _newPlayerPosition = Vector3.zero;
            _player.transform.position = _newPlayerPosition;
            _playerController.onLader = true;
            _playerController.onDesk = false;
            _playerController.onFloor = true;
        }
    }
}