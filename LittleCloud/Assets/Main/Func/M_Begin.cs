using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class M_Begin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI T_Q;
    [SerializeField] private TextMeshProUGUI T_A1, T_A2;

    [SerializeField] private GameObject soul;
    [SerializeField] private GameObject buttonBack;
    [SerializeField] private GameObject buttonComfirm;
    [SerializeField] private GameObject button1, button2;
    [SerializeField] private GameObject dropdown1, dropdown2, dropdown3;

    [SerializeField] private TMP_Dropdown playerYearDropdown;
    [SerializeField] private TMP_Dropdown playerMonthDropdown;
    [SerializeField] private TMP_Dropdown playerDayDropdown;

    [SerializeField] private M_Screen m_Screen;
    [SerializeField] private M_Date m_Date;
    [SerializeField] private SaveLoadPrefs m_SaveLoadPrefs;

    private string[] questions =
    {
        "我是小雲朵，將與你一起走過一段特別的旅程，請讓我好好認識你。\n\n你為何而來呢？",
        "請問你是以何種方式與小生命分別的呢？",
        "請問你與小生命分別的日子是？"
    };

    private string[,] answers =
    {
        {
            "與小生命分別的父母",
            "想了解小雲朵的世界"
        },
        {
            "自然",
            "人工"
        }
    };

    private List<string> years = new List<string>();
    private List<string> months = new List<string>();
    private List<string> days = new List<string>();

    private int curID = 0;

    private Vector3 origin_pos;
    private bool is_moving = false;

    void Start()
    {
        T_Q.text = questions[0];
        T_A1.text = answers[0, 0];
        T_A2.text = answers[0, 1];

        SetDropdowns();

        origin_pos = soul.transform.localPosition;
    }

    public void NextQuestion(int val)
    {
        curID += 1;
        T_Q.text = questions[curID];

        if (curID == 2)
        {
            m_SaveLoadPrefs.Setting(2, val);    // 0: IsFirst, 1: PlayerIdentity, 2: PlayerWay

            Move3();

            button1.SetActive(false);
            button2.SetActive(false);
            dropdown1.SetActive(true);
            dropdown2.SetActive(true);
            dropdown3.SetActive(true);
            buttonComfirm.SetActive(true);
        }
        else
        {
            m_SaveLoadPrefs.Setting(1, val);    // 0: IsFirst, 1: PlayerIdentity, 2: PlayerWay

            Move2();

            buttonBack.SetActive(true);
            T_A1.text = answers[curID, 0];
            T_A2.text = answers[curID, 1];
        }
    }

    public void LastQuestion()
    {
        curID -= 1;
        T_Q.text = questions[curID];
        T_A1.text = answers[curID, 0];
        T_A2.text = answers[curID, 1];

        if (curID == 0)
        {
            Move1();

            buttonBack.SetActive(false);
        }
        else
        {
            Move2();

            button1.SetActive(true);
            button2.SetActive(true);
            dropdown1.SetActive(false);
            dropdown2.SetActive(false);
            dropdown3.SetActive(false); 
            buttonComfirm.SetActive(false);
        }
    }

    private void SetDropdowns()
    {
        years.Clear();
        months.Clear();
        days.Clear();


        for (int i= m_Date.todayDate[0]; i>=1900; i--)
        {
            years.Add(i.ToString());
        }
        for (int i = 1; i <= 12; i++)
        {
            months.Add(i.ToString());
        }
        for (int i = 1; i <= 31; i++)
        {
            days.Add(i.ToString());
        }

        playerYearDropdown.ClearOptions();
        playerYearDropdown.AddOptions(years);

        playerMonthDropdown.ClearOptions();
        playerMonthDropdown.AddOptions(months);

        playerDayDropdown.ClearOptions();
        playerDayDropdown.AddOptions(days);

        playerYearDropdown.value = 0;
        playerMonthDropdown.value = m_Date.todayDate[1] - 1;
        playerDayDropdown.value = m_Date.todayDate[2] - 1;
    }

    public void SetDayDropdown()
    {
        days.Clear();

        int year = m_Date.todayDate[0] - playerYearDropdown.value;
        int month = playerMonthDropdown.value + 1;

        if (month == 2)
        {
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                for (int i = 1; i <= 29; i++)
                {
                    days.Add(i.ToString());
                }
            }
            else
            {
                for (int i = 1; i <= m_Date.lastDays[month]; i++)
                {
                    days.Add(i.ToString());
                }
            }
        }
        else
        {
            for (int i = 1; i <= m_Date.lastDays[month]; i++)
            {
                days.Add(i.ToString());
            }
        }

        playerDayDropdown.ClearOptions();
        playerDayDropdown.AddOptions(days);
    }

    private void Move1()
    {
        StartCoroutine(Moving(origin_pos));
    }

    private void Move2()
    {
        float dy = 70f;

        Vector3 traget_pos = new Vector3(origin_pos.x, origin_pos.y + dy, origin_pos.z);

        StartCoroutine(Moving(traget_pos));
    }

    private void Move3()
    {
        float dy = 170f;

        Vector3 traget_pos = new Vector3(origin_pos.x, origin_pos.y + dy, origin_pos.z);

        StartCoroutine(Moving(traget_pos));
    }

    IEnumerator Moving(Vector3 traget_pos)
    {
        while (is_moving)
        {
            yield return new WaitForSeconds(0.01f);
        }

        is_moving = true;

        float dy1 = (traget_pos.y - soul.transform.localPosition.y) / 3;

        Vector3 traget_pos1 = new Vector3(origin_pos.x - 10, soul.transform.localPosition.y + dy1, origin_pos.z);
        Vector3 traget_pos2 = new Vector3(traget_pos1.x, traget_pos1.y + dy1 / 3, traget_pos1.z);
        Vector3 traget_pos3 = new Vector3(origin_pos.x + 10, soul.transform.localPosition.y + dy1 * 2, origin_pos.z);
        Vector3 traget_pos4 = new Vector3(traget_pos3.x, traget_pos3.y + dy1 / 3, traget_pos3.z);

        while (Vector3.Distance(soul.transform.localPosition, traget_pos1) > 0.001f)
        {
            soul.transform.localPosition = Vector3.MoveTowards(soul.transform.localPosition, traget_pos1, 0.5f);

            yield return new WaitForSeconds(0.01f);
        }

        while (Vector3.Distance(soul.transform.localPosition, traget_pos2) > 0.001f)
        {
            soul.transform.localPosition = Vector3.MoveTowards(soul.transform.localPosition, traget_pos2, 0.5f);

            yield return new WaitForSeconds(0.01f);
        }

        while (Vector3.Distance(soul.transform.localPosition, traget_pos3) > 0.001f)
        {
            soul.transform.localPosition = Vector3.MoveTowards(soul.transform.localPosition, traget_pos3, 0.5f);

            yield return new WaitForSeconds(0.01f);
        }

        while (Vector3.Distance(soul.transform.localPosition, traget_pos4) > 0.001f)
        {
            soul.transform.localPosition = Vector3.MoveTowards(soul.transform.localPosition, traget_pos4, 0.5f);

            yield return new WaitForSeconds(0.01f);
        }

        while (Vector3.Distance(soul.transform.localPosition, traget_pos) > 0.001f)
        {
            soul.transform.localPosition = Vector3.MoveTowards(soul.transform.localPosition, traget_pos, 0.5f);

            yield return new WaitForSeconds(0.01f);
        }

        soul.transform.localPosition = traget_pos;
        yield return new WaitForSeconds(0.01f);

        is_moving = false;
    }
}
