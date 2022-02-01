using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSearch : MonoBehaviour
{
    [SerializeField, Header("�ǂ�������Ώہi�f�o�b�O�p�j")]
    private GameObject target_object = null;

    private GameObject parentObject;//�e�I�u�W�F�N�g


    private void Start()
    {
        //�e�I�u�W�F�N�g�̏����擾����
        parentObject = gameObject.transform.root.gameObject;
    }

    /// <summary>
    /// �R���C�_�[�ɓ�������ǂ�������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //�ǂ������鑊��̃I�u�W�F�N�g�����擾����
            target_object = other.gameObject;
        }
    }

    /// <summary>
    /// �R���C�_�[����o���珄�񏈗��ɕς���
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            //����̏�������������
            target_object = null;
        }
    }
}
