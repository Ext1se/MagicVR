using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkinMaps : MonoBehaviour
{

    //���� ������ �� ������ �����, �� �� ������� ������� ChangeSkinPlayer ������� ���� -1
    public void Down()
    {
        // ������� ������ � ����������� ChangeSkinPlayer
        GameObject player = GameObject.Find("ChangeSkinPlayer");
        ChangeSkinPlayer script = player.GetComponent<ChangeSkinPlayer>();

        //������� ����� �����
        script.ChangeSkinDown();
    }

    //���� ������ �� ������ �����, �� �� ������� ������� ChangeSkinPlayer ������� ���� +1
    public void Next()
    {
        // ������� ������ � ����������� ChangeSkinPlayer
        GameObject player = GameObject.Find("ChangeSkinPlayer");
        ChangeSkinPlayer script = player.GetComponent<ChangeSkinPlayer>();

        //������� ����� �����
        script.ChangeSkinNext();
    }






}
