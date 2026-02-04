using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEditor;
using UnityEngine.AI;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_Seek : ActionTask {

		 NavMeshAgent NavAgent;

		public float seekFrequency;

		public float seekRadius;

		private float timeSinceLastSeek = 0f;

		public BBParameter<Transform> targetTransform;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			NavAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			NavAgent.SetDestination(targetTransform.value.position);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timeSinceLastSeek += Time.deltaTime;
			if(timeSinceLastSeek > seekFrequency)
			{
                NavAgent.SetDestination(targetTransform.value.position);
                timeSinceLastSeek = 0f;
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