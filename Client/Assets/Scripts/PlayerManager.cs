using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    MyPlayer _myPlayer;
    Dictionary<int, Player> _players = new Dictionary<int, Player>();

    public static PlayerManager Instance { get; } = new PlayerManager();

    public void Add(S_PlayerList packet) {
        Object obj = Resources.Load("Player");

        foreach (S_PlayerList.Player p in packet.players) {
            GameObject go = Object.Instantiate(obj) as GameObject;

            if (p.isSelf) {
                MyPlayer myPlayer = go.AddComponent<MyPlayer>();
                myPlayer.playerId = p.playerId;
                myPlayer.transform.position = new Vector3(p.posX, p.posY, p.posZ);
                _myPlayer = myPlayer;
            }
            else {
                Player player = go.AddComponent<Player>();
                player.playerId = p.playerId;
                player.transform.position = new Vector3(p.posX, p.posY, p.posZ);
                _players.Add(p.playerId, player);
            }
        }
    }

    public void Move(S_BroadcastMove packet) {
        if (_myPlayer.playerId == packet.playerId) {
            _myPlayer.transform.position = new Vector3(packet.posX, packet.posY, packet.posZ);
        }
        else {
            Player player = null;
            if (_players.TryGetValue(packet.playerId, out player)) {
                player.transform.position = new Vector3(packet.posX, packet.posY, packet.posZ);
            }
        }
    }

    public void EnterGame(S_BroadcastEnterGame packet) {
        if (packet.playerId == _myPlayer.playerId) {
            return;
        }
        Object obj = Resources.Load("Player");
        GameObject go = Object.Instantiate(obj) as GameObject;

        Player player = go.AddComponent<Player>();
        player.transform.position = new Vector3(packet.posX, packet.posY, packet.posZ);
        _players.Add(packet.playerId, player);
    }

    public void LeaveGame(S_BroadcastLeaveGame packet) {
        if (_myPlayer.playerId == packet.playerId) {
            GameObject.Destroy(_myPlayer.gameObject);
            _myPlayer = null;
        }
        else {
            Player player = null;
            if (_players.TryGetValue(packet.playerId, out player)) {
                GameObject.Destroy(player.gameObject);
                _players.Remove(packet.playerId);
            }
        }
    }
}
