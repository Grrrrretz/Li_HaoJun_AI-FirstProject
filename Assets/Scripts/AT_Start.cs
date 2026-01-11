using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Start : ActionTask {

		public ParticleSystem _particleSystem;
		float time = 0f;
		float maxtime = 5f;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {


            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            _particleSystem.Clear(true);
            time = 0;

            _particleSystem.Play(true);

			Debug.Log("play");


        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {


            time += Time.deltaTime;

            if (time >= maxtime)
            {
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {

            _particleSystem.Stop(true,ParticleSystemStopBehavior.StopEmitting);

			time = 0f;

        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}