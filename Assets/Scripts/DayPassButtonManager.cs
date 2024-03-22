using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Joy{
    public class DayPassButtonManager : MonoBehaviour
    {
        public static DayPassButtonManager instance;
        public event EventHandler OnDayPassed;
        public Button dayButton;

        private void Awake() {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start(){
            dayButton = this.GetComponent<Button>();
            dayButton.onClick.AddListener(ButtonOnClick);
        }
        private void ButtonOnClick(){
            //DateManager.instance.aDayPassed();

            OnDayPassed?.Invoke(this, EventArgs.Empty);
        }

    }
}

