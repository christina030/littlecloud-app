using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class M_Talk : MonoBehaviour
{
    // [SerializeField] private Image cloud;
    [SerializeField] private TextMeshProUGUI talk;
    // [SerializeField] private Canvas canvas;
    // [SerializeField] private Sprite[] sprites;
    private int cur_id = 0;

    [SerializeField] private TextAsset talkFile;  // 用於加載 txt 文件
    private string[] talk_set;

    [SerializeField] private TextToSpeech m_TextToSpeech;

    public void ChangeTalk()
    {
        int id = Random.Range(0, talk_set.Length);
        while (id == cur_id)
        {
            id = Random.Range(0, talk_set.Length);
        }
        talk.text = talk_set[id];
        cur_id = id;

        // m_TextToSpeech.Speak(talk_set[id]);
    }

    void LoadTalkFromFile()
    {
        if (talkFile != null)
        {
            // 按行分割文本文件內容，並去掉空行
            talk_set = talkFile.text.Split(new[] { "/END" }, System.StringSplitOptions.RemoveEmptyEntries);
        }
        else
        {
            Debug.LogError("No talk file provided.");
        }
    }

    void Start()
    {
        // 從 txt 文件讀取對話
        LoadTalkFromFile();

        ChangeTalk();
    }

    // void Update()
    // {
    //     if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
    //         //Debug.Log("touch!");

    //         PointerEventData pointer = new PointerEventData(EventSystem.current);
    //         pointer.position = Input.GetTouch(0).position;
    //         GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
    //         List<RaycastResult> results = new List<RaycastResult>();
    //         gr.Raycast(pointer, results);

    //         if (results.Count != 0)
    //         {
    //             if (results[0].gameObject.name == "CCloud")
    //             {
    //                 // 小雲朵動畫
    //                 // StartCoroutine(ChangeImage());

    //                 ChangeTalk();
    //             }

    //             //Debug.Log(results[0].gameObject.name);
    //         }
    //     }
    // }

    // 小雲朵動畫
    // IEnumerator ChangeImage()
    // {
    //     cloud.sprite = sprites[1];
    //     yield return new WaitForSeconds(0.2f);
    //     cloud.sprite = sprites[2];
    //     yield return new WaitForSeconds(0.2f);
    //     cloud.sprite = sprites[1];
    //     yield return new WaitForSeconds(0.2f);
    //     cloud.sprite = sprites[0];
    // }
}
