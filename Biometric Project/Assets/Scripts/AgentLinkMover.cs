using System.Collections;
using System.Collections.Generic;
using System; 
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
                Debug.Log("Entered mesh link");     
                yield return Walk();

                agent.CompleteOffMeshLink(); 
            }
            yield return null; 
        }
    }

    private IEnumerator Walk()
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;

        RaycastHit hit;
        Debug.DrawLine(data.startPos, data.endPos);
        if (Physics.Raycast(data.startPos, data.endPos, out hit, 10f))
        {
            if (hit.collider.tag == "Door")
            {
                //Debug.Log("Door found");
                agent.isStopped = true;
                yield return null; 
            }
            else
            {
                agent.isStopped = false; 
            }
        }

        while (agent.transform.position != endPos)
        {
            //Debug.Log("Walking through door"); 
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, endPos, agent.speed * Time.deltaTime);
            yield return null;
        }
    }
}
