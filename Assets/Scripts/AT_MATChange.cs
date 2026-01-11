using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_MATChange : ActionTask {

		public MeshRenderer MAR;
		Material[] mats;

        public Material matA;
        public Material matB;

        bool changed = false;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {


             mats = MAR.materials;


            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			Material now;


            changed = !changed;

			if (changed) 
			{
				now = matA;
			}
			else
			{
				now = matB;
			}

            mats[0] = now;
            MAR.materials = mats;

            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {

        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}