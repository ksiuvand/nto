using UnityEngine;
public class Paddle : MonoBehaviour
{
    [SerializeField] private GameObject _raft;
    [SerializeField] private Collider _leftOfRaft;
    [SerializeField] private Collider _firstLeftOfRaft;
    [SerializeField] private Collider _secondLeftOfRaft;
    [SerializeField] private Collider _rightOfRaft;
    [SerializeField] private Collider _firstRightOfRaft;
    [SerializeField] private Collider _secondRightOfRaft;
    [SerializeField] private GameObject _gameControllerObject;

    private GameController _gameController;

    [SerializeField] private float MaxDeltaTime = 1.0f;
    [SerializeField] private float _raftDeltaSpeed = 1.0f;
    [SerializeField] private float _raftDeltaAngle = 1.0f;

    private Raft _raftScript;

    private bool _onLeft = false;
    private bool _onRight = false;
    private bool _inLeftFirst = false;
    private bool _inRightFirst = false;
    private float _entryTime = 0;

    private void Start()
    {
        if (_gameControllerObject.TryGetComponent(out GameController gameController) == false)
        {
            Debug.LogError("Uncorrect game controller");
        }
        _gameController = gameController;

        if (_raft.TryGetComponent(out Raft raftScript) == false)
        {
            Debug.LogError("Raft not specified");
        }
        _raftScript = raftScript;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _leftOfRaft)
        {
            _onLeft = true;
        }

        else if (other == _rightOfRaft)
        {
            _onRight = true;
        }

        else if (other == _firstLeftOfRaft)
        {
            _inLeftFirst = true;
            _entryTime = Time.time;
        }

        else if (other == _firstRightOfRaft)
        {
            _inRightFirst = true;
            _entryTime = Time.time;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Time.time - _entryTime > MaxDeltaTime)
            return;

        if (_onLeft)
        {
            if (_inLeftFirst == false)
                return;

            if (other == _secondLeftOfRaft)
            {
                _gameController.speed += _raftDeltaSpeed;
                //_raft.transform.rotation.
                _gameController.angle -= _raftDeltaAngle;
                Debug.Log(_gameController.speed);
            }
        }

        else if (_onRight)
        {
            if (_inRightFirst == false)
                return;

            if (other == _secondRightOfRaft)
            {
                _gameController.speed += _raftDeltaSpeed;
                _gameController.angle += _raftDeltaAngle;
                Debug.Log(_gameController.speed);
            }
        }
    }
}
