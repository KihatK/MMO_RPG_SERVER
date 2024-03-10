using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server {
    interface ITask {
        void Execute();
    }

    class BroadCastTask : ITask {
        GameRoom _room;
        ClientSession _session;
        string _chat;

        BroadCastTask(GameRoom room, ClientSession session, string chat) {
            _room = room;
            _session = session;
            _chat = chat;
        }

        public void Execute() {
            //_room.Broadcast(_session, _chat);
        }
    }

    class TaskQueue {
        Queue<ITask> _queue = new Queue<ITask>();
    }
}
