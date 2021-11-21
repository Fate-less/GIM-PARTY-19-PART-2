using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    [HideInInspector]
    public int currentMoney;
    [HideInInspector]
    public int  MoneyInRun = 0;

    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        // read the current balance from Player Prefs
        currentMoney = PlayerPrefs.GetInt("currencyPref");
        moneyText.text = MoneyInRun.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMoney(int moneyToAdd)
    {
        MoneyInRun += moneyToAdd;
        moneyText.text = MoneyInRun.ToString();

    }

    //public void subtractMoney(int moneyToSubtract)
    //{
    //    if(money - moneyToSubtract < 0)
    //    {
    //        Debug.Log("Not enough money");
    //    }
    //    else
    //    {
    //        money -= moneyToSubtract;
    //        moneyText.text = money.ToString();
    //    }
    //}

    public void OnGameOver()
    {
        // Do what you want
        // add currency earned to the total balance
        currentMoney += MoneyInRun;
        PlayerPrefs.SetInt("currencyPref", currentMoney);
        MoneyInRun = 0; // reset this for the next round
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Square")
        {
            OnGameOver();
        }
        else
        {
            OnGameOver();
        }
    }
}
