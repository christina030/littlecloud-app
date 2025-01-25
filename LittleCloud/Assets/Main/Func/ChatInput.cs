using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatInput : MonoBehaviour
{
    public ChatPanelManager cpm;

    // [SerializeField] private GameObject inputField;
    [SerializeField] private TMP_InputField inputText;
    // [SerializeField] private GameObject outputText;
    
    // test
    [SerializeField] private bool isTest;
    private List<string> dialogue = new List<string>();
    private List<bool> isMy = new List<bool>();
    // test end

    void Start()
    {
        cpm.Init();
        
        // test
        if (isTest)
        {
            dialogue.Add("Sending you a big hug. It's okay, we need to recover quickly so we can be ready to welcome our baby back.");
            dialogue.Add("Seeing friends my age getting pregnant and having their babies so smoothly, I can't help but wonder, why me...");
            dialogue.Add("I experienced a stillbirth at 30 weeks.");
            dialogue.Add("That sense of unfairness, I've felt it too.");
            dialogue.Add("We both understand the pain of loss. In the quiet of the night, it's especially hard not to cry...");
            dialogue.Add("Let's support each other and keep going!");

            isMy.Add(false);
            isMy.Add(true);
            isMy.Add(false);
            isMy.Add(false);
            isMy.Add(false);
            isMy.Add(false);
            
            Debug.Log("test");
            for (int i=0; i<dialogue.Count; i++)
            {
                cpm.AddBubble(dialogue[i], isMy[i]);
            }
        }
        // test end
    }
 
    public void EnterChat()
    {
        if (inputText.text != "")
        {
            // Debug.Log("Enter: " + inputText.text);
            string text = inputText.text;
            cpm.AddBubble(text, true);
            inputText.text = "";
        }
    }
}
