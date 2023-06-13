using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChangeSkinPlayerRemote : MonoBehaviourPun
{

    [Header("����� �����")]
    public int NomerSkins;
    public int OldNomerSkins;
    PhotonView PV;


    [Header("����� ������")]
    [Tooltip("�����")]
    public GameObject TopKnot;

    [Tooltip("�������")]
    public GameObject Beard;

    [Tooltip("����������")]
    public GameObject Sideburns;

    [Tooltip("���")]
    public GameObject Neck;

    [Tooltip("��������")]
    public GameObject Hair;


    [Header("�����")]
    [Tooltip("�������� ������ ���������� ������")]
    public GameObject[] Skins;




    // Start is called before the first frame update
    void Start()
    {
        NomerSkins = 0;
        PV = GetComponent<PhotonView>();
        PV.RPC("DisableAllSkinsExceptFirst", RpcTarget.AllBuffered);
    }



    [PunRPC]
    public void DisableAllSkinsExceptFirst()
    {
        for (int i = 1; i < Skins.Length; i++)
        {
            Skins[i].SetActive(false);
        }
    }




    public void ChangeSkin(int value)
    {
        //OldNomerSkins = NomerSkins;
        //NomerSkins = value;
        PV.RPC("RPC_ChangeSkin", RpcTarget.AllBuffered, value);
    }

    [PunRPC]
    public void RPC_ChangeSkin(int value)
    {
        Debug.Log("���� �������� �� " + NomerSkins);
        // ��������� ������� ����
        Skins[NomerSkins].SetActive(false);

        NomerSkins = value;
        // �������� ����� ���� ��������
        Skins[NomerSkins].SetActive(true);
        ActiveFase();
    }

    //���������� �������������� �� ����, � ����������� �� �����
    public void ActiveFase()
    {
        Debug.Log("���������� ������ ");

        //����� ������� ������ �� ���� ������.
        TopKnot.SetActive(NomerSkins == 0);

        //������ ������� ������ �� ���� ������.
        //Beard.SetActive();

        //���������� ������� ������ �� ���� ������.
        Sideburns.SetActive(NomerSkins == 1);

        //��� ������� ������ �� ���� ������.
        Neck.SetActive(NomerSkins == 1 || NomerSkins == 2 || NomerSkins == 4 || NomerSkins == 5);

        //�������� ������� ������ �� ���� ������.
        Hair.SetActive(NomerSkins == 0 || NomerSkins == 3);
    }





}
