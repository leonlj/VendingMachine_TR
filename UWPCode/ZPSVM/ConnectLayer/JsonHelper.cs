using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConnectLayer
{
    public class JsonHelper
    {
        /// <summary>
        /// 将JSON字符串反序列化成数据对象
        /// </summary>
        /// <typeparam name="T">数据对象类型</typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns>返回数据对象</returns>
        public static T Deserialize<T>(string json)
        {
            var _Bytes = Encoding.Unicode.GetBytes(json);
            using (MemoryStream _Stream = new MemoryStream(_Bytes))
            {
                var _Serializer = new DataContractJsonSerializer(typeof(T));
                return (T)_Serializer.ReadObject(_Stream);
            }
        }

        /// <summary>
        /// 将object序列化成JSON字符串 
        /// </summary>
        /// <param name="instance">被序列化对象</param>
        /// <returns>返回json字符串</returns>
        public static string Serialize(object instance)
        {
            using (MemoryStream _Stream = new MemoryStream())
            {
                var _Serializer = new DataContractJsonSerializer(instance.GetType());
                _Serializer.WriteObject(_Stream, instance);
                _Stream.Position = 0;
                using (StreamReader _Reader = new StreamReader(_Stream))
                { return _Reader.ReadToEnd(); }
            }
        }
    }
}
