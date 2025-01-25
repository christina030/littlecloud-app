using System;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputText : MonoBehaviour
{
    [SerializeField] private GameObject inputField;
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private GameObject outputText;

    [SerializeField] private GameObject saveButton;
    // [SerializeField] private GameObject deleteButton;
    [SerializeField] private GameObject[] modifyObjects;
    [SerializeField] private GameObject[] viewObjects;

    [SerializeField] private GameObject moodObjects;
    [SerializeField] private GameObject bigMood;
    [SerializeField] private Image bigMoodImage;
    [SerializeField] private Sprite[] moodSprites;

    [SerializeField] private GameObject scripts;

    [SerializeField] private SaveLoadGame m_Saveloadgame;
    [SerializeField] private M_Date m_Date;

    // private int date;
    [SerializeField] private int mood;
    [SerializeField] private int page;

    public void SaveInput(int date)
    {
        outputText.GetComponent<TextMeshProUGUI>().text = inputText.text;

        // Save Text
        // date = m_Date.intDate;

        if (inputText.text == "")
        {
            if (m_Saveloadgame.gameData.diaryBook.ContainsKey(date))
            {
                m_Saveloadgame.gameData.diaryBook.Remove(date);
                // m_Saveloadgame.SaveGame();
            }
        }
        else
        {
            if (m_Saveloadgame.gameData.diaryBook.ContainsKey(date))
            {
                m_Saveloadgame.gameData.diaryBook[date] = inputText.text;
            }
            else
            {
                m_Saveloadgame.gameData.diaryBook.Add(date, inputText.text);
            }
            // m_Saveloadgame.SaveGame();
        }

        // // SetActive
        // foreach (GameObject button in modifyObjects)
        // {
        //     button.SetActive(false);

        // }
        // // inputField.SetActive(false);
        // // saveButton.SetActive(false);
        // // deleteButton.SetActive(false);

        // outputText.SetActive(true);
        // foreach (GameObject button in viewObjects)
        // {
        //     button.SetActive(true);

        // }

        // scripts.GetComponent<M_Diary>().enabled = true;
    }

    // public void ModifyInput()
    // {
    //     scripts.GetComponent<M_Diary>().enabled = false;
    //     inputText.text = outputText.GetComponent<TextMeshProUGUI>().text;

    //     outputText.SetActive(false);
    //     foreach (GameObject button in viewObjects)
    //     {
    //         button.SetActive(false);

    //     }

    //     foreach (GameObject button in modifyObjects)
    //     {
    //         button.SetActive(true);

    //     }
    //     // inputField.SetActive(true);
    //     // saveButton.SetActive(true);
    //     // deleteButton.SetActive(true);
    // }

    public void CancelInput()
    {
        foreach (GameObject button in modifyObjects)
        {
            button.SetActive(false);

        }
        inputField.SetActive(false);
        saveButton.SetActive(false);
        // deleteButton.SetActive(false);

        // outputText.SetActive(true);
        foreach (GameObject button in viewObjects)
        {
            button.SetActive(true);

        }

        scripts.GetComponent<M_Diary>().enabled = true;
    }

    public void DeleteInput()
    {
        outputText.GetComponent<TextMeshProUGUI>().text = "";
        bigMoodImage.sprite = moodSprites[0];

        // Delete Diary
        int date = m_Date.intDate;
        if (m_Saveloadgame.gameData.diaryBook.ContainsKey(date))
        {
            m_Saveloadgame.gameData.diaryBook.Remove(date);
        }
        if (m_Saveloadgame.gameData.dailyLabels.ContainsKey(date))
        {
            m_Saveloadgame.gameData.dailyLabels.Remove(date);
        }
        m_Saveloadgame.SaveGame();

        CancelInput();
    }

    
    public void SaveMood(int date)
    {
        // Save Mood
        // date = m_Date.intDate;

        if (m_Saveloadgame.gameData.dailyLabels.ContainsKey(date))
        {
            m_Saveloadgame.gameData.dailyLabels[date] = mood;
        }
        else
        {
            m_Saveloadgame.gameData.dailyLabels.Add(date, mood);
        }
        // m_Saveloadgame.SaveGame();
    }

    public void ModifyMood(int label)
    {
        page += 1;
        mood = label;
        bigMoodImage.sprite = moodSprites[label];
        moodObjects.SetActive(false);
        inputField.SetActive(true);
        bigMood.SetActive(true);
        saveButton.SetActive(true);
    }


    public void SaveDiary()
    {
        // Save Diary
        int date = m_Date.intDate;
        SaveMood(date);
        SaveInput(date);
        m_Saveloadgame.SaveGame();
        
        // SetActive
        inputField.SetActive(false);
        saveButton.SetActive(false);
        // deleteButton.SetActive(false);
        foreach (GameObject button in modifyObjects)
        {
            button.SetActive(false);

        }

        // outputText.SetActive(true);
        foreach (GameObject button in viewObjects)
        {
            button.SetActive(true);

        }

        scripts.GetComponent<M_Diary>().enabled = true;
    }

    public void ModifyDiary()
    {
        // Modify Diary
        page = 0;

        scripts.GetComponent<M_Diary>().enabled = false;
        inputText.text = outputText.GetComponent<TextMeshProUGUI>().text;

        // outputText.SetActive(false);
        // bigMood.SetActive(false);
        foreach (GameObject button in viewObjects)
        {
            button.SetActive(false);

        }

        // moodObjects.SetActive(true);
        // inputField.SetActive(true);
        // saveButton.SetActive(true);
        // deleteButton.SetActive(true);
        foreach (GameObject button in modifyObjects)
        {
            button.SetActive(true);

        }
    }

    public void GoBack()
    {
        if (page == 0)
        {
            page -= 1;
            CancelInput();
        }
        else if (page == 1)
        {
            page -= 1;
            inputField.SetActive(false);
            saveButton.SetActive(false);
            bigMood.SetActive(false);
            moodObjects.SetActive(true);
        }
    }
}
