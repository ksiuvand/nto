using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ForLeft : MonoBehaviour
{
    [SerializeField] private Hand _rightHand;
    [SerializeField] private GameObject _right;

    private Throwable _rightThrowable;
    private void Start()
    {
        _rightThrowable = _right.GetComponent<Throwable>();
    }
    private void Update()
    {
        if (_rightHand.currentAttachedObject == gameObject)
        {
            Debug.Log(1);
            _rightHand.DetachObject(gameObject);
            _rightHand.AttachObject(_right, GrabTypes.None, _rightThrowable.attachmentFlags);
        }
    }
}
