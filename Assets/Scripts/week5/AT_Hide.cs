using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Hide : ActionTask {
		public BBParameter<Transform> targetTransform;
		public float fleeDistance;

        public float HideFrequency;


        private float timeSinceLastHide = 0f;
        private NavMeshAgent navAgent;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			SetDestintion();

				}

        void SetDestintion()
		{
                Vector3 DirectionAwayFormTarget = agent.transform.position - targetTransform.value.position;


                Vector3 targetPosition = DirectionAwayFormTarget.normalized * fleeDistance + agent.transform.position;


                navAgent.SetDestination(targetPosition);
            
        }


		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            timeSinceLastHide += Time.deltaTime;
            if (timeSinceLastHide > HideFrequency)
            {
                Vector3 DirectionAwayFormTarget = agent.transform.position - targetTransform.value.position;
                Vector3 targetPosition = DirectionAwayFormTarget.normalized * fleeDistance + agent.transform.position;
                navAgent.SetDestination(targetPosition);
                timeSinceLastHide = 0f;
            }

            

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}