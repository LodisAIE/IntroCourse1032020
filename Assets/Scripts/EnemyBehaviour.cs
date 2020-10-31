using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;

    // Start is called before the first frame update
    void Start()
    {
        if (_target == null)
            _target = GameObject.Find("Player");

        GameManagerBehaviour.enemyCount++;
    }


    private void OnCollisionEnter(Collision collision)
    {
        HealthBehaviour health = collision.gameObject.GetComponent<HealthBehaviour>();
        if (health != null && health.name == _target.name)
        {
            health.TakeDamage(_damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the enemy doesn't have a target to chase, don't set its velocity
        if (_target == null)
            return;

        //Finds the direction the enemy needs to move in
        Vector3 direction = _target.transform.position - transform.position;
        //Normalize the direction vector to remove distance from the equation
        direction.Normalize();
        //Move the enemy in the direction found scaled by the speed
        transform.position += direction * _speed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        GameManagerBehaviour.enemyCount--;
    }
}
