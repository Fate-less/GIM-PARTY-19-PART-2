using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMoneyText : MonoBehaviour
{
    public MoneyScript Money;
    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = Money.MoneyInRun.ToString();
    }
}
