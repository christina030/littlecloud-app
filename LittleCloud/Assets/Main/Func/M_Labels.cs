using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class M_Labels : MonoBehaviour
{
    private string labelsFileName = "/All_Labels.txt";

    public Dictionary<int, Dictionary<int, string>> adviceLabels = new Dictionary<int, Dictionary<int, string>>();

    [SerializeField] private SaveLoadGame m_Saveloadgame;

    public void UpDateAdviceLabels(int playerYear, int playerMonth, int playerDay)
    {
        if (Directory.Exists(m_Saveloadgame.savePath))
        {
            Debug.Log("Exist Path");
            adviceLabels = JsonConvert
                .DeserializeObject<Dictionary<int, Dictionary<int, string>>>(File.ReadAllText(m_Saveloadgame.savePath + labelsFileName));
        }

        Debug.Log("UpDate Advice Labels");
        Debug.Log(m_Saveloadgame.savePath);
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
