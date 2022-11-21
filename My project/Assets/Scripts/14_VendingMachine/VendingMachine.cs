using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public enum EBeverageType { Cider, Coke, StrawberryMilk}
    
    [System.Serializable]
    public struct SButton
    {
        public EBeverageType type;
        public int cnt;
    }

    [SerializeField]
    private SButton[] buttons = null;

    private GameObject[] beveragePrefabs = null;
    private void Awake()
    {
        beveragePrefabs = Resources.LoadAll<GameObject>("Prefabs\\Beverages");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (BuyBeverageWithButtonIndex(0))
                SpawnBeverage(buttons[0].type);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (BuyBeverageWithButtonIndex(1))
                SpawnBeverage(buttons[1].type);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (BuyBeverageWithButtonIndex(2))
                SpawnBeverage(buttons[2].type);
        }
    }
    public bool BuyBeverageWithButtonIndex(int _btnIdx)
    {
        if (CheckStock(_btnIdx) == 0) return false;
        --buttons[_btnIdx].cnt;
        return true;
    }
    public void SpawnBeverage(EBeverageType _type)
    {
        GameObject go = Instantiate(beveragePrefabs[(int)_type]);
        go.transform.position = transform.position + GetRandomPositionWithRadius(2.5f);
    }
    private Vector3 GetRandomPositionWithRadius(float _r)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle))*_r;
    }
    public int CheckStock(int _btnIdx)
    {
        return buttons[_btnIdx].cnt;
    }


}
