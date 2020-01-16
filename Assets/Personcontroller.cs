using System.Collections;
using UnityEngine;

public class Personcontroller : MonoBehaviour
{
    float Runspeed = 4;
    float Rotspeed = 40;
    float Rot = 0;
    float Gravity = 8;

    public CharacterController Controller;
    public Animator animator;
    Vector3 movedir = Vector3.zero;
     void Start()
    {
        Controller = this.gameObject.GetComponent<CharacterController>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Getinput();
        ChargeInput();
        Jumpinput();
    }

    void Movement()
    {
        if (Controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if(animator.GetBool("Attacking")== true)
                {
                    return;
                    
                }
                else if(animator.GetBool("Attacking")== false){
                    animator.SetBool("Running", true);
                    animator.SetInteger("Conditions", 1);
                    movedir = new Vector3(0, 0, 1);
                    movedir *= Runspeed;
                    movedir = transform.TransformDirection(movedir);
                }
         

            }
                if (Input.GetKeyUp(KeyCode.W))
                {
                animator.SetBool("Running", false);
                    movedir = new Vector3(0, 0, 0);
                    animator.SetInteger("Conditions", 0);
                }
       
        }
        movedir.y -= Gravity * Time.deltaTime;
        Controller.Move(movedir * Time.deltaTime);

        Rot += Input.GetAxis("Horizontal") * Rotspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, Rot, 0);
    }
     
    void Getinput()
    {
        if (Controller.isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (animator.GetBool("Running") == true)
                {
                    animator.SetBool("Running", false);
                    movedir = new Vector3(0, 0, 0);
                }
               if (animator.GetBool("Running") == false)
                {
                    Attacking();
                }
            }
        }
    }
     void Attacking()
    {
        StartCoroutine ("AttackRoutine");
    }
  IEnumerator AttackRoutine()
    {
        animator.SetBool("Attacking", true);
        animator.SetInteger("Conditions", 2);
        yield return new WaitForSeconds(1);
        animator.SetInteger("Conditions", 0);
        animator.SetBool("Attacking", false);

    }
        void ChargeInput()
    {
        Charge();
    }

    void Charge()
    {
        if (Controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Charge", true);
                animator.SetInteger("Conditions", 3);
                movedir = new Vector3(0, 0, 1);
                  movedir *= Runspeed;
                    movedir = transform.TransformDirection(movedir);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animator.SetBool("Charge", false);
                animator.SetInteger("Conditions", 0);
                movedir = new Vector3(0, 0, 0);
            }
            movedir.y -= Gravity * Time.deltaTime;
            Controller.Move(movedir * Time.deltaTime);

            Rot += Input.GetAxis("Horizontal") * Rotspeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, Rot, 0);
        }
    }

    void Jumpinput()
    {
        Jump();
    }
    void Jump()
    {
        if (Controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("Jump", true);
                animator.SetInteger("Conditions", 4);
              

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("Jump", false);
                animator.SetInteger("Conditions", 0);
        

            }
        }
    }
}
