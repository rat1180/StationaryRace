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
    public int roomIDnum;  // ���[��ID�i���o�[
    public string host;
    public string applicationId;
    public Level logLevel = Level.INFO;

    public string roomName = "New Room";

    public int capacity = 4;

    #region �T�[�o�[�ڑ��i���͑��ňˑ��j
    void Awake()
    {
        var strixNetwork = StrixNetwork.instance;

        strixNetwork.applicationId = applicationId;

        // �܂��}�X�^�[�T�[�o�[�ɐڑ����܂�
        strixNetwork.ConnectMasterServer(
            host: host,
            connectEventHandler: _ => {
                Debug.Log("Connection established.");

                // �}�X�^�[�T�[�o�[�ɐڑ�������Ń��[�����쐬�ł��܂�
                strixNetwork.CreateRoom(
                    new RoomProperties
                    {
                        name = "testRoom",
                        //password = "66e3f2nk",       // ���̃��[���̓p�X���[�h�ŕی삳��Ă��邽�߁A�p�X���[�h�̂Ȃ��N���C�A���g�͎Q���ł��܂���
                        capacity = 10,                 // ���[�����ێ��ł���N���C�A���g�̍ő吔
                        key1 = 1,                      // key1���g�p���Ă��̎����Ŏg�p����NPC�̓�Փx��\�����Ƃɂ��܂�

                    },
                    new RoomMemberProperties
                    {
                        name = "testPlayer",           // ���ꂪ�v���C���[�̖��O�ɂȂ�܂�

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

        #region �悭�킩���
        // �v���C�x�[�g���[��
        CreateRoom();
    }

    // ICondition�c�������ʂ��i�荞�ނ��߂̂���  Order�c�������ʂ̕��я����w�肷�����  limit�c�����\�����邩  offset�c�����ڂ���\�����邩  RequestConfig�c�^�C���A�E�g�̒l null�̏ꍇ��30�b
    //private void SearchRoom(ICondition condition, Order order, int limit, int offset, RoomSearchEventHandler handler, FailureEventHandler failureHandler/*, RequestConfig config = null*/);
    #endregion

    private void OnConnectCallback(StrixNetworkConnectEventArgs args)
    {
        Debug.Log("�ڑ�");
    }

    private void OnConnectFailedCallback(StrixNetworkConnectFailedEventArgs args)
    {
        Debug.Log("���s");
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
            Debug.Log("�ڑ�");
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
