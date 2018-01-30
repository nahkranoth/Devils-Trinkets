using UnityEngine;
using Zenject;
using System;
using Hobscure.Utils;

namespace Hobscure.NPC
{
    public class NPCRouteManager : MonoBehaviour
    {
        public SpriteAnimations frontAnim;
        public SpriteAnimations backAnim; 

        public UnityEngine.AI.NavMeshAgent navAgent;

        Action reachedCallback;

        int currentRoute;
        public bool running;

        public void NavigateTo(Vector3 position, Action callback)
        {
            navAgent.ResetPath();
            navAgent.SetDestination(position);

            running = true;
            reachedCallback = callback;
            frontAnim.Run();
            backAnim.Run();
        }

        public void PauseRoutes()
        {
            frontAnim.Pause();
            backAnim.Pause();
            running = false;
        }

        private void DestinationIsReached()
        {
            PauseRoutes();
            reachedCallback();
        }

        void Update()
        {
            if (running) {
                float dist = navAgent.remainingDistance;
                if (dist != Mathf.Infinity && dist > 0 && navAgent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete && dist <= 1)
                {
                    DestinationIsReached();
                }
            }
        }
    }
}