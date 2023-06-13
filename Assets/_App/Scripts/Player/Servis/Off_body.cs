using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������ �������� ������� �� ����������� ����������� ���� ���������� ������. �������� ������� �� �������� ���� ������
public class Off_body : MonoBehaviour
{

    public ChangeSkinPlayer _ChangeSkinPlayer; // ������ �� ������, ���������� ������� SkinON

    public GameObject[] objectsToDisable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //public void DisableAllObjects(bool isActive)
    //{
    //    foreach (GameObject obj in objectsToDisable)
    //    {
    //        obj.SetActive(isActive); // ��������� ��� �������� ������ 
    //    }
    //}

    public void DisableAllObjects(bool isActive)
    {
        for (int i = 0; i < objectsToDisable.Length; i++)
        {
            GameObject obj = objectsToDisable[i];

            if (isActive)
            {
                if (i<2)
                {
                    obj.SetActive(true); // �������� ������ 2 �������
                }
                _ChangeSkinPlayer.SkinON();
            }
            else
            {
                obj.SetActive(false); // ��������� ��� �������
            }
        }
    }



}
