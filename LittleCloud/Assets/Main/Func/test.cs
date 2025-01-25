using System.Collections.Generic;
using UnityEngine;
 
 
public class test : MonoBehaviour
{
    public ChatPanelManager cpm;
    // private int count;
    private List<string> dialogue = new List<string>();
    private List<bool> isMy = new List<bool>();
    void Start()
    {
        cpm.Init();
        dialogue.Add("Sending you a big hug. It’s okay, we need to recover quickly so we can be ready to welcome our baby back.");
        dialogue.Add("Seeing friends my age getting pregnant and having their babies so smoothly, I can’t help but wonder, why me...");
        dialogue.Add("I experienced a stillbirth at 30 weeks.");
        dialogue.Add("That sense of unfairness, I’ve felt it too.");
        dialogue.Add("We both understand the pain of loss. In the quiet of the night, it’s especially hard not to cry...");
        dialogue.Add("Let’s support each other and keep going!");

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
 
    // void Update()
    // {
    //     // if (Input.GetKeyDown(KeyCode.Space))
    //     if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
    //     {
    //         Debug.Log("test");
    //         cpm.AddBubble(dialogue[count],Random.Range(0,2)>0);
    //         count++;
    //         if (count > dialogue.Count-1)
    //         {
    //             count = 0;
    //         }
    //     }
    // }
}
 
 