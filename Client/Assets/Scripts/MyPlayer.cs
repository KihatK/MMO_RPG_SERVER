using ServerCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : Player
{
    NetworkManager _network;

    void Start()
    {
        StartCoroutine("CoSendPacket");
        _network = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
    }

    void Update()
    {
        
    }

    IEnumerator CoSendPacket() {
        while (true) {
            yield return new WaitForSeconds(0.25f);

            C_Move chatPacket = new C_Move();
            chatPacket.posX = UnityEngine.Random.Range(-50, 50);
            chatPacket.posY = 0;
            chatPacket.posZ = UnityEngine.Random.Range(-50, 50);

            _network.Send(chatPacket.Write());
        }
    }
}
