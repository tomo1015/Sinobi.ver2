using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �S�[���I�u�W�F�N�g
/// </summary>
public class GoalPosition : MonoBehaviour
{
    /// <summary>
    /// �Փ�
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //�Ԃ����Ă����I�u�W�F�N�g���v���C���[�Ȃ��
        if (collision.transform.tag == "Player")
        {
            //�S�[�����o
            //�N���A��Ԃ�ۑ��iAutoSaveUI�����łɁj


        }
        else
        {
            //�Ȃɂ����Ȃ�
            return;
        }
    }
}

