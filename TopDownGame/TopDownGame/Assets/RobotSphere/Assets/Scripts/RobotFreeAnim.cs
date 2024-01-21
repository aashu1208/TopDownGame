using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotFreeAnim : MonoBehaviour {

	Vector3 rot = Vector3.zero;
	float rotSpeed = 40f;
	Animator anim;

	NavMeshAgent navAgent;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;

		//Initializing navmeshagent
		navAgent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{
		CheckKey();
		gameObject.transform.eulerAngles = rot;
	}

	void CheckKey()
	{

        if (Input.GetMouseButtonDown(0))
        {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
				//set the target position for navmeshagent
				MovetoPosition(hit.point);
            }
        }


		//walk animation control
		anim.SetBool("Walk_Anim", navAgent.velocity.magnitude > 1.0f);

		// Walk
		/*if (Input.GetKey(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", true);
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", false);
		}*/

		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}

		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}

	public void MovetoPosition(Vector3 targetPosition)
    {

		//use navmeshagent to move to the target position
		navAgent.SetDestination(targetPosition);
    }

}
