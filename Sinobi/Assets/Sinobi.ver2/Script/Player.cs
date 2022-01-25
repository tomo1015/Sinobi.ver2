using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�X�N���v�g
/// </summary>
public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;
    private Vector3 movement;
    private Vector3 rotation;


    [SerializeField, Header("�ړ����x")]
    private float Speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// �t���[���X�V
    /// </summary>
    private void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        //�A�j���[�V�����Đ�
        if (inputHorizontal != 0.0f || inputVertical != 0.0f)
        {
            animator.SetBool("IsWalk", true);
            //���͗ʁ~�ړ����x
            movement.x = inputHorizontal * Speed;
            movement.z = inputVertical * Speed;

            //�������ړ������ɂ��邽�߂ɕʕϐ��Ɋi�[����
            rotation = movement;
        }
        else
        {
            // TODO�F�~�܂��Ă��鎞�Ɍ������l����
            animator.SetBool("IsWalk", false);
            //movement.x = 0.0f;
            //movement.z = 0.0f;
        }

        //�L�����N�^�[�̌������ړ������Ɍ�����
        transform.rotation = Quaternion.LookRotation(rotation);

        //RigidBody�ɔ��f
        rigidbody.velocity = movement;
    }
}
