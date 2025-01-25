using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
//using System.Web.Script.Serialization;

public class SaveLoadGame : MonoBehaviour
{
    private string dairyFileName = "/Diary.txt";
    private string labelsFileName = "/Labels.txt";
    private string indexFileName = "/IndexTable.txt";
    public string savePath;

    [System.Serializable]
    public class GameData
    {
        public Dictionary<int, string> diaryBook = new Dictionary<int, string>();
        public Dictionary<int, int> dailyLabels = new Dictionary<int, int>();
        public List<int> dailyIDs = new List<int>();
    }

    public GameData gameData;

    private void Awake()
    {
        savePath = $"{Application.persistentDataPath}/GameData";
        CreateDir(savePath);

        LoadGame();
    }

    private void CreateDir(string filePath)
    {
        if (Directory.Exists(filePath))
            return;
        Directory.CreateDirectory(filePath);
    }

    public void SaveGame()
    {
        CreateDir(savePath);

        File.WriteAllText(savePath + dairyFileName, JsonConvert.SerializeObject(gameData.diaryBook));
        File.WriteAllText(savePath + labelsFileName, JsonConvert.SerializeObject(gameData.dailyLabels));
        File.WriteAllText(savePath + indexFileName, JsonConvert.SerializeObject(gameData.dailyIDs));
        
        Debug.Log("Game Saved to " + savePath);
    }

    public void LoadGame()
    {
        if (Directory.Exists(savePath))
        {
            Debug.Log("Exist Path");
            gameData.diaryBook = JsonConvert
                .DeserializeObject<Dictionary<int, string>>(File.ReadAllText(savePath + dairyFileName));
            gameData.dailyLabels = JsonConvert
                .DeserializeObject<Dictionary<int, int>>(File.ReadAllText(savePath + labelsFileName));
            gameData.dailyIDs = JsonConvert
                .DeserializeObject<List<int>>(File.ReadAllText(savePath + indexFileName));
        }
        
        Debug.Log("Game Loaded from " + savePath);
    }
}
