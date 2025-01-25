using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowSelectedDate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDate;
    [SerializeField] private SaveLoadGame m_Saveloadgame;

    // 0出、1惡、2性、3月、4建、5禁、6運、7休

    public void UpdateDateInfo()
    {
        //textDate.text = selectedDate[0].ToString() + "年" + selectedDate[1].ToString() + "月" + selectedDate[2].ToString() + "日";

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
