using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Action_Web : MonoBehaviour
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

    // [SerializeField] private SaveLoadGame m_Saveloadgame;
    // [SerializeField] private M_Date m_Date;
    [SerializeField] private M_Screen m_Screen;

    // [SerializeField] private TextMeshProUGUI textDate;
    // [SerializeField] private TextMeshProUGUI textDiary;

    // private int[] date;
    // private int dateInt;

    [SerializeField] private GameObject info_section, expert_section;
    [SerializeField] private TextMeshProUGUI infoText, expertText;

    void Start()
    {
        SwichToInfo();
    }

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

                    }
                    else if (y > x + slidingDistance && y < -x - slidingDistance)
                    {
                        if (!allowMultipleTimes && curVector == SlideVector.Right)
                        {
                            return;
                        }

                        curVector = SlideVector.Right;
                        Debug.Log("Right");

                        m_Screen.SwitchToMain();
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
    
    public void SwichToInfo()
    {
        info_section.SetActive(true);
        expert_section.SetActive(false);
        // infoText.text = "<u><b>資訊小站</b></u>";
        // expertText.text = "<b>專題文章</b>";
        infoText.text = "<u><b>Information</b></u>";
        expertText.text = "<b>Articles</b>";
    }

    public void SwichToExpert()
    {
        expert_section.SetActive(true);
        info_section.SetActive(false);
        // expertText.text = "<u><b>專題文章</b></u>";
        // infoText.text = "<b>資訊小站</b>";
        expertText.text = "<u><b>Articles</b></u>";
        infoText.text = "<b>Information</b>";
    }

}
