using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using Services;

namespace SharpHTML
{
    public class SH_ActionGen
    {
        public static string _CreateAction(TM_Message P_TM_Message)
        {
            //return Convert.ToBase64String();
            //JsonSerializerSettings L_JsonSerializerSettings = new JsonSerializerSettings();
            //L_JsonSerializerSettings.Converters.Add(new StringEnumConverter(null, true));
            //L_JsonSerializerSettings.ContractResolver = new DefaultContractResolver();

            //byte[] byt = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(P_TM_Message, L_JsonSerializerSettings));
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(_ToJSON_String(P_TM_Message));
            return Convert.ToBase64String(byt);
        }

        public static string _ToJSON_String(object P_Object)
        {
            //return Convert.ToBase64String();
            JsonSerializerSettings L_JsonSerializerSettings = new JsonSerializerSettings();
            L_JsonSerializerSettings.Converters.Add(new StringEnumConverter(null, true));
            L_JsonSerializerSettings.ContractResolver = new DefaultContractResolver();

            return JsonConvert.SerializeObject(P_Object, L_JsonSerializerSettings);
        }
    }
}
