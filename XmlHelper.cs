using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace VideoCombine
{
    public class XmlHelper
    {
        private static readonly string XmlPath;

        static XmlHelper()
        {
            XmlPath = Application.StartupPath + @"\..\XML\";
        }

        /// <summary>
        /// 修改LMSettings指定节点数据
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool UpdateNodestring(string node,string value)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(XmlPath + @"setting.xml");
                XmlNode xn = xmlDoc.SelectSingleNode(node);
                xn.InnerText = value;
                xmlDoc.Save(XmlPath + @"setting.xml");
            }
            catch (Exception ex)
            {
                CalAlgorithm.AlgorithmsInLoadManager.WriteLog("UpdateNode", ex);
            }
            return true;
        }
        /// <summary>
        /// 修改LMSettings指定节点数据
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool UpdateNodeDouble(string node, double value)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(XmlPath + @"setting.xml");
                XmlNode xn = xmlDoc.SelectSingleNode(node);
                xn.InnerText = value.ToString();
            }
            catch (Exception ex)
            {
                CalAlgorithm.AlgorithmsInLoadManager.WriteLog("UpdateNode", ex);
            }
            return true;
        }
        /// <summary>
        /// 读取指定节点的数据
        /// </summary>
        /// <param name="node">节点</param>
        public static string ReadNodeDataOfLMSettings(string node)
        {
            string value = "";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(XmlPath + @"setting.xml");
                XmlNode xn = xmlDoc.SelectSingleNode(node);
                value = xn.InnerText;
            }
            catch (Exception ex)
            {
                CalAlgorithm.AlgorithmsInLoadManager.WriteLog("ReadNodeString", ex);
            }
            return value;
        }

    }
}
