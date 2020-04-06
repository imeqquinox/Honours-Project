using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterController : MonoBehaviour
{
    private enum State
    {
        Idle, 
        Walking, 
        Crawling, 
        Running, 
        JumpAttack
    };

    private Transform target;
    private float rot_speed = 10f; 
    private float look_radius = 10f;
    private NavMeshAgent agent;
    private State current_state = State.Idle;
    private Animator animator; 

    private void Start()
    {
        current_state = State.Idle;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
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

        StateMachine();
        KeyboardDebug();
    }

    // Rotation function towards target
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion look_rot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look_rot, Time.deltaTime * rot_speed); 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, look_radius);
    }

    private void StateMachine()
    {
        switch(current_state)
        {
            case State.Idle:
                foreach (AnimatorControllerParameter parameter in animator.parameters)
                {
                    animator.SetBool(parameter.name, false); 
                }
                animator.SetBool("idle", true); 
                break;

            case State.Walking:
                foreach (AnimatorControllerParameter parameter in animator.parameters)
                {
                    animator.SetBool(parameter.name, false);
                }
                animator.SetBool("walking", true);
                break;

            case State.Crawling:
                foreach (AnimatorControllerParameter parameter in animator.parameters)
                {
                    animator.SetBool(parameter.name, false);
                }
                animator.SetBool("crawling", true);
                break;

            case State.Running:
                foreach (AnimatorControllerParameter parameter in animator.parameters)
                {
                    animator.SetBool(parameter.name, false);
                }
                animator.SetBool("running", true);
                break;

            case State.JumpAttack:
                foreach (AnimatorControllerParameter parameter in animator.parameters)
                {
                    animator.SetBool(parameter.name, false);
                }
                animator.SetBool("attack", true);
                break;

            default:
                break; 
        }
    }

    private void KeyboardDebug()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            current_state = State.Idle;
            Debug.Log("Idle"); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            current_state = State.Walking;
            Debug.Log("Walking");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            current_state = State.Crawling;
            Debug.Log("Crawling");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            current_state = State.Running;
            Debug.Log("Running");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            current_state = State.JumpAttack;
            Debug.Log("Attack");
        }
    }
}
