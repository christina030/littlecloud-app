using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// using TMPro;

public class Action_Main : MonoBehaviour
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
    [SerializeField] private M_Talk m_Talk;
    [SerializeField] private M_Reply m_Reply;

    [SerializeField] private Canvas canvas;

    // [SerializeField] private TextMeshProUGUI textDate;
    // [SerializeField] private TextMeshProUGUI textDiary;

    // private int[] date;
    // private int dateInt;

    private bool isBegin = true;
    private bool isTouchCloud = false;
    private bool isTouchTalk = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (isBegin && Input.touches[0].phase == TouchPhase.Began)
            {
                // 計時開始
                touchBegin = Input.touches[0].position;
                timer = 0;

                // 判斷按的物件
                PointerEventData pointer = new PointerEventData(EventSystem.current);
                pointer.position = Input.GetTouch(0).position;
                GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
                List<RaycastResult> results = new List<RaycastResult>();
                gr.Raycast(pointer, results);

                if (results.Count != 0)
                {
                    if (results[0].gameObject.name == "CCloud")
                    {
                        isTouchCloud = true;
                    }
                    else if (results[0].gameObject.name == "CTalk")
                    {
                        isTouchTalk = true;
                    }
                }
                Debug.Log("Touch " + results[0].gameObject.name);
            }

            else if (isBegin && Input.touches[0].phase == TouchPhase.Moved)
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

                        isBegin = false;
                        isTouchCloud = false;
                        isTouchTalk = false;
                        m_Screen.SwitchToWeb();
                    }
                    else if (y > x + slidingDistance && y < -x - slidingDistance)
                    {
                        if (!allowMultipleTimes && curVector == SlideVector.Right)
                        {
                            return;
                        }

                        curVector = SlideVector.Right;
                        Debug.Log("Right");

                        isBegin = false;
                        isTouchCloud = false;
                        isTouchTalk = false;
                        m_Screen.SwitchToChat();
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
                isBegin = true;
                curVector = SlideVector.None;
                
                // 判斷按的物件
                PointerEventData pointer = new PointerEventData(EventSystem.current);
                pointer.position = Input.GetTouch(0).position;
                GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
                List<RaycastResult> results = new List<RaycastResult>();
                gr.Raycast(pointer, results);

                if (results.Count != 0)
                {
                    if (isTouchCloud && results[0].gameObject.name == "CCloud")
                    {
                        // 小雲朵動畫
                        // StartCoroutine(ChangeImage());
                        m_Talk.ChangeTalk();
                    }
                    else if (isTouchTalk && results[0].gameObject.name == "CTalk")
                    {
                        m_Reply.OpenReplyWindow();
                    }
                }
                isTouchCloud = false;
                isTouchTalk = false;
            }
        }
    }
}
