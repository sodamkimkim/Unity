using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2. �� ����
// - ���� 11��, ���� 5��, 
 //- ���� �ϴܺ��� ����
 // - ���� ������
 // 3. �� �̵�
  //- �� �����ӿ� �� ���� �̵�
  // ȭ���� �¿� ���� �����ϸ� �Ʒ��� �̵�.
  // Ÿ�� ��ġ���� �������� ���� ���� 
  // �� ���� �پ��� �ӵ� ����
public class InvadersManager : MonoBehaviour
{
    [SerializeField]
    private GameObject invaderPrefab = null;
    private void SpawnInvader(Vector3 _pos)
    {
        GameObject go = Instantiate(invaderPrefab, _pos, Quaternion.identity);
    }
}
