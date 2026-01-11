using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Start : ActionTask {

		public ParticleSystem _particleSystem;
        public ParticleSystem _particleSystem2;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            _particleSystem = agent.GetComponent<ParticleSystem>();
            _particleSystem2 = agent.GetComponent<ParticleSystem>();

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            _particleSystem.Play();
            _particleSystem2.Play();
            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {

            _particleSystem.Stop();
            _particleSystem2.Stop();

        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}