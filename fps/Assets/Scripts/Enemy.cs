using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float hp = 10;
    [SerializeField]
    private NavMeshAgent nav;
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(Player.Instance.gameObject.transform.position);
    }
}
