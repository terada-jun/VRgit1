using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class cycle : MonoBehaviour
{
    private Vector3 Tracker1Posision;
    private SteamVR_Action_Pose tracker1 = SteamVR_Actions.default_Pose;
    public Transform bodyCollider;
    public SteamVR_Action_Vector2 walkAction;
    [Range(0, 100)] public float walkSpeed = 0;
    public float TrackerPosition0 = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        pos.x -= Player.instance.hmdTransform.localPosition.x;
        pos.z -= Player.instance.hmdTransform.localPosition.z;
        pos.y = transform.position.y;
        transform.position = pos;

    }

    // Update is called once per frame
    void Update()
    {
        Tracker1Posision = tracker1.GetLocalPosition(SteamVR_Input_Sources.RightFoot);
        if (walkSpeed > 0)
        {
            walkSpeed = walkSpeed + Mathf.Abs(Tracker1Posision.y - TrackerPosition0) * 10 - (float)0.05;
        }
        else { walkSpeed = walkSpeed + Mathf.Abs(Tracker1Posision.y - TrackerPosition0) * 10; }
        TrackerPosition0=Tracker1Posision.y;
        Vector3 player_pos = transform.position;
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(0,0,1));
        player_pos.x += walkSpeed * Time.deltaTime * direction.x;
        player_pos.z += walkSpeed * Time.deltaTime * direction.z;
        transform.position = player_pos;
        Debug.Log("walk"+walkSpeed);
    }
}
