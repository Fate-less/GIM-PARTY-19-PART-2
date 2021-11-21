using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text moneyText;
    [HideInInspector]
    public int currentMoney;
    // Start is called before the first frame update
    void Start()
    {
        currentMoney = PlayerPrefs.GetInt("currencyPref");
        moneyText.text = "Money: " + currentMoney.ToString();
    }
}
