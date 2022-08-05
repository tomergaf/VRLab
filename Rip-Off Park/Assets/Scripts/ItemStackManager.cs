using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemStackManager : AbsBoothItem
{
    [Tooltip("Set to false if no need to know if items invalidate or if using AbsBoothItems")]
    public bool needValidation = true;
    public UnityEvent Stack_Exhausted;
    public UnityEvent Item_Invalidated;

    public List<GameObject> items;
    private List<AbsBoothItem> boothItems = new List<AbsBoothItem>();

    private int numOfItems;
    private int invalidItemsNum = 0;

    private void Start()
    {

        foreach (GameObject gameObject in items)
        {
            AbsBoothItem absBoothItem = gameObject.GetComponent<AbsBoothItem>();
            if (absBoothItem is BoothItem)
            {
                ((BoothItem)absBoothItem).Item_Invalidated.AddListener(ItemInvalidated);
                Debug.Log("added listener");
            }
            boothItems.Add(absBoothItem);
        }
        InitValues();
    }

    public override void InitValues()
    {
        invalidItemsNum = 0;
        numOfItems = items.Count;
        foreach (AbsBoothItem boothItem in boothItems)
        {
            Debug.Log("Initializing stack item: " + boothItem.name);
            boothItem.InitValues();
        }
    }
    public override void ResetItem()
    {
        foreach(AbsBoothItem boothItem  in boothItems)
        {
            Debug.Log("Stack reset:" + boothItem.name);
            boothItem.ResetItem();
            InitValues();
        }
    }

    public override void GameEnd()
    {
        foreach (AbsBoothItem boothItem in boothItems)
        {
            Debug.Log("Stack Game End: " + boothItem.name);
            boothItem.GameEnd();
        }
    }

    public override void GameStart()
    {
        foreach (AbsBoothItem boothItem in boothItems)
        {
            Debug.Log("Stack Game Start: " + boothItem.name);
            boothItem.GameStart();
            InitValues();
        }
    }
    
    public virtual void ItemInvalidated(BoothItem boothItem)
    {
        Debug.Log("Item from stack: " + gameObject.name + " was invalidated: " + boothItem.name);
        invalidItemsNum += 1;
        Item_Invalidated.Invoke();
        if (invalidItemsNum == numOfItems)
            ExhaustStack();

    }

    public virtual void ExhaustStack()
    {
        Debug.Log("Stack Exhausted: " + gameObject.name);
        Stack_Exhausted.Invoke();
    }

    public float GetInvalidItemsNum()
    {
        return invalidItemsNum;
    }
}
