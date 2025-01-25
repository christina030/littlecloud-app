using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class M_Diary : MonoBehaviour
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

    [SerializeField] private SaveLoadGame m_Saveloadgame;
    [SerializeField] private M_Date m_Date;

    [SerializeField] private TextMeshProUGUI textDate;
    [SerializeField] private TextMeshProUGUI textDiary;
    [SerializeField] private Image bigMoodImage;
    [SerializeField] private Sprite[] moodSprites;

    private int[] date;
    private int dateInt;

    void Start()
    {
        UpdateDiary();
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

                    // Left
                    if (y + slidingDistance < x && y > -x - slidingDistance)
                    {
                        if (!allowMultipleTimes && curVector == SlideVector.Left)
                        {
                            return;
                        }

                        curVector = SlideVector.Left;
                        Debug.Log("Left");

                        m_Date.Tomorrow();
                        UpdateDiary();
                    }
                    // Right
                    else if (y > x + slidingDistance && y < -x - slidingDistance)
                    {
                        if (!allowMultipleTimes && curVector == SlideVector.Right)
                        {
                            return;
                        }

                        curVector = SlideVector.Right;
                        Debug.Log("Right");

                        m_Date.Yesterday();
                        UpdateDiary();
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

    public void UpdateDiary()
    {
        date = m_Date.curDate;
        dateInt = m_Date.intDate;
        Debug.Log(dateInt);

        // textDate.text = date[0].ToString() + "年" + date[1].ToString() + "月" + date[2].ToString() + "日";
        textDate.text = date[0].ToString() + " . " + date[1].ToString() + " . " + date[2].ToString();

        if (m_Saveloadgame.gameData.diaryBook.ContainsKey(dateInt))
            textDiary.text = m_Saveloadgame.gameData.diaryBook[dateInt];
        else
            textDiary.text = "";
            
        if (m_Saveloadgame.gameData.dailyLabels.ContainsKey(dateInt))
            bigMoodImage.sprite = moodSprites[m_Saveloadgame.gameData.dailyLabels[dateInt]];
        else
            bigMoodImage.sprite = moodSprites[0];
    }
}
