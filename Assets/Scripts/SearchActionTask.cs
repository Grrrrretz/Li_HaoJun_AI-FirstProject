using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

	public class SearchActionTask : ActionTask
	{
		public BBParameter<Vector3> LeadScout1;
        public BBParameter<Vector3> LeadScout2;
        public BBParameter<Vector3> LeadScout3;
		public NavMeshAgent NavMeshAgent;

        protected override string OnInit()
		{
			return null;
		}

		protected override void OnExecute()
		{
			//Choose a random destination on the navmesh
			//Set the path to that position

			LeadScout1 = Random.insideUnitSphere * 3;
            LeadScout2 = Random.insideUnitSphere * 3;
            LeadScout3 = Random.insideUnitSphere * 3;

			

        }

		protected override void OnUpdate()
		{
			//When they have arrived then end the task

		





		}

		//Called when the task is disabled.
		protected override void OnStop()
		{
			
		}

		//Called when the task is paused.
		protected override void OnPause()
		{
			
		}
	}
}