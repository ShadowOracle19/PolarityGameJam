using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerAnimations : MonoBehaviour
    {
        private Animator mAnimator;

        // Start is called before the first frame update
        void Start()
        {
            mAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (mAnimator!= null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    mAnimator.SetTrigger("Jump");
                }
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
                {
                    mAnimator.SetBool("Walking", true);
                    mAnimator.SetBool("WalkingBackwards", false);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    mAnimator.SetBool("WalkingBackwards", true);
                    mAnimator.SetBool("Walking", false);
                }
                else
                {
                    mAnimator.SetBool("Walking", false);
                    mAnimator.SetBool("WalkingBackwards", false);
                }
            }
        }
    }
}
