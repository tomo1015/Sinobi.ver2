using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// �v���C���[�X�^�[�g�ʒu
/// </summary>
public class StartPosition : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�v���n�u")]
    private GameObject m_PlayerObject = null;
    // Start is called before the first frame update
    private void Start()
    {
        // TODO: �o���G�t�F�N�g�ƃA�j���[�V�������l����
        //�C���X�^���X
        Instantiate(m_PlayerObject, this.gameObject.transform);
    }
}
