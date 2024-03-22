using UnityEngine;
using System;

namespace Joy {
    [CreateAssetMenu(fileName = "NewStock", menuName = "Joy/Stock Asset", order = 1)]
    public class StockAsset : ScriptableObject {
        public int stockId;
        public string stockName;
        public int currentMoneyValue;
        public Sprite stockSprite;
        public int fluctuation = 0;

        public void StockAsset_OnDayPassed(object sender, EventArgs e)
        {
            fluctuation = UnityEngine.Random.Range(-100, 100);

            currentMoneyValue += fluctuation;
            if (currentMoneyValue <= 0){
                currentMoneyValue = 1;
            }
            for (int i = 0; i < PlayerInventoryManager.instance.playerStockList.Count; i++) {
                PlayerInventoryManager.instance.playerStockList[i].stock.stock.currentMoneyValue = this.currentMoneyValue;
                PlayerInventoryManager.instance.slotList[i].myStockTotalValue.text = "$ " + 
                    (PlayerInventoryManager.instance.playerStockList[i].stock.stock.currentMoneyValue * 
                    PlayerInventoryManager.instance.playerStockList[i].numberOfStock).ToString();
            }
        }
    }
}
