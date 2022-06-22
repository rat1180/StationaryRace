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

public class WaitMacth : MonoBehaviour
{
    public GameObject GMSystem;
    public bool RoomFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RoomFlg)
        {
            memberWait();
        }
    }

    void memberWait()
    {
        if (CheckAllRoomMembersState(1))
        {
            //GMSystem.GetComponent<GMSystem>().StartRace();
            this.gameObject.SetActive(false);
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

    public void RoomIn()
    {
        RoomFlg = true;
        Debug.Log("In");
    }

}