using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Screen : MonoBehaviour
{
    [SerializeField] private GameObject main_screen, setting_screen, diary_screen, diarybook_screen, calendar_screen, plant_screen, station_screen, link_screen, begin_screen, end_screen, chat_screen, web_screen;

    [SerializeField] private MoveTo m_MoveTo;
    [SerializeField] private M_Date m_Date;
    [SerializeField] private M_Diary m_Diary;
    [SerializeField] private M_Calendar m_Calendar;

    [SerializeField] private TextToSpeech m_TextToSpeech;

    public void SwichScreen(bool open_main, bool open_setting, bool open_diary, bool open_diarybook, bool open_calendar, bool open_plant, bool open_station, bool open_link, bool open_begin, bool open_end, bool open_chat, bool open_web)
    {
        main_screen.SetActive(open_main);
        setting_screen.SetActive(open_setting);
        diary_screen.SetActive(open_diary);
        diarybook_screen.SetActive(open_diarybook);
        calendar_screen.SetActive(open_calendar);
        plant_screen.SetActive(open_plant);
        station_screen.SetActive(open_station);
        link_screen.SetActive(open_link);
        begin_screen.SetActive(open_begin);
        end_screen.SetActive(open_end);
        chat_screen.SetActive(open_chat);
        web_screen.SetActive(open_web);
    }

    // public void SwitchToStation()
    // {
    //     m_MoveTo.Move2(m_MoveTo.station, true, false, false, false, false, true, false, false, false, false, false);
    // }

    public void SwitchToMain()
    {
        SwichScreen(true, false, false, false, false, false, false, false, false, false, false, false);
        m_TextToSpeech.Silence();
        // m_MoveTo.Back2Main(true, false, false, false, false, false, false, false, false, false, false);
        // m_Date.Back2Today();
    }

    public void SwitchToChat()
    {
        SwichScreen(false, false, false, false, false, false, false, false, false, false, true, false);
    }

    public void SwitchToWeb()
    {
        SwichScreen(false, false, false, false, false, false, false, false, false, false, false, true);
    }

    public void SwitchToSetting()
    {
        SwichScreen(false, true, false, false, false, false, false, false, false, false, false, false);
    }

    public void SwitchToDiary()
    {
        SwichScreen(false, false, true, false, false, false, false, false, false, false, false, false);
        // m_Diary.UpdateDiary();
        // m_MoveTo.Move2(m_MoveTo.diary, false, false, true, false, false, false, false, false, false, false, false);
    }

    public void SwitchToDiaryBook()
    {
        SwichScreen(false, false, false, true, false, false, false, false, false, false, false, false);
        // m_Diary.UpdateDiary();
        // m_MoveTo.Move2(m_MoveTo.diary, false, false, true, false, false, false, false, false, false, false, false);
    }

    public void SwitchToPlant()
    {
        SwichScreen(false, false, false, false, false, true, false, false, false, false, false, false);
    }

    public void SwitchToCalendar()
    {
        SwichScreen(false, false, false, false, true, false, false, false, false, false, false, false);
        //m_Calendar.UpdateCalendar();
        // m_MoveTo.Move2(m_MoveTo.calendar, false, false, false, true, false, false, false, false, false, false, false);
    }
}
