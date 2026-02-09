using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class AT_RandomLocation : ActionTask {

		public BBParameter<Transform> targetTransform;
		public BBParameter<Transform> WolfTransform;

		public float Radius = 10f;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            if (WolfTransform.value == null || targetTransform.value == null)
            {
                EndAction(false);
                return;
            }

            Vector3 wolflocation = WolfTransform.value.position;

            Vector3 result;

			Randomlocation(wolflocation, Radius,out result);

            targetTransform.value.position = result;

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

		public void Randomlocation(Vector3 center, float radius, out Vector3 result)
		{
            NavMeshHit hit;

            for (int i = 0; i < 10; i++)
            {
                Vector3 random = center + Random.insideUnitSphere * radius;

                if (NavMesh.SamplePosition(random, out hit, radius, NavMesh.AllAreas))
                {
                    result = hit.position;
					return;
				}
			
 
            }
            result = center;

        }
		}
	}