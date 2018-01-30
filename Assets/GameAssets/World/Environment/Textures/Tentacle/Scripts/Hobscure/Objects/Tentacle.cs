using Hobscure.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hobscure.Objects { 

    public class Tentacle : MonoBehaviour {

        SpriteAnimations spriteAnimations;

        Animator animator;

        private IEnumerator coroutine;

        // Use this for initialization
        void Start () {
            spriteAnimations = GetComponent<SpriteAnimations>();
            spriteAnimations.Run();

            animator = GetComponent<Animator>();

            coroutine = Run();
            StartCoroutine(coroutine);
        }

        IEnumerator Run()
        {
            yield return new WaitForSeconds(Random.Range(2f, 3f));
            AnimateIn();
        }

        void AnimateIn()
        {
            animator.SetTrigger("Show");
        }
    }

}