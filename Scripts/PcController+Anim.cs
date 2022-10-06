using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    //Основные параметры
    public float speedMove;//скорость персонажа
    public float jumpPower;//сила прыжка

    //Параметры геймплейя для перса
    private float gravityForce;//гравитация перса
    private Vector3 moveVector;//направ движ перса
    
    //Ссылки на компоненты 
    private CharacterController ch_controller;
    private Animator ch_animator;
    private MobileController mContr;
        
        void Start () 
     {
        ch_controller = GetComponent<CharacterController> ();
        ch_animator = GetComponent<Animator> ();
        mContr = GameObject.FindGameObjectWithTag ("Joystick").GetComponent<MobileController>();
     }
        
     // Update is called once per frame
        void Update ()
     {
     CharacterMove ();
     GamingGravity ();
     }
     //метод перемещения перса
     private void CharacterMove()
     {
        if (ch_controller.isGrounded)// чтобы при прыжке не летал
        // перемещение по поверхн
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis ("Horizontal") * speedMove;
        moveVector.z = Input.GetAxis ("Vertical") * speedMove;

        //анимация пердиж перса
    if (moveVector.x != 0 || moveVector.z != 0)
        ch_animator.SetBool ("условие перехода аним", true);
    else ch_animator.SetBool ("условие перехода аним", false);
     //поворот перса в стороне перемещ
     if (Vector3.Angle (Vector3.forward, moveVector) > 1f || Vector3.Angle (Vector3.forward, moveVector) == 0)
    {
        Vector3 direct = Vector3.RotateTowards (transform.forward, moveVector, speedMove, 0.0f);
        transform.rotation = Quaternion.LookRotation (direct);
    }
     }
        moveVector.y = gravityForce;//расчет гравитации
        ch_controller.Move (moveVector * Time.deltaTime);//метод перемещения перса
    }
       //метод гравитации
        private void GamingGravity()
    {
    if (!ch_controller.isGrounded)
        gravityForce -= 20f * Time.deltaTime;
    else
        gravityForce = -1f;
    if (Input.GetKeyDown (KeyCode.Space) && ch_controller.isGrounded)
        gravityForce = jumpPower;
}
