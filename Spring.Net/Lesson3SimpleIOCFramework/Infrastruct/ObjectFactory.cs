using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson3SimpleIOCFramework.Infrastruct
{
    public class ObjectFactory
    {
        private Dictionary<string, object> objectFactory = new Dictionary<string, object>();

        public ObjectFactory(string fileName)
        {
            InstanceObjects(fileName);
        }

        /// <summary>
        /// 使用Linq to xml方法从xml文件中查找所有的object，然后用反射的方法创建类型实例
        /// </summary>
        /// <param name="fileNmae"></param>
        private void InstanceObjects(string fileNmae)
        {
            XElement root = XElement.Load(fileNmae);
            var objects = from obj in root.Elements("object") select obj;
            objectFactory = objects.ToDictionary(
                k => k.Attribute("id").Value,
                v =>
                {
                    string typeName = v.Attribute("type").Value;
                    Type t = Type.GetType(typeName);
                    return Activator.CreateInstance(t);
                }
                );
        }

        public object GetObject(string id)
        {
            if (objectFactory.ContainsKey(id))
            {
                return objectFactory[id];
            }
            return null;
        }
    }
}
