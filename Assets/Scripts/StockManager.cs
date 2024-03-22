using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


namespace Joy{
    public class StockManager : MonoBehaviour
    {
        [SerializeField] TMP_Text stockNameText;
        [SerializeField] TMP_Text stockMoneyText;
        public StockAsset stock;
        public Image stockImage;
        private Button stockBuy;

        private void Awake(){
            stockBuy = this.GetComponent<Button>();
            stockBuy.onClick.AddListener(BuyOnClick);
        }
        
        private void Start(){
            stockNameText.text = stock.stockName;
            stockMoneyText.text = "$" + stock.currentMoneyValue.ToString();
            stockImage.sprite = stock.stockSprite;
            
            DayPassButtonManager.instance.OnDayPassed += stock.StockAsset_OnDayPassed;
            DayPassButtonManager.instance.OnDayPassed += StockManager_OnDayPassed;
        }

        private void StockManager_OnDayPassed(object sender, EventArgs e)
        {
            //Debug.Log("hi");
            //stockImage.sprite = stock.stockSprite;
            if (stock.fluctuation > 0){
                stockMoneyText.color = Color.red;
            }
            else{
                stockMoneyText.color = Color.blue;
            }
            stockMoneyText.text = "$" + stock.currentMoneyValue.ToString();
            
        }

        private void BuyOnClick(){
            WalletManager.instance.BuyStock(this);
        }
    }
}

