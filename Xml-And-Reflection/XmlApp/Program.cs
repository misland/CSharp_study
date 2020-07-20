using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;

namespace XmlApp
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryModel model = new QueryModel();
            List<Guid> lst=new List<Guid>();
            lst.Add(Guid.NewGuid());
            lst.Add(Guid.NewGuid());
            model.Mode = lst;
            Type source = model.GetType();
            PropertyInfo property = source.GetProperty("Mode");
            var modetype = property.PropertyType.Name;
            var name = property.Name;
            var testtype = typeof(List<Guid>).Name;
            Console.WriteLine(modetype);

            var value = (List<Guid>)property.GetValue(model, null);
            //Console.WriteLine(value);
            //save(model);
            QueryModel result = get();
            Console.ReadKey();
        }

        static void save(QueryModel model)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "/conditions.xml");
            XmlNode root = doc.SelectSingleNode("/querys");
            XmlNode node = root.SelectSingleNode("/querys/query[@user=\"zgh\" and @name=\"abc\"]");
            if (node==null) 
            {
                XmlElement query = doc.CreateElement("query");
                query.SetAttribute("user", "zgh");
                query.SetAttribute("name", "abc");
                root.AppendChild(query);
                PropertyInfo[] properties = model.GetType().GetProperties();
                foreach (PropertyInfo p in properties)
                {
                    string attName = p.Name;
                    XmlElement ele = doc.CreateElement(attName);
                    var type = p.PropertyType;
                    if (type == typeof(List<Guid>))
                    {
                        var val = (List<Guid>)p.GetValue(model, null);
                        if (val.Count > 0)
                        { 
                            ele.InnerText=string.Join(",",val.ToArray());
                        }
                    }
                    else if (type == typeof(List<int>))
                    {
                        var val = (List<int>)p.GetValue(model, null);
                        if (val.Count > 0)
                        {
                            ele.InnerText = string.Join(",", val.ToArray());
                        }
                    }
                    else if (type == typeof(int))
                    {
                        var val = (int)p.GetValue(model, null);
                        ele.InnerText = val.ToString();
                    }
                    else if (type == typeof(bool))
                    {
                        var val = (bool)p.GetValue(model, null);
                        ele.InnerText = val.ToString();
                    }
                    else if (type == typeof(DateTime))
                    {
                        var val = (DateTime)p.GetValue(model, null);
                        ele.InnerText = val.ToString();
                    }
                    else 
                    {
                        continue;
                    }
                    query.AppendChild(ele);
                }
            }
            doc.Save(AppDomain.CurrentDomain.BaseDirectory + "/conditions.xml");
        }

        static QueryModel get()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "/conditions.xml");
            XmlNode root = doc.SelectSingleNode("/querys");
            XmlNode node = root.SelectSingleNode("/querys/query[@user=\"zgh\" and @name=\"abc\"]");
            QueryModel model = new QueryModel();
            if (node != null)
            {
                XmlNodeList nodes = node.ChildNodes;
                PropertyInfo[] properties = model.GetType().GetProperties();
                foreach (PropertyInfo p in properties)
                {
                    string name = p.Name;
                    foreach (XmlNode n in nodes)
                    {
                        if (n.Name == name)
                        {
                            string text = n.InnerText;
                            if (!string.IsNullOrEmpty(text))
                            {
                                if (p.PropertyType == typeof(List<Guid>))
                                {
                                    string[] arr = text.Split(',');
                                    List<Guid> lst = new List<Guid>();
                                    Guid g=Guid.Empty;
                                    foreach (string s in arr)
                                    {
                                        if (Guid.TryParse(s, out g))
                                        {
                                            lst.Add(g);
                                        }
                                    }
                                    p.SetValue(model, lst, null);
                                }
                                else if (p.PropertyType == typeof(List<int>))
                                {
                                    string[] arr = text.Split(',');
                                    List<int> lst = new List<int>();
                                    int g = 0;
                                    foreach (string s in arr)
                                    {
                                        if (int.TryParse(s, out g))
                                        {
                                            lst.Add(g);
                                        }
                                    }
                                    p.SetValue(model, lst, null);
                                }
                                else if (p.PropertyType == typeof(int))
                                { 
                                    int g=0;
                                    if (int.TryParse(text, out g))
                                    {
                                        p.SetValue(model, g, null);
                                    }
                                }
                                else if (p.PropertyType == typeof(bool))
                                {
                                    bool g = false;
                                    if (bool.TryParse(text, out g))
                                    {
                                        p.SetValue(model, g, null);
                                    }
                                }
                                else if (p.PropertyType == typeof(DateTime))
                                {
                                    DateTime g = new DateTime();
                                    if (DateTime.TryParse(text, out g))
                                    {
                                        p.SetValue(model, g, null);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return model;
        }

    }
}
