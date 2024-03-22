using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Joy{
    public class DateManager : MonoBehaviour
    {
        public static DateManager instance;
        public int date = 1;
        public void Awake(){
            if (instance == null){
                instance = this;
            }
            else{
                Destroy(gameObject);
            }
        }

        private void Start() {
            DayPassButtonManager.instance.OnDayPassed += DateManager_OnDayPassed;
        }

        public void DateManager_OnDayPassed(object sender, EventArgs e){
            date++;
        }
        
    }
}

