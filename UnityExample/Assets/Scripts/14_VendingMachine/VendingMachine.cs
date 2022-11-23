using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] beveragePrefabs = null;

    public enum EBeverageType { Cider, Coke, StrawberryMilk }


    [System.Serializable]
    public struct SButton
    {
        public EBeverageType type;
        public int price;
        public int cnt;
    }
    //[SerializeField]
    //private EBeverageType[] beverages = null;

    //[SerializeField]
    //private int[] beverageCnts = null;
    [SerializeField]
    private SButton[] buttons = null;
    [SerializeField]
    private int btnColCnt = 1;

    private GameObject[] beveragePrefabs = null;
    private UIManager uiMng = null;

    private void Awake()
    {
        // 폴더 다 들고옴
        // 파일 순서대로 배열인덱스 매겨지기 때문에 이넘도 그렇게 셋팅하는게 편하다.

        // 1. Find tag
        // 2. Inspector
        // 3. GetComponentInChildren
        beveragePrefabs = Resources.LoadAll<GameObject>("Prefabs\\Beverages");
        //beveragePrefab = Resources.Load<GameObject>("Prefabs\\Beverages\\P_Beverage_Coke");
        GameObject uiMngGo = GameObject.FindGameObjectWithTag("UIManager");
        if (uiMngGo != null)
            uiMng = uiMngGo.GetComponent<UIManager>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    if (BuyBeverageWithButtonIndex(0))
        //        SpawnBeverage(buttons[0].type);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    if (BuyBeverageWithButtonIndex(1))
        //        SpawnBeverage(buttons[1].type);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    if (BuyBeverageWithButtonIndex(2))
        //        SpawnBeverage(buttons[2].type);
        //}
        if (Input.GetKeyDown(KeyCode.M))
            uiMng.ShowMenu(buttons, btnColCnt);
        if (Input.GetKeyDown(KeyCode.N))
            uiMng.HideMenu();
    }
    public bool BuyBeverageWithButtonIndex(int _btnIdx)
    {
        if (CheckStock(_btnIdx) == 0) return false;
        --buttons[_btnIdx].cnt;
        return true;
    }
    // 음료생성해주는 메서드
    public void SpawnBeverage(EBeverageType _type)
    {
        // c#에서는 enum도 클래스이기 떄문에 int로 형변환 해줘야 한다.
        // c에서는 그냥 int 면 int로 들어오는데..
        GameObject go = Instantiate(beveragePrefabs[(int)_type]);
        go.transform.position = transform.position + GetRandomPositionWithRadius(2.5f);

    }
    // 반지름 받아서 랜덤포지션 생성해주는 함수
    private Vector3 GetRandomPositionWithRadius(float _r)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * _r;
    }
    public int CheckStock(EBeverageType _type)
    {
        // ******** 과제
        // 1. 재고 체크
        // 타입이 자판기에 있는지 먼저 체크해야함.
        // 있다고 찾아지면 몇개인지 반환.

        // 2. 음료 구매하고나면 음료 카운트 -1

        return 0;
    }
    public int CheckStock(int _btnIdx)
    {
        return buttons[_btnIdx].cnt;
    }
} // end of class
