using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ForRight : MonoBehaviour
{
    [SerializeField] private Hand _leftHand;
    [SerializeField] private GameObject _left;

    private Throwable _leftThrowable;
    private void Start()
    {
        _leftThrowable = _left.GetComponent<Throwable>();
    }
    private void Update()
    {
        if (_leftHand.currentAttachedObject == gameObject)
        {
            _leftHand.DetachObject(gameObject);
            _leftHand.AttachObject(_left, GrabTypes.None, _leftThrowable.attachmentFlags);
        }
    }
}
