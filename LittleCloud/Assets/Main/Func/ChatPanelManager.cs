using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class ChatPanelManager : MonoBehaviour
{
    public GameObject leftBubblePrefab;
    public GameObject rightBubblePrefab;
 
    private ScrollRect scrollRect;
    private Scrollbar scrollbar;
    
    private RectTransform content;
 
    [SerializeField] 
    private float stepVertical; //上下两个气泡的垂直间隔
    [SerializeField] 
    private float stepHorizontal; //左右两个气泡的水平间隔
    [SerializeField]
    private float maxTextWidth;//文本内容的最大宽度
 
    private float lastPos; //上一个气泡最下方的位置
    private float halfHeadLength;//头像高度的一半
 
    public void Init()
    {
        scrollRect = GetComponentInChildren<ScrollRect>();
        scrollbar = GetComponentInChildren<Scrollbar>();
        content = transform.Find("ViewPort").Find("Content").GetComponent<RectTransform>();
        // lastPos = 0;
        lastPos = stepVertical;
        halfHeadLength = leftBubblePrefab.transform.Find("head").GetComponent<RectTransform>().rect.height / 2;
        Debug.Log("init this.content: " + this.content);
        Debug.Log("lastPos: " + lastPos);
        Debug.Log("halfHeadLength: " + halfHeadLength);
        Debug.Log("stepVertical: " + stepVertical);
    }
 
    public void AddBubble(string content, bool isMy)
    {
        GameObject newBubble = isMy ? Instantiate(rightBubblePrefab, this.content) : Instantiate(leftBubblePrefab, this.content);
        //设置气泡内容
        TextMeshProUGUI text = newBubble.GetComponentInChildren<TextMeshProUGUI>();
        text.text = content;
        if (text.preferredWidth > maxTextWidth)
        {
            text.GetComponent<LayoutElement>().preferredWidth = maxTextWidth;
        }
        //计算气泡的水平位置
        float hPos = isMy ? stepHorizontal / 2 : -stepHorizontal / 2;
        //计算气泡的垂直位置
        float vPos = - stepVertical - halfHeadLength + lastPos;
        newBubble.transform.localPosition = new Vector2(hPos, vPos);
        //更新lastPos
        Image bubbleImage = newBubble.GetComponentInChildren<Image>();
        float imageLength = GetContentSizeFitterPreferredSize(bubbleImage.GetComponent<RectTransform>(), bubbleImage.GetComponent<ContentSizeFitter>()).y;
        lastPos = vPos - imageLength;
        //更新content的长度
        Debug.Log("content: " + content);
        Debug.Log("this.content: " + this.content);
        Debug.Log("vPos: " + vPos);
        Debug.Log("imageLength: " + imageLength);
        Debug.Log("lastPos: " + lastPos);
        Debug.Log("this.content.rect.height: " + this.content.rect.height);
        Debug.Log("this.content.rect.width: " + this.content.rect.width);
        Debug.Log("this.content.offsetMax: " + this.content.offsetMax);
        Debug.Log("this.content.offsetMax.x: " + this.content.offsetMax.x);
        if (-lastPos > this.content.rect.height)
        {
            // this.content.sizeDelta = new Vector2(this.content.rect.width, -lastPos);
            this.content.sizeDelta = new Vector2(0, -lastPos - this.content.rect.height);
            // this.content.offsetMax = new Vector2(0, -lastPos + imageLength - this.content.rect.height);
        }
 
        scrollRect.verticalNormalizedPosition = 0;//使滑动条滚轮在最下方
    }
 
    public Vector2 GetContentSizeFitterPreferredSize(RectTransform rect, ContentSizeFitter contentSizeFitter)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        return new Vector2(HandleSelfFittingAlongAxis(0, rect, contentSizeFitter),
            HandleSelfFittingAlongAxis(1, rect, contentSizeFitter));
    }
 
    private float HandleSelfFittingAlongAxis(int axis, RectTransform rect, ContentSizeFitter contentSizeFitter)
    {
        ContentSizeFitter.FitMode fitting =
            (axis == 0 ? contentSizeFitter.horizontalFit : contentSizeFitter.verticalFit);
        if (fitting == ContentSizeFitter.FitMode.MinSize)
        {
            return LayoutUtility.GetMinSize(rect, axis);
        }
        else
        {
            return LayoutUtility.GetPreferredSize(rect, axis);
        }
    }
}