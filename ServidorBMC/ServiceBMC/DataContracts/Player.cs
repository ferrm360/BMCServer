using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBMC.DataContracts
{
    [DataContract]
    internal class Player
    {
        [DataMember]
        int playerId { get; set; }
        [DataMember]
        String username { get; set; }
        [DataMember]
        String email { get; set; }
        [DataMember]
        String password { get; set; }
    }


}
