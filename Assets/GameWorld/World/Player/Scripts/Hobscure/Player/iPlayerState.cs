using UnityEngine;
using System.Collections;

namespace Hobscure.Player { 
    public interface iPlayerState {

        void Init();

        void Update();

        void Exit();
    }
}