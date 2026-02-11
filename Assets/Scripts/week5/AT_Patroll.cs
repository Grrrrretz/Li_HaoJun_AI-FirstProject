using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Patroll : ActionTask {

        public List<Transform> patrolPoints;


        private NavMeshAgent navAgent;

        private int currentPaatrolPointIndex;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            currentPaatrolPointIndex = 0;
            navAgent.SetDestination(patrolPoints[0].position);


        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            if (navAgent.remainingDistance < 0.25f && navAgent.pathPending)
            {
                Debug.Log("We have arrived!");
            }
                currentPaatrolPointIndex++;

            if(currentPaatrolPointIndex >= patrolPoints.Count)
            {
                currentPaatrolPointIndex = 0;
            }

            Vector3 nextposition = patrolPoints[currentPaatrolPointIndex].position;
            navAgent.SetDestination(nextposition);
        }

        //Called when the task is disabled.
        protected override void OnStop()
        {

        }
		//EndAction can be called from anywhere.

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}