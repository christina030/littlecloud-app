using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class M_Calendar : MonoBehaviour
{
    public enum SlideVector
    {
        None,
        Up,
        Down,
        Left,
        Right
    };

    [SerializeField] private bool allowMultipleTimes = false;
    [SerializeField] private float offsetTime = 0.1f;
    [SerializeField] private float slidingDistance = 80f;

    private Vector2 touchBegin = Vector2.zero;
    private Vector2 touchEnd = Vector2.zero;
    private float timer;

    public SlideVector curVector = SlideVector.None;

    [SerializeField] private M_Date m_Date;

    [SerializeField] private TextMeshProUGUI textMonth;
    [SerializeField] private TextMeshProUGUI textDate;

    [SerializeField] private GameObject date_set;
    private GameObject[] dates;

    //private int[] initDate = new int[] { 2023, 11, 1 };
    private int curFirst;
    private int curNumDay;
    private int[] curDate;
    //private int initLast = 4;
    private int[] selectedDate = new int[3];

    private GameObject[] GetAllDateButtons(GameObject button_set)
    {
        int cnt = button_set.transform.childCount;
        GameObject[] dates = new GameObject[cnt];

        for (int i=0; i<cnt; i++)
        {
            dates[i] = button_set.transform.GetChild(i).gameObject;
        }

        return dates;
    }

    void Start()
    {
        dates = GetAllDateButtons(date_set);
        UpdateCalendar();
        selectedDate = curDate;
        UpdateDateInfo();
    }

    private void GetFirst()
    {
        //curFirst = (DateTime.Now.DayOfWeek + 7 - ((m_Date.curDate[2] - 1) % 7)) % 7;
        DateTime dateValue = new DateTime(curDate[0], curDate[1], 1);
        curFirst = (int)dateValue.DayOfWeek;
        curNumDay = m_Date.curNumDay;
    }

    public void UpdateCalendar()
    {
        curDate = m_Date.curDate;

        GetFirst();

        int lastDay = curFirst + curNumDay;
        int date = 1;
        for (int i = 0; i < 42; i++)
        {
            if (i < curFirst || i >= lastDay)
            {
                dates[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                dates[i].transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                dates[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = date.ToString();

                dates[i].GetComponent<StoreDate>().UpdateStoredDate(new int[3] { curDate[0], curDate[1], date });

                dates[i].transform.GetChild(1).gameObject.SetActive(true);

                date++;
            }
        }

        textMonth.text = curDate[0].ToString() + "年" + curDate[1].ToString() + "月";
    }

    public void SetSelectedDate(int[] date)
    {
        selectedDate = date;
        UpdateDateInfo();
    }

    public void UpdateDateInfo()
    {
        textDate.text = selectedDate[0].ToString() + "年" + selectedDate[1].ToString() + "月" + selectedDate[2].ToString() + "日";

    }

    ///*
    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                touchBegin = Input.touches[0].position;
                timer = 0;
            }

            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                timer += Time.deltaTime;

                if (timer > offsetTime)
                {
                    touchEnd = Input.touches[0].position;
                    float x = touchBegin.x - touchEnd.x;
                    float y = touchBegin.y - touchEnd.y;

                    if (y + slidingDistance < x && y > -x - slidingDistance)
                    {
                        if (!allowMultipleTimes && curVector == SlideVector.Left)
                        {
                            return;
                        }

                        curVector = SlideVector.Left;
                        Debug.Log("Left");

                        m_Date.NextMonth();
                        UpdateCalendar();
                    }
                    else if (y > x + slidingDistance && y < -x - slidingDistance)
                    {
                        if (!allowMultipleTimes && curVector == SlideVector.Right)
                        {
                            return;
                        }

                        curVector = SlideVector.Right;
                        Debug.Log("Right");

                        m_Date.LastMonth();
                        UpdateCalendar();
                    }
                    //else if (y > x + slidingDistance && y - slidingDistance > -x)
                    //{
                    //    if (!allowMultipleTimes && curVector == SlideVector.Down)
                    //    {
                    //        return;
                    //    }

                    //    curVector = SlideVector.Down;
                    //    Debug.Log("Down");
                    //}
                    //else if (y + slidingDistance < x && y < -x - slidingDistance)
                    //{
                    //    if (!allowMultipleTimes && curVector == SlideVector.Up)
                    //    {
                    //        return;
                    //    }

                    //    curVector = SlideVector.Up;
                    //    Debug.Log("Up");
                    //}

                    touchBegin = touchEnd;
                    timer = 0;
                }
            }

            else if (Input.touches[0].phase == TouchPhase.Ended)
            {
                curVector = SlideVector.None;
            }
        }
    }
    //*/
}
