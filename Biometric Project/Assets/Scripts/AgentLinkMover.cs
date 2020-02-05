using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

[RequireComponent(typeof(NavMeshAgent))]
public class AgentLinkMover : MonoBehaviour
{
    [SerializeField] private Transform door_ray = null;
    private NavMeshAgent agent;

    private IEnumerator Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = false; 

        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                yield return DoorDetection(); 
                //yield return Walk();

                //agent.isStopped = true; 
                agent.CompleteOffMeshLink(); 
            }
            yield return null; 
        }
    }

    private IEnumerator Walk()
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        while (agent.transform.position != endPos)
        {
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, endPos, agent.speed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator DoorDetection()
    {
        RaycastHit hit;

        if (Physics.Raycast(door_ray.position, door_ray.TransformDirection(Vector3.forward), out hit, 10f))
        {
            if (hit.collider.tag == "Door")
            {
                Debug.Log("Door found");
                agent.isStopped = true;
                yield return null;
            }
            else
            {
                agent.isStopped = false;
                yield return Walk(); 
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 direction = door_ray.TransformDirection(Vector3.forward) * 10f;
        Gizmos.DrawRay(door_ray.position, direction);
    }
}
