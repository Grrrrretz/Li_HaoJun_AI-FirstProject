using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Click : ActionTask {

        public BBParameter<Material> material;

        public LayerMask groundlayermask;
        public float triggerRadius = 2.0f; 

        private ParticleSystem ps;
        private ParticleSystemRenderer psr;

        protected override string OnInit()
        {

            ps = agent.GetComponentInChildren<ParticleSystem>();

            psr = ps.GetComponent<ParticleSystemRenderer>();

            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            return null;
        }

        protected override void OnExecute()
        {

            if (material != null && material.value != null)
            {
                psr.material = material.value;
            }

        }

        protected override void OnUpdate()
        {

            if (Mouse.current == null)
            {
                return;
            }
            if (!Mouse.current.leftButton.wasPressedThisFrame)
            {
                return;
            }

            var cam = Camera.main;
            if (cam == null)
            {
                return;
            }


            Vector3 mousepos = Mouse.current.position.ReadValue();
            Ray ray = cam.ScreenPointToRay(mousepos);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundlayermask))
            {

                Vector3 agentPos = agent.transform.position;
                Vector3 hitPos = hit.point;

                agentPos.y = 0f;
                hitPos.y = 0f;

                float dist = Vector3.Distance(agentPos, hitPos);
                if (dist <= triggerRadius)
                {
                    ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                    ps.Play();
                }
            }
        }

        protected override void OnStop()
        {

            if (ps != null)
            {
                ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}