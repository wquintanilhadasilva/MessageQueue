using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQShared
{
    public class FabricaMQ
    {
        private const String NOME_FILA = @".\private$\fila_wedson";
        //private const String NOME_FILA_REMOTO = @"FormatName:DIRECT=OS:DRWWEDSONSILV.rwit.com.br\\private$\\fila_wedson";
        //private const String NOME_FILA_REMOTO = @"net.msmq://DRWWEDSONSILV.rwit.com.br//private$//fila_wedson";
        private const String NOME_FILA_REMOTO = @".\private$\fila_wedson";

        public static MessageQueue GetSender(TIPO_SERVER server)
        {
            String nome = server == TIPO_SERVER.LOCAL ? NOME_FILA : NOME_FILA_REMOTO;
            MessageQueue service;
            if (MessageQueue.Exists(nome))
            {
                service = new MessageQueue(nome);
            }else
            {
                service = MessageQueue.Create(nome);
            }
            return service;
        }

        public static MessageQueue GetConsumer(TIPO_SERVER server)
        {
            String nome = server == TIPO_SERVER.LOCAL ? NOME_FILA : NOME_FILA_REMOTO;
            var service = new MessageQueue(nome);
            service.Formatter = new XmlMessageFormatter(new[] { typeof(String) });
            return service;
        }

    }

    public enum TIPO_SERVER
    {
        LOCAL, REMOTO
    }
}
