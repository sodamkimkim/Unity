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
        // # 초기화
        // 프리팹파일 로드
        // 게임오브젝트 동적할당

        // 폴더 다 들고옴.
        beveragePrefabs = Resources.LoadAll<GameObject>("Prefabs\\Beverages");
        //beveragePrefabs = Resources.Load<GameObject>("Prefabs\\Beverages\\P_Beverage_Coke");
        GameObject uiMngGo = GameObject.FindGameObjectWithTag("UIManager");
        if (uiMngGo != null)
            uiMng = uiMngGo.GetComponent<UIManager>();
    }
    // 타입 받아서 음료 생성
    private void SpawnBeverage(EBeverageType _type)
    {
        // 타입받아서 음료 생성하고
        // beveragePrefabs 배열에는 파일 로드된 순서대로 [0] [1] [2]로 들어가고,
        // 선언된 enum은 선언된 순서대로 0,1,2의 값을 가진다.
        // 따라서 배열의 순서에 enum 타입을 형변환해서 넣어서 사용한다.
        GameObject go = Instantiate(beveragePrefabs[(int)_type]);
        // 위치 지정
        go.transform.position = transform.position + GetRandomPositionWithRadius(2.5f);
    }
    private Vector3 GetRandomPositionWithRadius(float _r)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Rad2Deg;
        return new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));
    }
    // 버튼 인덱스 받아서 재고 수량 체크
    public int CheckStock(int _btnIdx)
    {
        return buttons[_btnIdx].stock;
    }
    // 버튼 인덱스 받아서 음료구매(재고 --)하는 메서드
    private bool BuyBeverageWithButtonIndex(int _btnIdx)
    {
        if (CheckStock(_btnIdx) == 0) return false;
        --buttons[_btnIdx].stock;
        return true;
    }
    // 구매 프로세스 진행하는 ui연동 콜백함수
    public bool BuyBeverage(int _btnIdx, out SButton _newBtnInfo)
    {
        // 버튼 onClick이벤트 발생하면 이 함수 콜백된다.
        // - 음료 생성해주고
        // - 구매 진행해서 true면 재고 -- 해주고
        // - ui버튼 정보도 수정해준다. (out SButton _newBtnInfo)
        // ㄴ 자판기 내부에서 수정된 재고정보를 가지고 있기때문에 콜백함수에서 out으로 수정해 준다.
        /*  UIMenuButton클래스에서 콜백함수호출 부분ㄱ
         public void OnClickCallback()
         {
            VendingMachine.SButton newBtnInfo = new VendingMachine.SButton();
            if ((bool)onClickCallback?.Invoke(btnIdx, out newBtnInfo ))
            {
                // 구매가 됨
                UpdateInfo(newBtnInfo);
            }
         }
            => 즉, 콜백함수에 out newBtnInfo던지고, 수정된 newBtnInfo정보로 UpdateInfo(newBtnInfo)한다.
         */

        if (buttons == null|| buttons.Length == 0 || buttons.Length <= _btnIdx)
        {
            _newBtnInfo = buttons[_btnIdx];
            return false;
        }
        if(BuyBeverageWithButtonIndex(_btnIdx)) // 구매가 가능한 상태면 구매하고 재고 -1
        {
            SpawnBeverage(buttons[_btnIdx].type);
            _newBtnInfo = buttons[_btnIdx]; // 해당 버튼 정보 갱신 (재고정보 수정된 것 반영)
            return true;
        }
        _newBtnInfo = buttons[_btnIdx]; // 위 if못타면 구매 안일어 난 것. => UIMenuButton에서 UpdateInfo()안일어난다.
        return false; 
    }
    // 플레이어와 상호작용할 때 호출되는 함수. 
    public void ShowMenu()
    {
        // UIManager -> UIMenuManager -> UIMenuButtonHolder => UIButton 으로 연결된다.
        uiMng.ShowMenu(buttons, BuyBeverage, btnColCnt);
    }
    // 플레이어와 상호작용할 때 호출되는 함수.
    public void HideMenu()
    {
        uiMng.HideMenu();
    }
} // end of class
