using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    // [SerializeField] private GameObject soul;
    // public GameObject setting, diary, calendar, plant, station, link;

    // [SerializeField] private M_Screen m_Screen;

    // private Vector3 origin_pos;
    // private Vector3 origin_scale;
    // private Quaternion origin_rotation;

    // void Start()
    // {
    //     origin_pos = soul.transform.localPosition;
    //     origin_scale = soul.transform.localScale;
    //     origin_rotation = soul.transform.rotation;
    // }

    // public void Move2(GameObject traget, bool open_main, bool open_setting, bool open_diary, bool open_calendar, bool open_plant, bool open_station, bool open_link, bool open_begin, bool open_end)
    // {
    //     StartCoroutine(Moving(traget, open_main, open_setting, open_diary, open_calendar, open_plant, open_station, open_link, open_begin, open_end));
    // }

    // public void Back2Main(bool open_main, bool open_setting, bool open_diary, bool open_calendar, bool open_plant, bool open_station, bool open_link, bool open_begin, bool open_end)
    // {
    //     StartCoroutine(MovingBack(open_main, open_setting, open_diary, open_calendar, open_plant, open_station, open_link, open_begin, open_end));
    // }

    // IEnumerator Moving(GameObject traget, bool open_main, bool open_setting, bool open_diary, bool open_calendar, bool open_plant, bool open_station, bool open_link, bool open_begin, bool open_end)
    // {
    //     soul.GetComponent<Animator>().enabled = false;
    //     yield return new WaitForSeconds(0.1f);

    //     while (Vector3.Distance(soul.transform.localPosition, traget.transform.localPosition) > 0.001f)
    //     {
    //         soul.transform.localPosition = Vector3.MoveTowards(soul.transform.localPosition, traget.transform.localPosition, 15f);
    //         soul.transform.localScale = soul.transform.localScale * 0.96f;

    //         yield return new WaitForSeconds(0.01f);
    //     }

    //     soul.SetActive(false);
    //     yield return new WaitForSeconds(0.1f);

    //     m_Screen.SwichScreen(open_main, open_setting, open_diary, open_calendar, open_plant, open_station, open_link, open_begin, open_end);
    // }

    // IEnumerator MovingBack(bool open_main, bool open_setting, bool open_diary, bool open_calendar, bool open_plant, bool open_station, bool open_link, bool open_begin, bool open_end)
    // {
    //     m_Screen.SwichScreen(open_main, open_setting, open_diary, open_calendar, open_plant, open_station, open_link, open_begin, open_end);
    //     yield return new WaitForSeconds(0.1f);

    //     soul.transform.rotation = origin_rotation;
    //     soul.SetActive(true);

    //     while (Vector3.Distance(soul.transform.localPosition, origin_pos) > 0.001f)
    //     {
    //         soul.transform.localPosition = Vector3.MoveTowards(soul.transform.localPosition, origin_pos, 15f);
    //         if (soul.transform.localScale.x < origin_scale.x)
    //             soul.transform.localScale = soul.transform.localScale / 0.96f;
    //         else
    //             soul.transform.localScale = origin_scale;

    //         yield return new WaitForSeconds(0.01f);
    //     }
    //     soul.transform.localPosition = origin_pos;
    //     soul.transform.localScale = origin_scale;

    //     yield return new WaitForSeconds(0.1f);
    //     soul.GetComponent<Animator>().enabled = true;
    // }
}
