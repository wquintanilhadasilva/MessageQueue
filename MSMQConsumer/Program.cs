using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MSMQShared;

namespace MSMQConsumer
{
    class Program
    {
        static MessageQueue local = FabricaMQ.GetConsumer(TIPO_SERVER.LOCAL);
        static MessageQueue remoto = FabricaMQ.GetConsumer(TIPO_SERVER.REMOTO);
        static void Main(string[] args)
        {
            while (true)
            {                
                try
                {
                    Console.WriteLine("Mensagem LOCAL: {0}", local.Receive().Body);
                    //Console.WriteLine("----------------------------------");
                    //Console.WriteLine("Mensagem REMOTA: {0}", remoto.Receive().Body);
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.StackTrace);
                }
                finally { }
            }
        }
    }
}
