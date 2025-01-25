using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extra;

public class SaveLoadPrefs : MonoBehaviour
{
    private void Awake()
    {
        Load();
    }

    public void Save()
    {
        PlayerSetting playerSetting = GetComponent<PlayerSetting>();

        int playerIdentity = playerSetting.PlayerIdentity; // true: 本人, false: 非本人
        int playerWay = playerSetting.PlayerWay;   // true: 自然, false: 人工
        int playerYear = playerSetting.PlayerYear;
        int playerMonth = playerSetting.PlayerMonth;
        int playerDay = playerSetting.PlayerDay;

        PlayerPrefs.SetInt("IsFirst", 0);
        PlayerPrefs.SetInt("PlayerIdentity", playerIdentity);
        PlayerPrefs.SetInt("PlayerWay", playerWay);
        PlayerPrefs.SetInt("PlayerYear", playerYear);
        PlayerPrefs.SetInt("PlayerMonth", playerMonth);
        PlayerPrefs.SetInt("PlayerDay", playerDay);

        PlayerPrefs.Save();

        Debug.Log("Prefs Saved");
        Debug.Log("0, " + playerIdentity.ToString() + ", " + playerWay.ToString() + ", " + playerYear.ToString() + ", " + playerMonth.ToString() + ", " + playerDay.ToString());
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("IsFirst"))
        {
            PlayerSetting playerSetting = GetComponent<PlayerSetting>();

            int isFirst = PlayerPrefs.GetInt("IsFirst");
            int playerIdentity = PlayerPrefs.GetInt("PlayerIdentity"); // true: 本人, false: 非本人
            int playerWay = PlayerPrefs.GetInt("PlayerWay");   // true: 自然, false: 人工
            int playerYear = PlayerPrefs.GetInt("PlayerYear");
            int playerMonth = PlayerPrefs.GetInt("PlayerMonth");
            int playerDay = PlayerPrefs.GetInt("PlayerDay");

            playerSetting.IsFirst = isFirst;
            playerSetting.PlayerIdentity = playerIdentity;
            playerSetting.PlayerWay = playerWay;
            playerSetting.PlayerYear = playerYear;
            playerSetting.PlayerMonth = playerMonth;
            playerSetting.PlayerDay = playerDay;

            Debug.Log("Prefs Loaded");
            Debug.Log(isFirst.ToString() + ", " + playerIdentity.ToString() + ", " + playerWay.ToString() + ", " + playerYear.ToString() + ", " + playerMonth.ToString() + ", " + playerDay.ToString());
        }
        else
        {
            Debug.Log("Prefs Not Loaded");

        }
    }

    public void Setting(int id, int val)
    {
        PlayerSetting playerSetting = GetComponent<PlayerSetting>();

        switch (id)
        {
            case 0:
                playerSetting.IsFirst = val;
                break;

            case 1:
                playerSetting.PlayerIdentity = val;
                break;

            case 2:
                playerSetting.PlayerWay = val;
                break;
        }
    }
}
