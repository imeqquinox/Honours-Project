using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform target = null;

    private float look_radius = 10f;
    private NavMeshAgent agent; 

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position); 

        if (distance <= look_radius)
        {
            agent.SetDestination(target.position); 

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget(); 
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion look_rot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look_rot, Time.deltaTime * 5f); 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, look_radius); 
    }
}
