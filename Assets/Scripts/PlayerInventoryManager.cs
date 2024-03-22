using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Joy{
    public struct PlayerStock{
        public StockManager stock{get; set;}
        public int numberOfStock{get; set;} 
        public PlayerStock(StockManager stock, int numberOfStock){
            this.stock = stock;
            this.numberOfStock = numberOfStock;
        }
    }


    public class PlayerInventoryManager : MonoBehaviour
    {
        public static PlayerInventoryManager instance;
        public List<PlayerStock> playerStockList = new List<PlayerStock>();
        public List<SlotManager> slotList = new List<SlotManager>();
        private void Awake(){
            if (instance == null){
                instance = this;
            }
            else{
                Destroy(gameObject);
            }
        }
        private void Update(){
            
        }
    }
}

