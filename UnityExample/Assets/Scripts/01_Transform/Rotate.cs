using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // private���� �����ؼ� �����ϵ� �ν����ͺ信�� �����ϱ� ���� SerializeField����
    [SerializeField, Range(0f, 360f)]
    private float rotX = 0f;

    // Range : ���� ���� ����. 
    [SerializeField, Range(0f, 360f)]
    private float rotY = 0f;

    // public - �ν����ͺ信�� ǥ�õȴ�.
    [SerializeField, Range(0f, 360f)]
    private float rotZ = 0f;

    private void Update()
    {
        // transform�� UnityEngine�� �⺻������ ������� �ִ�.
        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }


    /*
     < Rotate >
     - �谡 �������� �� ��ȭ�� ������ ��ġ�� ���ϴ� ��
     
     # Pitch
     : x�� ȸ��

    # Yaw
    : Y�� ȸ��

    # Roll
    : Z�� ȸ��

    # ���Ϸ� �ޱ�
     - x -> y -> z ������ ���� �� ���� �� ������ �ٸ� �� ȸ���� �ϴ� ���
     - ���� �ű�� ���

     - # ������ ����
    �� rotation ���� ���ļ� �������� �Ҿ������ ���� (x, y, z : 3�� ������) -> x�� 90�� rotate => (y, z : 2�� ������)

    # ���ʹϾ�(Quaternion) : �����
    - ���Ϸ� �ޱ� ����
    - ���Ҽ� �������� rotate ����
    - ������ ȸ���� �ƴ϶� ������ �� �ϳ��� ���� �� ���� �������� ȸ��. ( ������ �ذ� )
    
    # World ��ǥ��
    - ��ü ����� �߽��� ��ǥ
    - position�̵��� �Ͼ�� �� ������ �������� ��ǥ�� ��������.

    # Local ��ǥ��
    - ��ü ���ڸ��� ��ǥ
    - ������ ���� ������ �� �ְ�, �������κ��� ������ �󸶳� �������ִ��� ����� �� �ΰ�, rotation�� �Ͼ�� �� ������ �������� ��ǥ�� ��������.
    - rotation�� �� local ��ǥ�踦 �������� ����ȴ�.
     */

}
