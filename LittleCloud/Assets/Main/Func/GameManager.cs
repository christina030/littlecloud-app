// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class GameManager : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         Client.Instance.Start();
        
//         //打开登录界面
//         var loginPrefab = Resources.Load<GameObject>("LoginView");
//         var loginView = GameObject.Instantiate<GameObject>(loginPrefab);
//         loginView.AddComponent<LoginView>();
//     }
 
//     private void OnDestroy()
//     {
//         //退出账号
//         MessageHelper.Instance.SendOnOfflineMsg(PlayerData.Instance.LoginMsgS2C.account, 0);
//     }
// }
