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
    public int roomIDnum;  // ���[��ID�i���o�[
    public string host;
    public string applicationId;
    public int port = 9122;
    public Level logLevel = Level.INFO;

    public GameObject SystemINF;
    public GameObject WaitMacth;

    /// <summary>
    /// ���[���ɎQ���\�ȍő�l��
    /// </summary>
    public int capacity = 4;

    /// <summary>
    /// ���[����
    /// </summary>
    public string roomName = "New Room";

    /// <summary>
    /// ���[�������������C�x���g
    /// </summary>
    public UnityEvent onRoomEntered;

    /// <summary>
    /// ���[���������s���C�x���g
    /// </summary>
    public UnityEvent onRoomEnterFailed;

    void Awake()
    {
        capacity = PushBt.GAMEMODE;

        var strixNetwork = StrixNetwork.instance;

        strixNetwork.applicationId = applicationId;

        #region �ڑ��ĂP

        //// �܂��}�X�^�[�T�[�o�[�ɐڑ����܂�
        //strixNetwork.ConnectMasterServer(
        //    host: host,
        //    connectEventHandler: _ => {
        //        Debug.Log("Connection established.");

        //        //// �}�X�^�[�T�[�o�[�ɐڑ�������Ń��[�����쐬�ł��܂�
        //        //strixNetwork.CreateRoom(
        //        //    new RoomProperties
        //        //    {
        //        //        name = "testRoom",
        //        //        //password = "66e3f2nk",       // ���̃��[���̓p�X���[�h�ŕی삳��Ă��邽�߁A�p�X���[�h�̂Ȃ��N���C�A���g�͎Q���ł��܂���
        //        //        capacity = 10,                 // ���[�����ێ��ł���N���C�A���g�̍ő吔
        //        //        key1 = 1,                      // key1���g�p���Ă��̎����Ŏg�p����NPC�̓�Փx��\�����Ƃɂ��܂�

        //        //    },
        //        //    new RoomMemberProperties
        //        //    {
        //        //        name = "testPlayer",           // ���ꂪ�v���C���[�̖��O�ɂȂ�܂�

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

        #region �ڑ��ĂQ(����)
        //�T�[�o�[�ڑ�
        StrixNetwork.instance.playerName = PushBt.PlayerName;
        StrixNetwork.instance.ConnectMasterServer(host, port, OnConnectCallback, OnConnectFailedCallback);
        #endregion
    }

    // ICondition�c�������ʂ��i�荞�ނ��߂̂���  Order�c�������ʂ̕��я����w�肷�����  limit�c�����\�����邩  offset�c�����ڂ���\�����邩  RequestConfig�c�^�C���A�E�g�̒l null�̏ꍇ��30�b
    //private void SearchRoom(ICondition condition, Order order, int limit, int offset, RoomSearchEventHandler handler, FailureEventHandler failureHandler/*, RequestConfig config = null*/);


    private void OnConnectCallback(StrixNetworkConnectEventArgs args)
    {
        //Debug.Log("�ڑ�");
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
        //Debug.Log("���s");
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
            //Debug.Log("�ڑ�");
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
            //�ǉ�
            properties = new Dictionary<string, object>() {
            { "state", 0 }  // ������Ԃ� "Not Ready"
        }
        };
        Debug.Log(PushBt.PASS);
        strixNetwork.SearchRoom(
                            condition: ConditionBuilder.Builder().Field("name").EqualTo(PushBt.PASS).Build(),  //�uMy Game Room�v�Ƃ������O�̂��ׂĂ̕������������܂�
                            limit: 1,                                                                            // ���ʂ�10���̂ݎ擾���܂�
                            offset: 0,                                                                            // ���ʂ�擪����擾���܂�
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
                //�ǉ�
                properties = new Dictionary<string, object>() {
            { "state", 0 }  // ������Ԃ� "Not Ready"
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
                //�ǉ�
                properties = new Dictionary<string, object>() {
            { "state", 0 }  // ������Ԃ� "Not Ready"
                   
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
        // ���[�������o�[�̏�Ԃ�ύX���܂�: 0�́u�������v�A1�́u���������v
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

#region ���[�X

void Ready()
    {
        if (CheckAllRoomMembersState(1))
        {
            //�X�^�[�g�Ăяo��
        }
    }

    //�����o�`�F�b�N
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
