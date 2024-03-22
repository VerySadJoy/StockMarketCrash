using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace Joy {
    public class DateTextManager : MonoBehaviour {
        [SerializeField] TMP_Text dateText;
        private string dateTextString = "Day 0";

        private void Start() {
            dateText.text = dateTextString;
            DayPassButtonManager.instance.OnDayPassed += DateTextManager_OnDayPassed;
        }

        private void DateTextManager_OnDayPassed(object sender, EventArgs e) {
            
            dateTextString = "Day " + DateManager.instance.date.ToString();
            dateText.text = dateTextString;
        }
    }
}


