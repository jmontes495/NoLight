using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    private float animDelay = 0.1f;

    private bool isPlayingSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Walking());
        FinalTransition.GameEnded += StopWalking;
    }

    private void StopWalking()
    {
        StopAllCoroutines();
        CharacterSoundManager.StopWalkingSound();
        isPlayingSound = false;
    }

    private IEnumerator Walking()
    {
        WaitForSeconds delay = new WaitForSeconds(animDelay);
        yield return delay;

        while (true)
        {
            int moveVertical = Input.GetKey(KeyCode.DownArrow) ? -1 : 0;
            int moveHorizontal = Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;

            moveVertical = Input.GetKey(KeyCode.UpArrow) ? 1 : moveVertical;
            moveHorizontal = Input.GetKey(KeyCode.RightArrow) ? 1 : moveHorizontal;

            if (moveHorizontal != 0)
                moveVertical = 0;

            if ((moveHorizontal != 0 || moveVertical != 0) && !isPlayingSound)
            {
                CharacterSoundManager.PlayWalkingSound();
                isPlayingSound = true;
            }
            else if ((moveHorizontal == 0 && moveVertical == 0) && isPlayingSound)
            {
                CharacterSoundManager.StopWalkingSound();
                isPlayingSound = false;
            }

            animator.SetInteger("Vertical", moveVertical);
            animator.SetInteger("Horizontal", moveHorizontal);
            yield return delay;
        }

    }
}
