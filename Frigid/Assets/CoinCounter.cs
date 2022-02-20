using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour{
    Text cointAmount;
    public static int cointamnt;

    void Start(){
        cointAmount= GetComponent<Text>();

    }      
    void Update()
    {
    cointAmount.text=cointamnt.ToString();
    }
}