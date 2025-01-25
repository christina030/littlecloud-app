using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Reply : MonoBehaviour
{
    [SerializeField] private GameObject replyWindow;
    [SerializeField] private GameObject MainScript;
    // [SerializeField] private Canvas canvas;

    // private bool isTouch = false;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.touchCount == 1)
    //     {
    //         if (Input.touches[0].phase == TouchPhase.Began) {
    //             //Debug.Log("touch!");

    //             PointerEventData pointer = new PointerEventData(EventSystem.current);
    //             pointer.position = Input.GetTouch(0).position;
    //             GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
    //             List<RaycastResult> results = new List<RaycastResult>();
    //             gr.Raycast(pointer, results);

    //             if (results.Count != 0)
    //             {
    //                 if (results[0].gameObject.name == "CTalk")
    //                 {
    //                     isTouch = true;
    //                 }

    //                 //Debug.Log(results[0].gameObject.name);
    //             }
    //         }
    //         else if (Input.touches[0].phase == TouchPhase.Ended) {
    //             //Debug.Log("touch!");

    //             PointerEventData pointer = new PointerEventData(EventSystem.current);
    //             pointer.position = Input.GetTouch(0).position;
    //             GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
    //             List<RaycastResult> results = new List<RaycastResult>();
    //             gr.Raycast(pointer, results);

    //             if (results.Count != 0)
    //             {
    //                 if (results[0].gameObject.name == "CTalk")
    //                 {
    //                     isTouch = true;
    //                 }

    //                 //Debug.Log(results[0].gameObject.name);
    //             }
    //         }
    //     }
    // }

    public void OpenReplyWindow()
    {
        replyWindow.SetActive(true);
        MainScript.GetComponent<Action_Main>().enabled = false;
    }
    public void CloseReplyWindow()
    {
        replyWindow.SetActive(false);
        MainScript.GetComponent<Action_Main>().enabled = true;
    }
}
