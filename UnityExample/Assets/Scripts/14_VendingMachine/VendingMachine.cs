using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public enum EBeverageType { Cider, Coke, StrawberryMilk }
    [System.Serializable]
    public struct SButton
    {
        public EBeverageType type;
        public int price;
        public int stock;

        public SButton(EBeverageType _type, int _price, int _stock)
        {
            type = _type;
            price = _price;
            stock = _stock;
        }
    } // end of struct SButton
    [SerializeField]
    private SButton[] buttons = null;
    [SerializeField]
    private int btnColCnt = 1;
    private GameObject[] beveragePrefabs = null;
    private UIManager uiMng = null;

    private void Awake()
    {
        // # �ʱ�ȭ
        // ���������� �ε�
        // ���ӿ�����Ʈ �����Ҵ�

        // ���� �� ����.
        beveragePrefabs = Resources.LoadAll<GameObject>("Prefabs\\Beverages");
        //beveragePrefabs = Resources.Load<GameObject>("Prefabs\\Beverages\\P_Beverage_Coke");
        GameObject uiMngGo = GameObject.FindGameObjectWithTag("UIManager");
        if (uiMngGo != null)
            uiMng = uiMngGo.GetComponent<UIManager>();
    }
    // Ÿ�� �޾Ƽ� ���� ����
    private void SpawnBeverage(EBeverageType _type)
    {
        // Ÿ�Թ޾Ƽ� ���� �����ϰ�
        // beveragePrefabs �迭���� ���� �ε�� ������� [0] [1] [2]�� ����,
        // ����� enum�� ����� ������� 0,1,2�� ���� ������.
        // ���� �迭�� ������ enum Ÿ���� ����ȯ�ؼ� �־ ����Ѵ�.
        GameObject go = Instantiate(beveragePrefabs[(int)_type]);
        // ��ġ ����
        go.transform.position = transform.position + GetRandomPositionWithRadius(2.5f);
    }
    private Vector3 GetRandomPositionWithRadius(float _r)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Rad2Deg;
        return new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));
    }
    // ��ư �ε��� �޾Ƽ� ��� ���� üũ
    public int CheckStock(int _btnIdx)
    {
        return buttons[_btnIdx].stock;
    }
    // ��ư �ε��� �޾Ƽ� ���ᱸ��(��� --)�ϴ� �޼���
    private bool BuyBeverageWithButtonIndex(int _btnIdx)
    {
        if (CheckStock(_btnIdx) == 0) return false;
        --buttons[_btnIdx].stock;
        return true;
    }
    // ���� ���μ��� �����ϴ� ui���� �ݹ��Լ�
    public bool BuyBeverage(int _btnIdx, out SButton _newBtnInfo)
    {
        // ��ư onClick�̺�Ʈ �߻��ϸ� �� �Լ� �ݹ�ȴ�.
        // - ���� �������ְ�
        // - ���� �����ؼ� true�� ��� -- ���ְ�
        // - ui��ư ������ �������ش�. (out SButton _newBtnInfo)
        // �� ���Ǳ� ���ο��� ������ ��������� ������ �ֱ⶧���� �ݹ��Լ����� out���� ������ �ش�.
        /*  UIMenuButtonŬ�������� �ݹ��Լ�ȣ�� �κФ�
         public void OnClickCallback()
         {
            VendingMachine.SButton newBtnInfo = new VendingMachine.SButton();
            if ((bool)onClickCallback?.Invoke(btnIdx, out newBtnInfo ))
            {
                // ���Ű� ��
                UpdateInfo(newBtnInfo);
            }
         }
            => ��, �ݹ��Լ��� out newBtnInfo������, ������ newBtnInfo������ UpdateInfo(newBtnInfo)�Ѵ�.
         */

        if (buttons == null|| buttons.Length == 0 || buttons.Length <= _btnIdx)
        {
            _newBtnInfo = buttons[_btnIdx];
            return false;
        }
        if(BuyBeverageWithButtonIndex(_btnIdx)) // ���Ű� ������ ���¸� �����ϰ� ��� -1
        {
            SpawnBeverage(buttons[_btnIdx].type);
            _newBtnInfo = buttons[_btnIdx]; // �ش� ��ư ���� ���� (������� ������ �� �ݿ�)
            return true;
        }
        _newBtnInfo = buttons[_btnIdx]; // �� if��Ÿ�� ���� ���Ͼ� �� ��. => UIMenuButton���� UpdateInfo()���Ͼ��.
        return false; 
    }
    // �÷��̾�� ��ȣ�ۿ��� �� ȣ��Ǵ� �Լ�. 
    public void ShowMenu()
    {
        // UIManager -> UIMenuManager -> UIMenuButtonHolder => UIButton ���� ����ȴ�.
        uiMng.ShowMenu(buttons, BuyBeverage, btnColCnt);
    }
    // �÷��̾�� ��ȣ�ۿ��� �� ȣ��Ǵ� �Լ�.
    public void HideMenu()
    {
        uiMng.HideMenu();
    }
} // end of class
