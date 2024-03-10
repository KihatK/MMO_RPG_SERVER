﻿using ServerCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DummyClient {
    class ServerSession : PacketSession {
        public override void OnConnected(EndPoint endPoint) {
            Console.WriteLine($"OnConnected : {endPoint}");

            //C_PlayerInfoReq packet = new C_PlayerInfoReq() { playerId = 1001, name="ABCD" };
            //packet.skills.Add(new C_PlayerInfoReq.Skill() { id = 101, level = 1, duration = 3.0f });
            //packet.skills.Add(new C_PlayerInfoReq.Skill() { id = 201, level = 2, duration = 4.0f });
            //packet.skills.Add(new C_PlayerInfoReq.Skill() { id = 301, level = 3, duration = 5.0f });
            //packet.skills.Add(new C_PlayerInfoReq.Skill() { id = 401, level = 4, duration = 6.0f });

            //ArraySegment<byte> s = packet.Write();

            //if (s != null) {
            //    Send(s);
            //}
        }

        public override void OnDisconnected(EndPoint endPoint) {
            Console.WriteLine($"OnDisconnected : {endPoint}");
        }

        public override void OnRecvPacket(ArraySegment<byte> buffer) {
            //string recvData = Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count);
            //Console.WriteLine($"[From Server] {recvData}");
            //return buffer.Count;

            PacketManager.Instance.OnRecvPacket(this, buffer);
        }

        public override void OnSend(int numOfBytes) {
            //Console.WriteLine($"Transferred bytes: {numOfBytes}");
        }
    }
}