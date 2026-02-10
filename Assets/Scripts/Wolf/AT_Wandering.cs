using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class AT_Wandering : ActionTask {

		public BBParameter<NavMeshAgent> NavAgent;
		public BBParameter<Transform> Targetposition;

		Animator Animator;



        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

			if(NavAgent == null)
			{
				NavAgent = agent.GetComponent<NavMeshAgent>();
            }
			if(Animator == null)
			{
				Animator = agent.GetComponent<Animator>();
            }

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			Vector3 target = Targetposition.value.position;
			NavAgent.value.SetDestination(target);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			Animator.SetFloat("Speed", NavAgent.value.velocity.magnitude);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}