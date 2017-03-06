using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DarkRift;

namespace RoomPluginAPI
{
    
    public class Client
    {
        public const byte RoomTag = 147;

        public const byte ROOM_CREATE = 0;
        public const byte ROOM_JOIN = 1;
        public const byte ROOM_LEAVE = 2;
        public const byte ROOM_DELETE = 3;

        /// <summary>
        /// Creates room with random generated name, 
        /// Default Max Players is 10
        /// </summary>
        public void roomCreate()
        {
            Guid g = Guid.NewGuid();
            string name = Convert.ToBase64String(g.ToByteArray());
            name = name.Replace("=", ""); //Clearing all the characters(useless ones)
            name = name.Replace("+", "");
            name = name.Replace("/", "");

            DarkRiftWriter writer = SerializeNameMax(name, 10); //Returns a writer object
            DarkRiftAPI.SendMessageToServer(RoomTag, ROOM_CREATE, writer); //Send to server to create
        }
        /// <summary>
        /// Create a room(Sends Message to server with name), 
        /// Default Max Players is 10
        /// </summary>
        /// <param name="name"></param>
        public void roomCreate(String name)
        {
            DarkRiftWriter writer = SerializeNameMax(name, 10); //Returns a writer object
            DarkRiftAPI.SendMessageToServer(RoomTag, ROOM_CREATE, writer); //Send to server to create
        }

        /// <summary>
        /// Create a room(Sends Message to server with name and max players)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="max"></param>
        public void roomCreate(String name, int max)
        {
            DarkRiftWriter writer = SerializeNameMax(name, max); //Returns a writer object
            DarkRiftAPI.SendMessageToServer(RoomTag, ROOM_CREATE, writer); //Send to server to create
        }

        /// <summary>
        /// Serializes name and max players to send to server
        /// </summary>
        /// <param name="name"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private DarkRiftWriter SerializeNameMax(String name, int max)
        {
            using(DarkRiftWriter writer = new DarkRiftWriter())
            {
                writer.Write(name);
                writer.Write(max);

                return writer;
            }
        }






    }
}
