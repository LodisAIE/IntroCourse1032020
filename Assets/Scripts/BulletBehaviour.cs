using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    private Vector3 _velocity;
    [SerializeField]
    private float _despawnTime;
    public string owner;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _despawnTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        HealthBehaviour health = other.GetComponent<HealthBehaviour>();
        if(health != null && other.name != owner)
        {
            health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + _velocity * Time.deltaTime;
    }
}
