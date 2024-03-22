using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Joy{
    public class WalletManager : MonoBehaviour
    {
        public static WalletManager instance;
        public TMP_Text playerMoneyText;
        public int playerMoney = 100000;
        private void Awake(){
            if (instance == null){
                instance = this;
            }
            else{
                Destroy(gameObject);
            }
        }

        private void Start(){            
            //StockManager.instance.OnDayPassed += stock.StockAsset_OnDayPassed;
            //DayPassButtonManager.instance.OnDayPassed += StockManager_OnDayPassed;
            UpdateUI();
        }
        public void BuyStock(StockManager buyingStock){
            playerMoney -= buyingStock.stock.currentMoneyValue;
            bool found = false;
            for (int i = 0; i < PlayerInventoryManager.instance.playerStockList.Count; i++) {
                PlayerStock playerStock = PlayerInventoryManager.instance.playerStockList[i];
                if (playerStock.stock == buyingStock) {
                    playerStock.numberOfStock++;
                    PlayerInventoryManager.instance.playerStockList[i] = playerStock;
                    PlayerInventoryManager.instance.slotList[i].myStockNumber.text = (int.Parse(PlayerInventoryManager.instance.slotList[i].myStockNumber.text) + 1).ToString();
                    PlayerInventoryManager.instance.slotList[i].myStockTotalValue.text = "$ " + 
                        (buyingStock.stock.currentMoneyValue * PlayerInventoryManager.instance.playerStockList[i].numberOfStock).ToString();
                    found = true;
                    break;
                }
            }
            if (!found) {
                int newSlotIndex = PlayerInventoryManager.instance.playerStockList.Count;
                PlayerInventoryManager.instance.slotList[newSlotIndex].gameObject.SetActive(true);
                PlayerInventoryManager.instance.playerStockList.Add(new PlayerStock(buyingStock, 1));
                PlayerInventoryManager.instance.slotList[newSlotIndex].myStockSprite.sprite = buyingStock.stock.stockSprite;
                PlayerInventoryManager.instance.slotList[newSlotIndex].myStockNumber.text = "1";
                PlayerInventoryManager.instance.slotList[newSlotIndex].myStockTotalValue.text = "$ " + 
                    (buyingStock.stock.currentMoneyValue * PlayerInventoryManager.instance.playerStockList[newSlotIndex].numberOfStock).ToString();
            }
            UpdateUI();
        }

        public void SellStock(StockManager sellingStock){
            playerMoney += sellingStock.stock.currentMoneyValue;
            for (int i = 0; i < PlayerInventoryManager.instance.playerStockList.Count; i++) {
                PlayerStock playerStock = PlayerInventoryManager.instance.playerStockList[i];
                if (playerStock.stock == sellingStock) {
                    if (playerStock.numberOfStock <= 0){
                        return;
                    }
                    playerStock.numberOfStock--;
                    PlayerInventoryManager.instance.playerStockList[i] = playerStock;
                    PlayerInventoryManager.instance.slotList[i].myStockNumber.text = (int.Parse(PlayerInventoryManager.instance.slotList[i].myStockNumber.text) - 1).ToString();
                    PlayerInventoryManager.instance.slotList[i].myStockTotalValue.text = "$ " + 
                        (sellingStock.stock.currentMoneyValue * PlayerInventoryManager.instance.playerStockList[i].numberOfStock).ToString();
                    if (playerStock.numberOfStock <= 0){
                        PlayerInventoryManager.instance.slotList[i].gameObject.SetActive(false);
                        PlayerInventoryManager.instance.playerStockList.RemoveAt(i);
                    }
                    break;
                }
            }
            UpdateUI();
        }

        private void UpdateUI(){
            playerMoneyText.text = "$ " + playerMoney.ToString();
            
        }
    }
}
