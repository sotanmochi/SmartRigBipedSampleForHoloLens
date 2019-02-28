using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;

namespace RuntimeNavMeshForHoloLens
{
    public class AgentDestinationHandler : MonoBehaviour, IInputClickHandler
    {
        private UnityEngine.AI.NavMeshAgent agent;

        void Start()
        {
            InputManager.Instance.AddGlobalListener(gameObject);
            agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (GazeManager.Instance.HitObject != null && 
                GazeManager.Instance.HitObject.layer == SpatialMappingManager.Instance.PhysicsLayer)
			{
                RaycastHit hitInfo = GazeManager.Instance.HitInfo;
   
                // Find closest point on NavMesh and set destination.
                UnityEngine.AI.NavMeshHit navMeshHit;
                if(UnityEngine.AI.NavMesh.SamplePosition(hitInfo.point, out navMeshHit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
                {
                    agent.destination = navMeshHit.position;
                }
            }
        }
    }
}
