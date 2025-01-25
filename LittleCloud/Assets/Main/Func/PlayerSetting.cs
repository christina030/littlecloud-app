//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Extra
{
    public class PlayerSetting : MonoBehaviour
    {
        //[SerializeField] private TMP_InputField playerNameInputField;

        //public string PlayerName
        //{
        //    get { return playerNameInputField.text; }
        //    set { playerNameInputField.text = value; }
        //}

        [SerializeField] private M_Date m_Date;

        [SerializeField] private TMP_Dropdown playerYearDropdown;
        [SerializeField] private TMP_Dropdown playerMonthDropdown;
        [SerializeField] private TMP_Dropdown playerDayDropdown;

        public int IsFirst;
        public int PlayerIdentity; // 1: 本人, 0: 非本人
        public int PlayerWay; // 1: 自然, 0: 人工
        public int PlayerYear
        {
            get { return m_Date.todayDate[0] - playerYearDropdown.value; }
            set { playerYearDropdown.value = m_Date.todayDate[0] - value; }
        }
        public int PlayerMonth
        {
            get { return playerMonthDropdown.value + 1; }
            set { playerMonthDropdown.value = value - 1; }
        }
        public int PlayerDay
        {
            get { return playerDayDropdown.value + 1; }
            set { playerDayDropdown.value = value - 1; }
        }
    }
}

