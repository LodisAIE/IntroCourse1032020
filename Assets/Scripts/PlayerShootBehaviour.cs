using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    [SerializeField]
    private BulletEmitterBehaviour _gun;

    // Update is called once per frame
    void Update()
    {
        //Check to see if the player pressed the shoot button
        if (Input.GetButtonDown("Fire1"))
        {
            //If so fire the gun
            _gun.Fire();
        }
    }
}
