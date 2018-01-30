using UnityEngine;
using System.Collections;
using Zenject;
using Hobscure.Main;
using Hobscure.Objects;

namespace Hobscure.Player
{
    public class PlayerStateManager : MonoBehaviour
    {

        public iPlayerState state;

        public bool running;

        [Inject]
        public InputManager input;

        [Inject]
        public PlayerManager playerManager;

        [Inject]
        public ObjectManager objectManager;

        [Inject]
        public DiContainer container;

        IEnumerator InitState()
        {
            yield return new WaitForEndOfFrame();
            state.Init();
            running = true;
        }

        void Update()
        {
            if (running)
            {
                if (input.GetButtonDown("Menu") ||
                    input.GetButtonDown("Fire2") &&
                    (state.GetType() == typeof(WalkState))
                    )
                {
                    SwitchStates(new IdleState(this));
                }

                state.Update();
              
            }
        }

        public void SwitchStates(iPlayerState state)
        {
            if (this.state != null)
            {
                this.state.Exit();
            }

            this.state = state;
            running = false;
            StartCoroutine(InitState());
        }

    }
}