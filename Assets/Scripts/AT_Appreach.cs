using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Appreach : ActionTask {
		Blackboard agentblackboard;

        public Transform targetTransform;

		public float speed;

        float battry;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			Blackboard agentblackboard = agent.GetComponent<Blackboard>();

			speed = agentblackboard.GetVariableValue<float>("speed");

            battry = agentblackboard.GetVariableValue<float>("battry");

            //agentblackboard.SetVariableValue("speed",0f);




            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Vector3 diectiontomove = targetTransform.position - agent.transform.position;

			agent.transform.position += diectiontomove.normalized * speed * Time.deltaTime;

			battry += 1 * Time.deltaTime;

			if (battry >= 10) {

                agentblackboard.SetVariableValue("battry", 10f);

                EndAction(true);
                
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