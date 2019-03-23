using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Walking());
        FinalTransition.GameEnded += StopWalking;
    }

    private void StopWalking()
    {
        StopAllCoroutines();
    }

    private IEnumerator Walking()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        animator.SetInteger("Vertical", (int) moveVertical*10);
        animator.SetInteger("Horizontal", (int) moveHorizontal*10);
        yield return new WaitForEndOfFrame();

    }
}
