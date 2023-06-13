using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using MobaVR;


public class ServisUI : MonoBehaviourPunCallbacks
{
    public Text statusLegs; // ������ �� ��������� ��������� ��� ����������� ������� ���
    private bool legsEnabled = true; // ����, �����������, �������� �� ����

    public Text statusBody; // ������ �� ��������� ��������� ��� ����������� ������� ���� ����������
    private bool bodyEnabled = true; // ����, �����������, �������� �� ����


    public GameSession _GameSession;
    [SerializeField] private GameObject _PlayerVR;

    [SerializeField] private Off_legs[] offLegsArray;


    // ���� ������ �� ������ "����"
    public void Off_Legs()
    {
        // ���������� ������� ������� ��� ���������� ��� ���� �������
        photonView.RPC("DisableLegs", RpcTarget.All);

    }

    [PunRPC]
    private void DisableLegs()
    {
        // ������� ��� ������� � ����������� Off_legs
        offLegsArray = FindObjectsOfType<Off_legs>();

        foreach (Off_legs offLegs in offLegsArray)
        {
            offLegs.ToggleObjects(legsEnabled); // �������� ��� ��������� ����
        }

        // �������� ��������� ����� � ������ �������
        legsEnabled = !legsEnabled;
        statusLegs.text = legsEnabled ? "���������" : "��������";
    }

    // ���� ������ �� ������ "����"
    public void Off_Body()
    {
        // ���������� ������� ������� ��� ���������� ��� ���� �������
        photonView.RPC("DisableBody", RpcTarget.All);

    }

    [PunRPC]
    private void DisableBody()
    {
        // ������� ������ � ����������� Off_body
        Off_body offBodies = FindObjectOfType<Off_body>();

        offBodies.DisableAllObjects(bodyEnabled); // �������� ��� ��������� ����

        // �������� ��������� ����� � ������ �������
        bodyEnabled = !bodyEnabled;
        statusBody.text = bodyEnabled? "���������" : "��������";
    }

    // ���� ������ �� ������ "����� �������"
    public void ChangeTeam()
    {
        //����� ����� ������ Teammate � ��������� ������� � ��
        _PlayerVR = _GameSession.localPlayer;
        _PlayerVR.GetComponent<PlayerVR>().ChangeTeamOnClick();

    }





}
