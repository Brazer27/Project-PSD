using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Modules
{
    public class Response <T>
    {
        public Boolean Success;
        public String Message;
        public T Payload;
    }
}