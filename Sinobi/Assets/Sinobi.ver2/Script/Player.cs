using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤースクリプト
/// </summary>
public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;
    private Vector3 movement;
    private Vector3 rotation;


    [SerializeField, Header("移動速度")]
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
    /// フレーム更新
    /// </summary>
    private void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        //アニメーション再生
        if (inputHorizontal != 0.0f || inputVertical != 0.0f)
        {
            animator.SetBool("IsWalk", true);
            //入力量×移動速度
            movement.x = inputHorizontal * Speed;
            movement.z = inputVertical * Speed;

            //向きを移動方向にするために別変数に格納する
            rotation = movement;
        }
        else
        {
            // TODO：止まっている時に向きを考える
            animator.SetBool("IsWalk", false);
            //movement.x = 0.0f;
            //movement.z = 0.0f;
        }

        //キャラクターの向きを移動方向に向ける
        transform.rotation = Quaternion.LookRotation(rotation);

        //RigidBodyに反映
        rigidbody.velocity = movement;
    }
}
