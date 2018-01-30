using UnityEngine;
using System.Collections;

namespace Hobscure.Utils { 
    public class SpriteAnimations : MonoBehaviour {

        [SerializeField]
        Renderer matRenderer;

        Material material;

        [SerializeField]
        Texture2D idle_texture;

        [SerializeField]
        Texture2D[] textures;

        [SerializeField]
        float timeS;

        int currentFrame;

        bool running;

        private IEnumerator coroutine;

        public void Start()
        {
            Init();
        }

        void Init()
        {
            material = matRenderer.material;
        }

        public void Run()
        {
            if(material == null)
            {
                Init();
            }

            if (!running) {
                running = true;
                currentFrame = 0;
                coroutine = FrameSkip();
                StartCoroutine(coroutine);
            }
        }

        public void Pause()
        {
            if (running)
            {
                running = false;
                StopCoroutine(coroutine);
                material.mainTexture = idle_texture;
            }
        }

        IEnumerator FrameSkip()
        {
            while (running) {
                currentFrame++;
                material.mainTexture = textures[currentFrame % textures.Length];
                yield return new WaitForSeconds(timeS);
            }
        }

    }
}