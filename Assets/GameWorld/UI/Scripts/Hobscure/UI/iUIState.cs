using UnityEngine;
using System.Collections;

namespace Hobscure.UI { 
    public interface iUIState {
        void Init();
        void Update();
        void Exit();
    }
}