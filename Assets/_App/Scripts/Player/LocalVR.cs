using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobaVR
{

    public class LocalVR : MonoBehaviour
    {
        [Header("DieSkin")]
        public SkinDieRespawn[] skinDieRespawnObjects;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }



        public void DieLocal()
        {

            // ��������� ������� Die() �� ������ ������� � �������
            foreach (SkinDieRespawn obj in skinDieRespawnObjects)
            {
                //�������� ��������� �� ����������
                obj.Die();
            }

            //����� ��������� ����������� ��������
            //����� ������� ���� � ������ ������, � ���� �� ���� �������� ��������� ��� ������ ���� � ��������

        }

        public void RespawnLocal()
        {
            //������������ ��������� �����
            // ��������� ������� Die() �� ������ ������� � �������
            foreach (SkinDieRespawn obj in skinDieRespawnObjects)
            {
                //�������� ��������� �� ����������
                obj.Respawn();
            }
            

        }

    }
}