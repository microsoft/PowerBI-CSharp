// Copyright Microsoft 2015

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using PBIGettingStarted;

namespace PowerBIExtensionMethods
{
    //JSONBuilder used for PowerBI
    public static class JSONBuilder 
    {
        public static string ToJson(this object obj, JavaScriptSerializer serializer)
        {
            StringBuilder jsonBuilder = new StringBuilder();

            jsonBuilder.Append(string.Format("{0}\"rows\":", "{"));
            jsonBuilder.Append(serializer.Serialize(obj));
            jsonBuilder.Append(string.Format("{0}", "}"));

            return jsonBuilder.ToString();
        }

        public static string ToDatasetJson(this object obj, string datasetName)
        {
            StringBuilder jsonSchemaBuilder = new StringBuilder();
            jsonSchemaBuilder.Append(string.Format("{0}\"name\": \"{1}\",\"tables\": [", "{", datasetName));

            jsonSchemaBuilder.Append(obj.ToTableSchema(obj.GetType().Name));

            jsonSchemaBuilder.Append("]}");

            return jsonSchemaBuilder.ToString();

        }

        public static string ToTableSchema(this object obj, string tableName)
        {        
            StringBuilder jsonSchemaBuilder = new StringBuilder();
            string typeName = string.Empty;

            jsonSchemaBuilder.Append(String.Format("{0}\"name\": \"{1}\", ", "{", tableName));
            jsonSchemaBuilder.Append("\"columns\": [");

            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach(PropertyInfo p in properties)
            {
                string sPropertyTypeName = p.PropertyType.Name;
                if (sPropertyTypeName.StartsWith("Nullable") && p.PropertyType.GenericTypeArguments != null && p.PropertyType.GenericTypeArguments.Length == 1)
                    sPropertyTypeName = p.PropertyType.GenericTypeArguments[0].Name;
                switch (sPropertyTypeName)
                {                   
                    case "Int32": case "Int64":
                        typeName = "Int64";
                        break;
                    case "Double":
                        typeName = "Double";
                        break;
                    case "Boolean":
                        typeName = "bool";
                        break;
                    case "DateTime":
                        typeName = "DateTime";
                        break;
                    case "String":
                        typeName = "string";
                        break;
                    default:
                        typeName = null;
                        break;
                }

                if (typeName == null)
                    throw new Exception("type not supported");

                jsonSchemaBuilder.Append(string.Format("{0} \"name\": \"{1}\", \"dataType\": \"{2}\"{3},", "{", p.Name, typeName, "}"));
            }

            jsonSchemaBuilder.Remove(jsonSchemaBuilder.ToString().Length - 1, 1);

            jsonSchemaBuilder.Append("]}");

            return jsonSchemaBuilder.ToString();
        }

        public static dataset GetDataset(this dataset[] datasets, string datasetName)
        {
            var q = (from d in datasets where d.Name == datasetName select d).FirstOrDefault();

            return q;       
        }

        public static group GetGroup(this group[] groups, string groupName)
        {
            var q = (from d in groups where d.Name == groupName select d).FirstOrDefault();

            return q;       
        }
    }

    public class JavaScriptConverter<T> : JavaScriptConverter where T : new()
    {
        private const string _dateFormat = "MM/dd/yyyy";

        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new[] { typeof(T) };
            }
        }

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            T p = new T();

            var props = typeof(T).GetProperties();

            foreach (string key in dictionary.Keys)
            {
                var prop = props.Where(t => t.Name == key).FirstOrDefault();
                if (prop != null)
                {
                    if (prop.PropertyType == typeof(DateTime))
                    {
                        prop.SetValue(p, DateTime.ParseExact(dictionary[key] as string, _dateFormat, DateTimeFormatInfo.InvariantInfo), null);
                    }
                    else
                    {
                        prop.SetValue(p, dictionary[key], null);
                    }
                }
            }

            return p;
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            T p = (T)obj;
            IDictionary<string, object> serialized = new Dictionary<string, object>();

            foreach (PropertyInfo pi in typeof(T).GetProperties())
            {
                if (pi.PropertyType == typeof(DateTime))
                {
                    serialized[pi.Name] = ((DateTime)pi.GetValue(p, null)).ToString(_dateFormat);
                }
                else
                {
                    serialized[pi.Name] = pi.GetValue(p, null);
                }

            }


            StringBuilder powerBIJson = new StringBuilder();


            return serialized;
        }

        public static JavaScriptSerializer GetSerializer()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new JavaScriptConverter<T>() });

            return serializer;
        }
    }
}
