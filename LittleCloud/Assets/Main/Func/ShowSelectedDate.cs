using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowSelectedDate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDate;
    [SerializeField] private SaveLoadGame m_Saveloadgame;

    // 0�X�B1�c�B2�ʡB3��B4�ءB5�T�B6�B�B7��

    public void UpdateDateInfo()
    {
        //textDate.text = selectedDate[0].ToString() + "�~" + selectedDate[1].ToString() + "��" + selectedDate[2].ToString() + "��";

    }

    public void ModifyLabel()
    {
        //scripts.GetComponent<M_Diary>().enabled = false;
        //inputText.text = outputText.GetComponent<TextMeshProUGUI>().text;

        //outputText.SetActive(false);
        //foreach (GameObject button in otherButtons)
        //{
        //    button.SetActive(false);

        //}

        //inputField.SetActive(true);
        //saveButton.SetActive(true);
        //cancelButton.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
