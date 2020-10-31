using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitterBehaviour : MonoBehaviour
{
    private Vector3 _bulletVelocity;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private float _coolDown;
    [SerializeField]
    private BulletBehaviour _bullet;
    public string owner;

    // Start is called before the first frame update
    void Start()
    {
        //Owner is set to be whatever game object is holding the gun
        owner = transform.parent.name;
    }

    public void Fire()
    {
        //Create a clone of the bullet
        GameObject bullet = Instantiate(_bullet.gameObject, transform.position, transform.rotation);
        //Grab the bullet script attached
        BulletBehaviour bulletComponent = bullet.GetComponent<BulletBehaviour>();
        //Set the bullets owner to be the owner of the gun
        bulletComponent.owner = owner;
        //Set the velocity of the bullet to be the guns bullet velocity
        bulletComponent.SetVelocity(_bulletVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        //Update the bullet velocity to be our current forward scaled by the bullet speed
        _bulletVelocity = transform.forward * _bulletSpeed;
    }
}
