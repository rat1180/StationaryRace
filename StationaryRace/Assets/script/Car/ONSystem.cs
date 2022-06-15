using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using SoftGear.Strix.Unity.Runtime.Event;

public class ONSystem : MonoBehaviour
{
    public int roomIDnum;  // ルームIDナンバー
    public string host;
    public string applicationId;
    public Level logLevel = Level.INFO;

    public string roomName = "New Room";

    public int capacity = 4;

    #region サーバー接続（今は他で依存）
    void Awake()
    {
        var strixNetwork = StrixNetwork.instance;

        strixNetwork.applicationId = applicationId;

        // まずマスターサーバーに接続します
        strixNetwork.ConnectMasterServer(
            host: host,
            connectEventHandler: _ => {
                Debug.Log("Connection established.");

                // マスターサーバーに接続した後でルームを作成できます
                strixNetwork.CreateRoom(
                    new RoomProperties
                    {
                        name = "testRoom",
                        //password = "66e3f2nk",       // このルームはパスワードで保護されているため、パスワードのないクライアントは参加できません
                        capacity = 10,                 // ルームが保持できるクライアントの最大数
                        key1 = 1,                      // key1を使用してこの試合で使用するNPCの難易度を表すことにします

                    },
                    new RoomMemberProperties
                    {
                        name = "testPlayer",           // これがプレイヤーの名前になります

                    },
                    handler: __ => {
                        Debug.Log("Room created.");
                    },
                    failureHandler: createRoomError => Debug.LogError("Could not create room.Reason: " + createRoomError.cause)
                );



            },
            errorEventHandler: connectError => Debug.LogError("Connection failed.Reason: " + connectError.cause)
        );
        #endregion

        #region よくわからん
        // プライベートルーム
        CreateRoom();
    }

    // ICondition…検索結果を絞り込むためのもの  Order…検索結果の並び順を指定するもの  limit…何件表示するか  offset…何件目から表示するか  RequestConfig…タイムアウトの値 nullの場合は30秒
    //private void SearchRoom(ICondition condition, Order order, int limit, int offset, RoomSearchEventHandler handler, FailureEventHandler failureHandler/*, RequestConfig config = null*/);
    #endregion

    private void OnConnectCallback(StrixNetworkConnectEventArgs args)
    {
        Debug.Log("接続");
    }

    private void OnConnectFailedCallback(StrixNetworkConnectFailedEventArgs args)
    {
        Debug.Log("失敗");
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
            Debug.Log("接続");
        }
    }

    private void CreateRoom()
    {

    RoomProperties roomProperties = new RoomProperties
        {
            capacity = capacity,
            name = roomName
        };

        RoomMemberProperties memberProperties = new RoomMemberProperties
        {
            name = StrixNetwork.instance.playerName
        };


        StrixNetwork.instance.CreateRoom(roomProperties, memberProperties, args => {
            Debug.Log("s");
        }, args => {
            Debug.Log("f");
        });
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
