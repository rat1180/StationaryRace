using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using SoftGear.Strix.Client.Core.Auth.Message;
using SoftGear.Strix.Client.Core.Error;
using SoftGear.Strix.Client.Core.Model.Manager.Filter;
using SoftGear.Strix.Client.Core;
using SoftGear.Strix.Unity.Runtime;
using SoftGear.Strix.Net.Logging;
using SoftGear.Strix.Unity.Runtime.Event;

public class WaitMacth : MonoBehaviour
{
    public GameObject GMSystem;
    public bool RoomFlg = false;
    public GameObject Button;
    public GameObject CountTime;
    public GameObject RdText;
    public int Rdmenber;
    public bool WaitFlg = true;

    // Start is called before the first frame update
    void Start()
    {
        Button = transform.Find("Canvas/RdButton").gameObject;
        Button.SetActive(false);
        RdText = transform.Find("Canvas/Rdtext").gameObject;
        RdText.SetActive(false);
        CountTime = GameObject.Find("CountTime").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (RoomFlg)
        {
            memberWait();
        }

        if (Input.GetButton("Ready"))
        {
            ClickBottun();
        }
    }

    void memberWait()
    {
        Rdmenber = CheckAllRoomMembersState(1);
        RdmenberText();

        if ((Rdmenber == PushBt.GAMEMODE) && WaitFlg)
        {
            CountTime.GetComponent<CountTime>().CountStart();
            GMSystem.GetComponent<GMSystem>().CarSpawn();
            this.gameObject.SetActive(false);
            WaitFlg = false;
            GameObject SystemINF = GameObject.Find("SystemINF(Clone)");
            if(SystemINF != null)
            {
                if (SystemINF.GetComponent<StrixReplicator>().isLocal)
                {
                    var strixNetwork = StrixNetwork.instance;

                    strixNetwork.SetRoom(
                            roomId: strixNetwork.roomSession.room.GetPrimaryKey(),   // The ID of the current room
                            roomProperties: new RoomProperties
                            {
                                isJoinable = false
                            },
                            handler: setRoomResult => Debug.Log("RoomLock succeeded"),
                            failureHandler: setRoomError => Debug.LogError("RoomLock failed")
                        );
                }
            }
        }

    }

    public void ClickBottun()
    {
        // ルームメンバーの状態を変更します: 0は「準備中」、1は「準備完了」
        StrixNetwork.instance.SetRoomMember(
            StrixNetwork.instance.selfRoomMember.GetPrimaryKey(),
            new Dictionary<string, object>() {
        { "properties", new Dictionary<string, object>() {
            { "state", 1 }
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
    }

    public static int CheckAllRoomMembersState(int desiredState)
    {
        int Rdmenber = 0;
        foreach (var roomMember in StrixNetwork.instance.roomMembers)
        {
            if (!roomMember.Value.GetProperties().TryGetValue("state",
                out object value))
            {
                continue;
            }

            if ((int)value != desiredState)
            {
                continue;
            }
            Rdmenber++;
        }

        Debug.Log("CheckAllRoomMembersState OK");
        return Rdmenber;
    }

    //他のユーザー読み込みに1秒待つ
    public void WaitRoomIn()
    {
        Invoke("RoomIn", 1f);
    }

    

    public void RoomIn()
    {
        RoomFlg = true;
        Button.SetActive(true);
        RdText.SetActive(true);
        Rdmenber = 0;
        Debug.Log("In");
        GMSystem.GetComponent<GMSystem>().InitSet();
    }

    public void RdmenberText()
    {
        RdText.GetComponent<Text>().text = Rdmenber + "個の文房具が待機中！";
    }

}