using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    public Animator animator;

    /*p*//*ublic GameObject effect;*/

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Run", true);

            //Instantiate(effect, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {

            animator.SetTrigger("Jump");
        }
    }
}
