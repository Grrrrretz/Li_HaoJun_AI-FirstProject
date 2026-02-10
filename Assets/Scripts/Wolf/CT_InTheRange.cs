using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CT_InTheRange : ConditionTask {

        public BBParameter<Transform> targetPosition;
        public float range = 5f;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

            if (targetPosition == null|| targetPosition.value == null) 
			{  
				return false; 
			}

            Vector3 target = targetPosition.value.position;
            Vector3 current = agent.transform.position;

            float distance = Vector3.Distance(current, target);

            return distance <= range;
		}
	}
}