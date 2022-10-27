using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using SoftGear.Strix.Unity.Runtime.Event;
using SoftGear.Strix.Client.Core.Model.Manager.Filter.Builder;

public class ONSystem : MonoBehaviour
{
    public int roomIDnum;  // ルームIDナンバー
    public string host;
    public string applicationId;
    public int port = 9122;
    public Level logLevel = Level.INFO;

    public GameObject SystemINF;
    public GameObject WaitMacth;

    /// <summary>
    /// ルームに参加可能な最大人数
    /// </summary>
    public int capacity = 4;

    /// <summary>
    /// ルーム名
    /// </summary>
    public string roomName = "New Room";

    /// <summary>
    /// ルーム入室完了時イベント
    /// </summary>
    public UnityEvent onRoomEntered;

    /// <summary>
    /// ルーム入室失敗時イベント
    /// </summary>
    public UnityEvent onRoomEnterFailed;

    void Awake()
    {
        capacity = PushBt.GAMEMODE;

        var strixNetwork = StrixNetwork.instance;

        strixNetwork.applicationId = applicationId;

        #region 接続案１

        //// まずマスターサーバーに接続します
        //strixNetwork.ConnectMasterServer(
        //    host: host,
        //    connectEventHandler: _ => {
        //        Debug.Log("Connection established.");

        //        //// マスターサーバーに接続した後でルームを作成できます
        //        //strixNetwork.CreateRoom(
        //        //    new RoomProperties
        //        //    {
        //        //        name = "testRoom",
        //        //        //password = "66e3f2nk",       // このルームはパスワードで保護されているため、パスワードのないクライアントは参加できません
        //        //        capacity = 10,                 // ルームが保持できるクライアントの最大数
        //        //        key1 = 1,                      // key1を使用してこの試合で使用するNPCの難易度を表すことにします

        //        //    },
        //        //    new RoomMemberProperties
        //        //    {
        //        //        name = "testPlayer",           // これがプレイヤーの名前になります

        //        //    },
        //        //    handler: __ =>
        //        //    {
        //        //        Debug.Log("Room created.");
        //        //    },
        //        //    failureHandler: createRoomError => Debug.LogError("Could not create room.Reason: " + createRoomError.cause)
        //        //);



        //    },
        //    errorEventHandler: connectError => Debug.LogError("Connection failed.Reason: " + connectError.cause)
        //);
        #endregion

        #region 接続案２(成功)
        //サーバー接続
        StrixNetwork.instance.playerName = PushBt.PlayerName;
        StrixNetwork.instance.ConnectMasterServer(host, port, OnConnectCallback, OnConnectFailedCallback);
        #endregion
    }

    // ICondition…検索結果を絞り込むためのもの  Order…検索結果の並び順を指定するもの  limit…何件表示するか  offset…何件目から表示するか  RequestConfig…タイムアウトの値 nullの場合は30秒
    //private void SearchRoom(ICondition condition, Order order, int limit, int offset, RoomSearchEventHandler handler, FailureEventHandler failureHandler/*, RequestConfig config = null*/);


    private void OnConnectCallback(StrixNetworkConnectEventArgs args)
    {
        //Debug.Log("接続");
        if (capacity == 1)
        {
           
            CreateRoom();
        }
        else
        {
            EnterRoom();
        }
    }

    private void OnConnectFailedCallback(StrixNetworkConnectFailedEventArgs args)
    {
        //Debug.Log("失敗");
    }

    // Start is called before the first frame update
    void Start()
    {
        //StrixNetwork.instance.DisconnectMasterServer();
    }

    // Update is called once per frame
    void Update()
    {
        if (StrixNetwork.instance.masterSession.IsConnected)
        {
            //Debug.Log("接続");
        }
    }

    public void EnterRoom()
    {
        //StrixNetwork.instance.JoinRandomRoom(StrixNetwork.instance.playerName, args => {
        //    onRoomEntered.Invoke();
        //}, args => {
        //    CreateRoom();
        //});
        var strixNetwork = StrixNetwork.instance;

        RoomMemberProperties memberProperties = new RoomMemberProperties
        {
            name = PushBt.PlayerName,
            //追加
            properties = new Dictionary<string, object>() {
            { "state", 0 }  // 初期状態は "Not Ready"
        }
        };
        Debug.Log(PushBt.PASS);
        strixNetwork.SearchRoom(
                            condition: ConditionBuilder.Builder().Field("name").EqualTo(PushBt.PASS).Build(),  //「My Game Room」という名前のすべての部屋を検索します
                            limit: 1,                                                                            // 結果を10件のみ取得します
                            offset: 0,                                                                            // 結果を先頭から取得します
                            handler: searchResults => {
                                Debug.Log(searchResults.roomInfoCollection.Count + " rooms found.");
                                if(searchResults.roomInfoCollection.Count == 0)
                                {
                                    CreateRoom();
                                }
                                foreach (var roomInfo in searchResults.roomInfoCollection)
                                {
                                    StrixNetwork.instance.JoinRoom(

    new RoomJoinArgs
    {
        host = roomInfo.host,
        port = roomInfo.port,
        roomId = roomInfo.roomId,
        memberProperties = memberProperties
    },
    args =>
    {
        PushBt.GAMEMODE = roomInfo.capacity;
        onRoomEntered.Invoke();
        Debug.Log("JoinRoom succeeded");
    },
    args =>
    {
        CreateRoom();
        Debug.Log("JoinRoom failed. error = " + args.cause);
    }
);
                                }

                            },

                            failureHandler: searchError => Debug.LogError("Search failed.Reason: " + searchError.cause));

        
    }

    private void CreateRoom()
    {
        //SystemINF.GetComponent<SystemINF>().USERcntRESET();

        if (PushBt.GAMEMODE == 1)
        {
            RoomProperties roomProperties = new RoomProperties
            {
                capacity = capacity,
                name = roomName
            };

            RoomMemberProperties memberProperties = new RoomMemberProperties
            {
                name = PushBt.PlayerName,
                //追加
                properties = new Dictionary<string, object>() {
            { "state", 0 }  // 初期状態は "Not Ready"
        }
            };
            StrixNetwork.instance.CreateRoom(roomProperties, memberProperties, args =>
            {
                onRoomEntered.Invoke();
            }, args =>
            {
                onRoomEnterFailed.Invoke();
            });


        }
        else
        {
            RoomProperties roomProperties = new RoomProperties
            {
                capacity = PushBt.GAMEMODE,
                name = PushBt.PASS
            };

            RoomMemberProperties memberProperties = new RoomMemberProperties
            {
                name = StrixNetwork.instance.playerName,
                //追加
                properties = new Dictionary<string, object>() {
            { "state", 0 }  // 初期状態は "Not Ready"
                   
        }
            };
            StrixNetwork.instance.CreateRoom(roomProperties, memberProperties, args =>
            {
                onRoomEntered.Invoke();
            }, args =>
            {
                onRoomEnterFailed.Invoke();
            });
        }
        
    }

    public void SetNotRady()
    {
        // ルームメンバーの状態を変更します: 0は「準備中」、1は「準備完了」
        StrixNetwork.instance.SetRoomMember(
            StrixNetwork.instance.selfRoomMember.GetPrimaryKey(),
                new Dictionary<string, object>() {
        { "properties", new Dictionary<string, object>() {
            { "state", 0 }
        } }
                },
                args =>
                {
                    Debug.Log("SetRoomMember succeeded");
                },
                args =>
                {
                    Debug.Log("SetRoomMember failed. error = " + args.cause);
                }

            );
        WaitMacth.GetComponent<WaitMacth>().WaitRoomIn();
    }

#region レース

void Ready()
    {
        if (CheckAllRoomMembersState(1))
        {
            //スタート呼び出し
        }
    }

    //メンバチェック
    public static bool CheckAllRoomMembersState(int desiredState)
    {
        foreach (var roomMember in StrixNetwork.instance.roomMembers)
        {
            if (!roomMember.Value.GetProperties().TryGetValue("state",
                out object value))
            {
                return false;
            }

            if ((int)value != desiredState)
            {
                return false;
            }
        }

        Debug.Log("CheckAllRoomMembersState OK");
        return true;
    }

    #endregion
}
