using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDate : MonoBehaviour
{
    public int[] stroedDate = new int[3];

    [SerializeField] private M_Calendar m_Calendar;

    public void UpdateStoredDate(int[] date)
    {
        stroedDate = date;
    }

    public void SelectDate()
    {
        m_Calendar.SetSelectedDate(stroedDate);
        Debug.Log(stroedDate);
    }
}
