// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ChatView : MonoBehaviour
// {
//     private GameObject chatItem;
//     private Transform chatItemParent;
//     private Scrollbar scrollbar;
 
//     private Button sendBtn;
//     private InputField sendInput;
 
//     private Button publicChanelBtn;
//     private Transform scrollViewPublic;
    
//     //用来放置其他的聊天页面
//     private Transform scrollViewPageParent;//放全部聊天页面
//     private Transform tagListParent;//聊天框标签
//     private Transform friendBtnParent;//放好友位
//     private GameObject scroolViewPersonal;//私人聊天框
//     private GameObject personelChatPageBtn;//私人聊天框标签
//     private GameObject chatWithFriendBtn;//好友位按钮
 
//     private Button lastPressedTag;
//     private Color tagNormalColor = new Color(4/255f, 67/255f, 99/255f, 255/255f);
//     private Color tagPressedColor = new Color(0/255f,127/255f,191/255f, 255/255f);
 
//     private Button sendAddFriendBtn;
//     private InputField addFriendInput;
//     private Text addFriendTips;
 
//     private Button logoutBtn;
 
//     //聊天频道
//     private int chatType = 0;
//     private string chatTargetPlayer = "";
    
//     // Start is called before the first frame update
//     void OnEnable()
//     {
//         //发送信息
//         chatItem = Resources.Load<GameObject>("ChatItem");
//         //chatItemParent = this.transform.Find("ScrollViewPage/ScrollViewPublic/Viewport/Content");
//         scrollbar = this.transform.Find("ScrollViewPage/ScrollViewPublic/Scrollbar Vertical").GetComponent<Scrollbar>();
 
//         sendInput = this.transform.Find("SendInput").GetComponent<InputField>();//输入框
 
//         sendBtn = this.transform.Find("SendBtn").GetComponent<Button>();
//         sendBtn.onClick.AddListener(SendChatMsg); //发送聊天数据
 
//         //点击头像弹窗
//         portraitBtn = this.transform.Find("Popup_Dark/Portrait").GetComponent<Button>();
//         portraitPanel = this.transform.Find("PortraitPanel").gameObject;
//         portraitBtn.onClick.AddListener(() =>
//         {
//             portraitPanel.SetActive(!portraitPanel.activeInHierarchy);
//             friendsPanel.SetActive(false);
//         });
//         username = this.transform.Find("Popup_Dark/Username").gameObject.GetComponent<Text>();
//         username.text = PlayerData.Instance.LoginMsgS2C.account;
 
//         //朋友列表按钮
//         friendListBtn = this.transform.Find("Popup_Dark/FriendList").GetComponent<Button>();
//         friendsPanel = this.transform.Find("FriendsPanel").gameObject;
//         friendListBtn.onClick.AddListener(() =>
//         {
//             friendsPanel.SetActive(!friendsPanel.activeInHierarchy);
//             portraitPanel.SetActive(false);
//         });
 
//         //初始化朋友聊天界面相关设置。
//         scrollViewPageParent = this.transform.Find("ScrollViewPage");
//         scroolViewPersonal = Resources.Load<GameObject>("ScrollViewPersonal");
//         tagListParent = this.transform.Find("TagList/Viewport/Content");
//         personelChatPageBtn = Resources.Load<GameObject>("PersonalChatPageBtn");
//         friendBtnParent = this.transform.Find("FriendsPanel/Scroll View/Viewport/Content");
//         chatWithFriendBtn = Resources.Load<GameObject>("ChatWithFriendBtn");
 
//         //公共聊天
//         scrollViewPublic = scrollViewPageParent.transform.Find("ScrollViewPublic");
//         publicChanelBtn = tagListParent.transform.Find("PublicChanelBtn").GetComponent<Button>();
//         publicChanelBtn.onClick.AddListener(() =>
//         {
//             scrollViewPublic.SetAsLastSibling();
//             chatType = 0;
//             chatTargetPlayer = "";//设置公共聊天
//             //设置按钮按下颜色
//             lastPressedTag.gameObject.GetComponent<Image>().color = tagNormalColor;
//             lastPressedTag = publicChanelBtn;
//             publicChanelBtn.gameObject.GetComponent<Image>().color = tagPressedColor;
//             //关闭新消息提醒
//             publicChanelBtn.gameObject.transform.GetChild(1).gameObject.SetActive(false);
//         });
//         //初始化公共聊天按钮颜色
//         lastPressedTag = publicChanelBtn;
//         publicChanelBtn.gameObject.GetComponent<Image>().color = tagPressedColor;
 
//         //退出功能
//         logoutBtn = this.transform.Find("PortraitPanel/LogoutBtn").GetComponent<Button>();
//         logoutBtn.onClick.AddListener(() =>
//         {
//             //退出账号
//             MessageHelper.Instance.SendOnOfflineMsg(PlayerData.Instance.LoginMsgS2C.account, 0);
//             //打开登录界面
//             var loginPrefab = Resources.Load<GameObject>("LoginView");
//             var loginView = GameObject.Instantiate<GameObject>(loginPrefab);
//             loginView.AddComponent<LoginView>();
//             Destroy(this.gameObject);
//         });
 
//         sendAddFriendBtn = this.transform.Find("AddFriendPanel/AddBtn").GetComponent<Button>();
//         sendAddFriendBtn.onClick.AddListener(SendAddFriendMsg);
//         addFriendInput = this.transform.Find("AddFriendPanel/InputField").GetComponent<InputField>();
//         addFriendTips = this.transform.Find("AddFriendPanel/Tips").GetComponent<Text>();
 
//         //初始化朋友列表
//         foreach (var friend in PlayerData.Instance.LoginMsgS2C.friends)
//         {
//             InitChatWithFriend(friend.Key, friend.Value);
//         }
//         scrollViewPublic.transform.SetAsLastSibling();//默认优先展示公共聊天
        
//         //初始化过往聊天记录
//         List<ChatMsgS2C> localMsgs = new List<ChatMsgS2C>();
//         if (MessageHelper.Instance.TryLoadMsgFromLocal(out localMsgs))
//         {
//             foreach (var msg in localMsgs)
//             {
//                 if (msg.type == 0 ||
//                     (msg.type == 1 && msg.player == PlayerData.Instance.LoginMsgS2C.account) ||
//                     (msg.type == 1 && msg.targetPlayer == PlayerData.Instance.LoginMsgS2C.account))
//                 {
//                     AddMessage(msg.player, msg.msg, msg.time, msg.type, msg.targetPlayer, false);
//                 }
//             }
//         }
 
//         MessageHelper.Instance.chatHandle += ChatHandle;
//         MessageHelper.Instance.addFriendHandle += AddFriend;
//         MessageHelper.Instance.friendOnOfflineHandle += FriendOnOffline;
//     }
 
//     private void ChatHandle(ChatMsgS2C obj)
//     {
//         AddMessage(obj.player, obj.msg, obj.time, obj.type, obj.targetPlayer, true);
//         MessageHelper.Instance.SaveMsgToLocal(obj);//缓存本地聊天。
//     }
 
//     //添加消息条,,,,最后一条针对的是本地缓存的消息还是网络接收的信息，网络接收的信息为新消息，本地为旧消息
//     public void AddMessage(string title, string content, string time, int chatType, string chatTarget, bool newMsg)
//     {
//         var go = GameObject.Instantiate<GameObject>(chatItem);
//         if (chatType == 1)//私人聊天
//         {
//             if (title == PlayerData.Instance.LoginMsgS2C.account)//消息发送者是本人，表明这自己给别人发的消息，自己要能看到
//             {
//                 chatItemParent = this.transform.Find("ScrollViewPage/" + chatTarget + "/Viewport/Content");
//                 //自己发的消息不需要消息提示
//             }
//             else//消息发送者不是本人，但收到了这条消息，表明这别人给自己发的消息
//             {
//                 chatItemParent = this.transform.Find("ScrollViewPage/" + title + "/Viewport/Content");
//                 //设置消息提醒
//                 var newMsgTagTip = this.transform.Find("TagList/Viewport/Content/" + title).GetChild(3).gameObject;
//                 newMsgTagTip.SetActive(newMsg);
//                 var newMsgBtnTip = this.transform.Find("FriendsPanel/Scroll View/Viewport/Content/" + title)
//                     .GetChild(2).gameObject;
//                 newMsgBtnTip.SetActive(newMsg);
//             }
//         }
//         else if (chatType == 0)//公共聊天
//         {
//             chatItemParent = this.transform.Find("ScrollViewPage/ScrollViewPublic/Viewport/Content");
//             if (title != PlayerData.Instance.LoginMsgS2C.account)//不是自己发的消息在显示消息提醒
//             {
//                 //设置消息提醒
//                 var newMsgTagTip = this.transform.Find("TagList/Viewport/Content/PublicChanelBtn").GetChild(1).gameObject;
//                 newMsgTagTip.SetActive(newMsg);
//             }
//         }
//         //将单条消息实例化到对应的聊天框，并修改用户名、聊天信息、消息发送时间等
//         go.transform.SetParent(chatItemParent, false);
//         var titleText = go.transform.Find("MessagePanel/Title").GetComponent<Text>();
//         titleText.text = title;
//         var chat = go.transform.Find("MessagePanel/Message").GetComponent<Text>();
//         chat.text = content;
//         var chatTime = go.transform.Find("MessagePanel/Time").GetComponent<Text>();
//         chatTime.text = time;
//         //修改默认头像
//         if (title != PlayerData.Instance.LoginMsgS2C.account)
//         {
//             var portrait = go.transform.Find("UserPortrait").GetComponent<Image>();
//             portrait.sprite = Resources.Load<Sprite>("Sprites/头像");
//         }
 
//         StartCoroutine(ResetScrollbar());
//     }
 
//     //刷新对话框最新位置
//     public IEnumerator ResetScrollbar()
//     {
//         yield return new WaitForEndOfFrame();
//         scrollbar.value = 0;
//     }
 
//     //发送消息
//     private void SendChatMsg()
//     {
//         if (string.IsNullOrEmpty(sendInput.text))
//         {
//             return;
//         }
//         //如果希望减少带宽，用用户id也可以，不需要用用户账号
//         MessageHelper.Instance.SendChatMsg(PlayerData.Instance.LoginMsgS2C.account, sendInput.text, chatType, chatTargetPlayer);
//         sendInput.text = "";
//     }
    
//     //发送添加好友消息
//     private void SendAddFriendMsg()
//     {
//         if (string.IsNullOrEmpty(addFriendInput.text) && addFriendInput.text != PlayerData.Instance.LoginMsgS2C.account)
//         {
//             return;
//         }
//         MessageHelper.Instance.SendAddFriendMsg(PlayerData.Instance.LoginMsgS2C.account, addFriendInput.text);
//         addFriendInput.text = "";
//     }
    
//     //添加好友
//     private void AddFriend(AddFriendMsgS2C obj)
//     {
//         if (obj.result == 0)
//         {
//             PlayerData.Instance.LoginMsgS2C.friends = obj.friends;
//             InitChatWithFriend(obj.newFriend, obj.friendState);
//             scrollViewPublic.SetAsLastSibling();
// 			addFriendTips.text = "添加成功";
//         }
//         else
//         {
//             addFriendTips.text = "添加失败";
//         }
//     }
 
//     //初始化与朋友聊天的好友列表按钮、好友标签、好友聊天框，每个好友按钮点击都会生成好友标签和好友聊天框
//     private void InitChatWithFriend(string friendName, int friendState)
//     {
//         //聊天列表按钮
//         var go = GameObject.Instantiate<GameObject>(chatWithFriendBtn);
//         go.transform.SetParent(friendBtnParent, false);
//         go.gameObject.name = friendName;
//         go.transform.GetChild(0).GetComponent<Text>().text = friendName;
//         go.transform.GetChild(1).GetComponent<Image>().color = friendState == 1 ? Color.green : Color.gray;//更新好友在线状态
//         var btn = go.GetComponent<Button>();
//         btn.onClick.AddListener(() =>
//         {
//             if (tagListParent.transform.Find(friendName))//查看是否聊天标签有好友标签
//             {
//                 //仅调整聊天框置最前
//                 var friendChatScrollView = scrollViewPageParent.transform.Find(friendName);
//                 friendChatScrollView.transform.SetAsLastSibling();
//                 tagListParent.transform.Find(friendName).GetChild(2).GetComponent<Image>().color= friendState == 1 ? Color.green : Color.gray;//更新好友在线状态
//             }
//             else
//             {
//                 //添加一个好友聊天框
//                 var friendChatScrollView = GameObject.Instantiate<GameObject>(scroolViewPersonal);
//                 friendChatScrollView.transform.SetParent(scrollViewPageParent, false);
//                 friendChatScrollView.transform.SetAsLastSibling();
//                 friendChatScrollView.gameObject.name = friendName;
//                 //添加好友聊天标签
//                 var friendChatTagBtn = GameObject.Instantiate<GameObject>(personelChatPageBtn);
//                 friendChatTagBtn.transform.SetParent(tagListParent, false);
//                 friendChatTagBtn.gameObject.name = friendName;
//                 friendChatTagBtn.transform.GetChild(0).gameObject.GetComponent<Text>().text = friendName;
//                 friendChatTagBtn.GetComponent<Button>().onClick.AddListener(() =>
//                 {
//                     friendChatScrollView.transform.SetAsLastSibling();
//                     chatType = 1;
//                     chatTargetPlayer = friendName;//设置私人聊天和聊天对象
//                     //修改按钮颜色
//                     lastPressedTag.gameObject.GetComponent<Image>().color = tagNormalColor;
//                     friendChatTagBtn.gameObject.GetComponent<Image>().color = tagPressedColor;
//                     lastPressedTag = friendChatTagBtn.GetComponent<Button>();
//                     //关闭新消息提醒
//                     friendChatTagBtn.transform.GetChild(3).gameObject.SetActive(false);
//                     go.transform.GetChild(2).gameObject.SetActive(false);
//                 });
//                 friendChatTagBtn.transform.GetChild(2).GetComponent<Image>().color =
//                     go.transform.GetChild(1).GetComponent<Image>().color;
//                 var closeChatBtn = friendChatTagBtn.transform.GetChild(1).GetComponent<Button>();
//                 closeChatBtn.onClick.AddListener(() =>
//                 {
//                     Destroy(friendChatScrollView);
//                     Destroy(friendChatTagBtn, 0.1f);
//                     chatType = 0;
//                     chatTargetPlayer = "";//设置公共聊天
//                     lastPressedTag = publicChanelBtn;
//                     publicChanelBtn.gameObject.GetComponent<Image>().color = tagPressedColor;
//                     closeChatBtn.onClick.RemoveAllListeners();
//                 });
//             }
//             chatType = 1;
//             chatTargetPlayer = friendName;//设置私人聊天和聊天对象
//             //修改按钮颜色
//             lastPressedTag.gameObject.GetComponent<Image>().color = tagNormalColor;
//             tagListParent.transform.Find(friendName).gameObject.GetComponent<Image>().color = tagPressedColor;
//             lastPressedTag = tagListParent.transform.Find(friendName).gameObject.GetComponent<Button>();
//             //关闭新消息提醒
//             go.transform.GetChild(2).gameObject.SetActive(false);
//             tagListParent.transform.Find(friendName).GetChild(3).gameObject.SetActive(false);
//         });
//         //添加一个好友聊天框
//         var friendChatScrollView = GameObject.Instantiate<GameObject>(scroolViewPersonal);
//         friendChatScrollView.transform.SetParent(scrollViewPageParent, false);
//         friendChatScrollView.transform.SetAsLastSibling();
//         friendChatScrollView.gameObject.name = friendName;
//         //添加好友聊天标签
//         var friendChatTagBtn = GameObject.Instantiate<GameObject>(personelChatPageBtn);
//         friendChatTagBtn.transform.SetParent(tagListParent, false);
//         friendChatTagBtn.gameObject.name = friendName;
//         friendChatTagBtn.transform.GetChild(0).gameObject.GetComponent<Text>().text = friendName;
//         friendChatTagBtn.GetComponent<Button>().onClick.AddListener(() =>
//         {
//             friendChatScrollView.transform.SetAsLastSibling();
//             chatType = 1;
//             chatTargetPlayer = friendName;//设置私人聊天和聊天对象
//             //修改按钮颜色
//             lastPressedTag.gameObject.GetComponent<Image>().color = tagNormalColor;
//             friendChatTagBtn.gameObject.GetComponent<Image>().color = tagPressedColor;
//             lastPressedTag = friendChatTagBtn.GetComponent<Button>();
//             //关闭新消息提醒
//             friendChatTagBtn.transform.GetChild(3).gameObject.SetActive(false);
//             go.transform.GetChild(2).gameObject.SetActive(false);
//         });
//         friendChatTagBtn.transform.GetChild(2).GetComponent<Image>().color =
//             go.transform.GetChild(1).GetComponent<Image>().color;
//         var closeChatBtn = friendChatTagBtn.transform.GetChild(1).GetComponent<Button>();
//         closeChatBtn.onClick.AddListener(() =>
//         {
//             Destroy(friendChatScrollView);
//             Destroy(friendChatTagBtn, 0.1f);
//             chatType = 0;
//             chatTargetPlayer = "";//设置公共聊天
//             lastPressedTag = publicChanelBtn;
//             publicChanelBtn.gameObject.GetComponent<Image>().color = tagPressedColor;
//             closeChatBtn.onClick.RemoveAllListeners();
//         });
//     }
    
//     //好友上下线请求
//     private void FriendOnOffline(OnOfflineMsgS2C obj)
//     {
//         if (obj.player == PlayerData.Instance.LoginMsgS2C.account)
//         {
//             return;
//         }
//         if (tagListParent.Find(obj.player))
//         {
//             tagListParent.Find(obj.player).GetChild(2).gameObject.GetComponent<Image>().color = 
//                 obj.state == 1 ? Color.green : Color.gray;
//         }
//         friendBtnParent.Find(obj.player).GetChild(1).gameObject.GetComponent<Image>().color =
//             obj.state == 1 ? Color.green : Color.gray;
//     }
 
//     // Update is called once per frame
//     void Update()
//     {
//         // if (Input.GetKeyDown(KeyCode.A))
//         // {
//         //     AddMessage("xxx", "aldfja;dfajdkfjakdfjalkjdlkfjamkdjflkmajdlfjadjflajla;f", System.DateTime.Now.ToString());
//         // }
//     }
 
//     private void OnDisable()
//     {
//         MessageHelper.Instance.chatHandle -= ChatHandle;
//         MessageHelper.Instance.addFriendHandle -= AddFriend;
//         MessageHelper.Instance.friendOnOfflineHandle -= FriendOnOffline;
//         //退出账号
//         //MessageHelper.Instance.SendOnOfflineMsg(PlayerData.Instance.LoginMsgS2C.account, 0);
//     }
// }


// public class MessageHelper
// {
//     private static MessageHelper instance = new MessageHelper();
//     public static MessageHelper Instance => instance;//单例
    
//     byte[] data = new byte[4096];//接收消息的缓冲区
//     int msgLength = 0;//接收到的消息长度
 
//     //client接收到消息时，把buffer的数据复制到data数据缓冲区，数据长度加上接受的新有效数据流长度，handle处理数据
//     public void CopyToData(byte[] buffer, int length)
//     {
//         Array.Copy(buffer, 0, data, msgLength, length);
//         msgLength += length;
//         Handle();
//     }
    
//     private void Handle()
//     {
//         //包体大小(4) 协议ID(4) 包体(byte[])
//         if (msgLength >= 8)
//         {
//             byte[] _size = new byte[4];
//             Array.Copy(data, 0, _size, 0, 4);//把包体大小从第0位缓存4位长度
//             int size = BitConverter.ToInt32(_size, 0);//获得包体大小
 
//             //本次要拿的长度
//             var _length = 8 + size;//实际完整消息的长度：包体大小(4)+协议ID(4)+包体(byte[])
 
//             while (msgLength>=_length)//判断数据缓冲区的长度是否大于一条完整消息的长度。
//             {
//                 //拿出id
//                 byte[] _id = new byte[4];
//                 Array.Copy(data, 4, _id, 0, 4);//把协议ID从第4位缓存4位长度
//                 int id = BitConverter.ToInt32(_id, 0);//获得协议ID
 
//                 //包体
//                 byte[] body = new byte[size];
//                 Array.Copy(data, 8, body, 0, size);//把包体从第8位缓存size位长度
 
//                 if (msgLength>_length)//如果接收到的数据长度大于这次取出的完整一条数据的长度，说明还有数据
//                 {
//                     for (int i = 0; i < msgLength - _length; i++)
//                     {
//                         data[i] = data[_length + i];//前面取完一次完整消息了，把后面的消息前挪
//                     }
//                 }
//                 msgLength -= _length;//减掉已经取完的消息长度
//                 if (id != (int)MsgID.PingMsg)
//                 {
//                     Debug.Log($"{DateTime.Now} | Message | 发送的消息类型:{id} | 接收的消息内容:{Encoding.UTF8.GetString(body, 0, body.Length)}");
//                 }
//                 else
//                 {
//                     Debug.Log($"{DateTime.Now} | Ping | 接收的消息内容:Ping");
//                 }
//                 WaitHandle?.Invoke(id, false, Encoding.UTF8.GetString(body, 0, body.Length));
//                 //根据id进行处理,,实际项目一般使用观察者模式，监听id和Action事件绑定
//                 switch (id)
//                 {
//                     case (int)MsgID.RegisterMsg://注册请求
//                         RigisterMsgHandle(body);
//                         break;
//                     case (int)MsgID.LoginMsg://登录业务
//                         LoginMsgHandle(body);
//                         break;
//                     case (int)MsgID.ChatMsg://聊天业务
//                         ChatMsgHandle(body);
//                         break;
//                     case (int)MsgID.AddFriend://添加好友
//                         AddFriendHandle(body);
//                         break;
//                     case (int)MsgID.OnOffline://朋友上线下线
//                         FriendOnOfflineHandle(body);
//                         break;
//                     case (int)MsgID.PingMsg://维持连接
//                         PingHandle(body);
//                         break;
//                 }
//             }
//         }
//     }
 
//     //一旦开始发送消息，就让客户端等待消息回复，开启定时器，如果定时器结束前没有收到回复，说明断开连接，在GameManager中进行重连
//     public event Action<int, bool, string> WaitHandle;
//     //按格式封装消息，发送到服务器
//     public void SendToServer(int id, string str)
//     {
//         //Debug.Log("ID:" + id);
//         var body = Encoding.UTF8.GetBytes(str);
//         byte[] send_buff = new byte[body.Length + 8];
 
//         int size = body.Length;
 
//         var _size = BitConverter.GetBytes(size);
//         var _id = BitConverter.GetBytes(id);
 
//         Array.Copy(_size, 0, send_buff, 0, 4);
//         Array.Copy(_id, 0, send_buff, 4, 4);
//         Array.Copy(body, 0, send_buff, 8, body.Length);
//         if (id != (int)MsgID.PingMsg)
//         {
//             Debug.Log($"{DateTime.Now} | Message | 发送的消息类型:{id} | 发送的消息内容:{Encoding.UTF8.GetString(body, 0, body.Length)}");
//         }
//         else
//         {
//             Debug.Log($"{DateTime.Now} | Pong | 发送的消息内容:Pong");
//         }
        
//         Client.Instance.Send(send_buff);
//         //把发送的消息和id传递给订阅WaitHandle的方法，一旦断联，需要重连并重新发送消息。
//         WaitHandle?.Invoke(id, true, Encoding.UTF8.GetString(body, 0, body.Length));
//     }
 
//     //发送登录的消息给服务器 1002
//     public void SendLoginMsg(string account, string pwd)
//     {
//         LoginMsgC2S msg = new LoginMsgC2S();
//         msg.account = account;
//         msg.password = pwd;
//         var str = JsonHelper.ToJson(msg);//json格式化注册请求
//         SendToServer((int)MsgID.LoginMsg, str);//发送
//     }
 
//     public Action<LoginMsgS2C> loginHandle;
//     //处理登录(结果)请求
//     private void LoginMsgHandle(byte[] obj)
//     {
//         var str = Encoding.UTF8.GetString(obj);//将接受的消息从字节转换为string
//         LoginMsgS2C msg = JsonHelper.ToObject<LoginMsgS2C>(str);//在从json格式的string转为对应LoginMsgS2C
//         loginHandle?.Invoke(msg);//如果处理注册消息的事件有订阅，就执行。
//     }
    
//     //发送聊天信息给服务器
//     public void SendChatMsg(string account, string chat, int chatType, string chatTarget)
//     {
//         ChatMsgC2S msg = new ChatMsgC2S();
//         msg.player = account;
//         msg.msg = chat;
//         msg.time = System.DateTime.Now.ToString();
//         msg.type = chatType;
//         msg.targetPlayer = chatTarget;
//         var str = JsonHelper.ToJson(msg);//json格式化注册请求
//         SendToServer((int)MsgID.ChatMsg, str);//发送
//     }
 
//     public Action<ChatMsgS2C> chatHandle;
//     //处理聊天(转发)请求
//     private void ChatMsgHandle(byte[] obj)
//     {
//         var str = Encoding.UTF8.GetString(obj);//将接受的消息从字节转换为string
//         ChatMsgS2C msg = JsonHelper.ToObject<ChatMsgS2C>(str);//在从json格式的string转为对应ChatMsgS2C
//         chatHandle?.Invoke(msg);//如果处理注册消息的事件有订阅，就执行。
//     }
    
//     //发送注册的消息给服务器 1001
//     public void SendRegisterMsg(string account, string email, string pwd)
//     {
//         RegisterMsgC2S msg = new RegisterMsgC2S();
//         msg.account = account;
//         msg.email = email;
//         msg.password = pwd;
//         var str = JsonHelper.ToJson(msg);//json格式化注册请求
//         SendToServer((int)MsgID.RegisterMsg, str);//发送
//     }
 
//     public Action<RegisterMsgS2C> registerHandle;
//     //处理注册(结果)请求
//     private void RigisterMsgHandle(byte[] obj)
//     {
//         var str = Encoding.UTF8.GetString(obj);//将接受的消息从字节转换为string
//         RegisterMsgS2C msg = JsonHelper.ToObject<RegisterMsgS2C>(str);//在从json格式的string转为对应RegisterMsgS2C
//         registerHandle?.Invoke(msg);//如果处理注册消息的事件有订阅，就执行。
//     }
 
//     //发送添加好友消息
//     public void SendAddFriendMsg(string account, string addAccount)
//     {
//         AddFriendMsgC2S msg = new AddFriendMsgC2S();
//         msg.player = account;
//         msg.newFriend = addAccount;
//         var str = JsonHelper.ToJson(msg);//json格式化注册请求
//         SendToServer((int)MsgID.AddFriend, str);//发送
//     }
 
//     //处理添加好友请求
//     public Action<AddFriendMsgS2C> addFriendHandle;
//     private void AddFriendHandle(byte[] obj)
//     {
//         var str = Encoding.UTF8.GetString(obj);//将接受的消息从字节转换为string
//         AddFriendMsgS2C msg = JsonHelper.ToObject<AddFriendMsgS2C>(str);//在从json格式的string转为对应AddFriendMsgS2C
//         addFriendHandle?.Invoke(msg);//如果处理注册消息的事件有订阅，就执行。
//     }
 
//     //处理朋友上下线请求
//     public Action<OnOfflineMsgS2C> friendOnOfflineHandle;
//     private void FriendOnOfflineHandle(byte[] obj)
//     {
//         var str = Encoding.UTF8.GetString(obj);//将接受的消息从字节转换为string
//         OnOfflineMsgS2C msg = JsonHelper.ToObject<OnOfflineMsgS2C>(str);//在从json格式的string转为对应OnOfflineMsgS2C
//         friendOnOfflineHandle?.Invoke(msg);//如果处理注册消息的事件有订阅，就执行。
//     }
 
//     private void PingHandle(byte[] obj)
//     {
//         var str = Encoding.UTF8.GetString(obj);//将接受的消息从字节转换为string
//         SendToServer((int)MsgID.PingMsg, "pong");//发送
//     }
 
//     public void SendOnOfflineMsg(string account, int state)
//     {
//         OnOfflineMsgC2S msg = new OnOfflineMsgC2S();
//         msg.player = account;
//         msg.state = state;
//         var str = JsonHelper.ToJson(msg);//json格式化注册请求
//         SendToServer((int)MsgID.OnOffline, str);//发送
//     }
    
//     //缓存消息至本地
//     public void SaveMsgToLocal(ChatMsgS2C msg)
//     {
//         string path = Application.persistentDataPath + "/" + PlayerData.Instance.LoginMsgS2C.account + "/";
//         if (!Directory.Exists(path))
//         {
//             Directory.CreateDirectory(path);
//             if (!File.Exists(path + "Msgs.txt"))
//             {
//                 File.Create(path + "Msgs.txt").Dispose();
//             }
//         }
//         var str = JsonHelper.ToJson(msg) + "\n";
//         File.AppendAllText(path + "Msgs.txt", str);
//     }
 
//     //从本地加载消息记录
//     public bool TryLoadMsgFromLocal(out List<ChatMsgS2C> msgList)
//     {
//         string path = Application.persistentDataPath + "/" + PlayerData.Instance.LoginMsgS2C.account + "/Msgs.txt";
//         if (File.Exists(path))
//         {
//             List<ChatMsgS2C> msgs = new List<ChatMsgS2C>();
//             string[] strs = File.ReadAllLines(path);
//             foreach (var str in strs)
//             {
//                 msgs.Add(JsonHelper.ToObject<ChatMsgS2C>(str));
//             }
//             msgList = msgs;
//         }
//         else
//         {
//             msgList = new List<ChatMsgS2C>();
//         }
//         return File.Exists(path);
//     }
// }
 
// //1002
// public class LoginMsgC2S
// {
//     public string account;
//     public string password;
// }
 
// public class LoginMsgS2C
// {
//     public string account;
//     public string password;
//     public int result;//0成功 1失败:账号或密码错误
//     public Dictionary<string, int> friends;
// }
 
// //1001
// public class RegisterMsgC2S
// {
//     public string account;
//     public string email;
//     public string password;
// }
 
// public class RegisterMsgS2C
// {
//     public string account;
//     public string email;
//     public string password;
//     public int result;//0成功 1失败:已被注册的账号
// }
 
// //1003
// public class ChatMsgC2S
// {
//     public string player;
//     public string msg;
//     public string time;
//     public int type;//0世界聊天
//     public string targetPlayer;
// }
 
// //服务器转发给客户端
// public class ChatMsgS2C
// {
//     public string player;
//     public string msg;
//     public string time;
//     public int type;//0世界聊天
//     public string targetPlayer;
// }
 
// //1004
// public class AddFriendMsgC2S
// {
//     public string player;
//     public string newFriend;
// }
 
// public class AddFriendMsgS2C
// {
//     public string player;
//     public string newFriend;
//     public int result;
//     public Dictionary<string, int> friends;
//     public int friendState;
// }
 
// //1005
// public class OnOfflineMsgC2S
// {
//     public string player;
//     public int state;//0下线，1上线
// }
 
// public class OnOfflineMsgS2C
// {
//     public string player;
//     public int state;//0下线，1上线
// }
 
// public enum MsgID{
//     RegisterMsg = 1001,
//     LoginMsg = 1002,
//     ChatMsg = 1003,
//     AddFriend = 1004,
//     OnOffline = 1005,
//     PingMsg = 9999,
// }


