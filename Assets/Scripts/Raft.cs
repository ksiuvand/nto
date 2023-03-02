using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Raft : MonoBehaviour
{
    [SerializeField] private float strength = 100;
    [SerializeField] private Collider _leftOfRaft;
    [SerializeField] private Collider _rightOfRaft;

    private Rigidbody _rdRaft;


    private void Start()
    {
        _rdRaft = GetComponent<Rigidbody>();
    }
    private void Update()
    {
    }


}
