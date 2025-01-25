using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Date : MonoBehaviour
{
    public int[] todayDate = new int[3];
    public int[] curDate = new int[3];
    public int intDate;
    public int curNumDay;

    public int[] lastDays = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    // Start is called before the first frame update
    void Awake()
    {
        todayDate[0] = DateTime.Now.Year;
        todayDate[1] = DateTime.Now.Month;
        todayDate[2] = DateTime.Now.Day;
        todayDate.CopyTo(curDate, 0);
        UpdateIntDate();
        UpdateNumDay();
    }

    private void UpdateIntDate()
    {
        intDate = curDate[0] * 10000 + curDate[1] * 100 + curDate[2];
    }

    private void UpdateNumDay()
    {
        if (curDate[1] == 2)
        {
            if (curDate[0] % 400 == 0 || (curDate[0] % 4 == 0 && curDate[0] % 100 != 0))
            {
                curNumDay = 29;
            }
            else
            {
                curNumDay = lastDays[curDate[1]];
            }
        }
        else
        {
            curNumDay = lastDays[curDate[1]];
        }
    }

    private void NextYear()
    {
        curDate[0] += 1;
        curDate[1] = 1;
        UpdateNumDay();
    }

    private void LastYear()
    {
        if (curDate[0] > 1)
        {
            curDate[0] -= 1;
            curDate[1] = 12;
            UpdateNumDay();
        }
    }

    public void NextMonth()
    {
        curDate[1] += 1;
        curDate[2] = 1;

        if (curDate[1] > 12)
        {
            NextYear();
        }

        UpdateNumDay();
    }

    public void LastMonth()
    {
        curDate[1] -= 1;
        curDate[2] = curNumDay;
        
        if (curDate[1] < 1)
        {
            LastYear();
        }

        UpdateNumDay();
    }

    public void Tomorrow()
    {
        curDate[2] += 1;

        if (curDate[2] > curNumDay)
        {
            NextMonth();
            
        }

        UpdateIntDate();
    }

    public void Yesterday()
    {
        curDate[2] -= 1;

        if (curDate[2] < 1)
        {
            LastMonth();
        }

        UpdateIntDate();
    }

    public void Back2Today()
    {
        todayDate.CopyTo(curDate, 0);

        UpdateIntDate();
        UpdateNumDay();
    }
}
