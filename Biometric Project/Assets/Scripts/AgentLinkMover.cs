using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

[RequireComponent(typeof(NavMeshAgent))]
public class AgentLinkMover : MonoBehaviour
{
    private NavMeshAgent agent;

    private IEnumerator Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = false; 

        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                yield return Walk();

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
}
