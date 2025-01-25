using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action_Chat : MonoBehaviour
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

    [SerializeField] private GameObject room1;
    [SerializeField] private GameObject room2;
    [SerializeField] private GameObject enter1;
    [SerializeField] private GameObject enter2;
    // [SerializeField] private Image bg;
    // [SerializeField] private Sprite sprite1, sprite2;
    private int chatRoomId = 1;
    
    // [SerializeField] private TextMeshProUGUI textDate;
    // [SerializeField] private TextMeshProUGUI textDiary;

    // private int[] date;
    // private int dateInt;

    void Start()
    {
        
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

                        m_Screen.SwitchToMain();
                    }
                    else if (y > x + slidingDistance && y < -x - slidingDistance)
                    {
                        if (!allowMultipleTimes && curVector == SlideVector.Right)
                        {
                            return;
                        }

                        curVector = SlideVector.Right;
                        Debug.Log("Right");

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
    
    public void ChangeChatRoom()
    {
        if (chatRoomId == 1) // 備孕小窩
        {
            chatRoomId = 2;
            room2.SetActive(true);
            enter2.SetActive(true);
            room1.SetActive(false);
            enter1.SetActive(false);
            // bg.sprite = sprite2;
        }
        else if (chatRoomId == 2) // 流產療聊
        {
            chatRoomId = 1;
            room1.SetActive(true);
            enter1.SetActive(true);
            room2.SetActive(false);
            enter2.SetActive(false);
            // bg.sprite = sprite1;
        }
    }
}
