using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBehaviour : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    private float _rightOffset;
    [SerializeField]
    private float _distanceFromTarget;
    [SerializeField]
    private float _heightAboveTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the camera doesn't have a target to look at, don't set its position
        if (target == null)
            return;

        //Offset the position of the camera to follow our player, and update it's rotation
        transform.position = target.position + (target.right * _rightOffset) + (target.up * _heightAboveTarget) - (target.forward * _distanceFromTarget);
        transform.rotation = target.rotation;
    }
}
