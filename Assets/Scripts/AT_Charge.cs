using Microsoft.Win32.SafeHandles;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Charge : ActionTask {

		public BBParameter<float> value;

		float battry;
		Blackboard agentblackboard;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {


            Blackboard agentblackboard = agent.GetComponent<Blackboard>();



            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            battry = agentblackboard.GetVariableValue<float>("battry");


            
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			battry -= 1* Time.deltaTime;

			if (battry <= 0 ) {


                agentblackboard.SetVariableValue("battry", 0f);
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