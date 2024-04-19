using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchaser : MonoBehaviour
{
    public void OnPurchaseCompleted(Product product)
    {
        switch (product.definition.id)
        {
            case "1":
                AddTenSeconds();
                break;
        }
    }

    public void AddTenSeconds()
    {
        GameObject.Find("Timer").GetComponent<Timer>().gameTime += 10;
    }
}
