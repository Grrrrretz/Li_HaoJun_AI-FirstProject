using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_SetLight : ActionTask {

		public BBParameter<Light> pointlight;

		public bool Switch;

		public BBParameter<float> nowIntensity;
		public float offIntensity;
		public float onIntensity;
		public float t;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			if(Switch == true)
			{
				Lightchange(pointlight, nowIntensity, onIntensity);

				nowIntensity = onIntensity;

			}
			else
			{
                Lightchange(pointlight, nowIntensity, offIntensity);
				nowIntensity = offIntensity;
            }

			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		void Lightchange(BBParameter<Light> pointlight, BBParameter<float> nowIntensity, float Intensity) 
		{
            t += Time.deltaTime;
            pointlight.value.intensity = Mathf.Lerp(nowIntensity.value, Intensity, t/1);


        }

    }
}