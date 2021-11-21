using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMoney : MonoBehaviour
{
   public void MoneyReset()
    {
        PlayerPrefs.DeleteKey("currencyPref");
    }
}
