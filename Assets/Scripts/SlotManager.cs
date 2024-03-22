using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Joy{
    public class SlotManager : MonoBehaviour
    {
        public Image myStockSprite;
        public TMP_Text myStockNumber;
        public TMP_Text myStockTotalValue;
        private Button StockSell;
        
        private void Awake(){
            StockSell = this.GetComponent<Button>();
            StockSell.onClick.AddListener(SellOnClick);
        }

        private void SellOnClick(){
            int index = PlayerInventoryManager.instance.slotList.IndexOf(this);
            WalletManager.instance.SellStock(PlayerInventoryManager.instance.playerStockList[index].stock);
        }
    }
}

