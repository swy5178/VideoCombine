using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoCombine
{
    public class FileHelper
    {
        /// <summary>
        /// 获取与程序运行路径同级路径
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        public static string GetFileRealPath(string pathName)
        {
            string videoPath = string.Empty;
            try
            {
                string path = Application.StartupPath.Trim();
                videoPath = path + @"\..\" + pathName;
            }
            catch (Exception e)
            {
                CalAlgorithm.AlgorithmsInLoadManager.WriteLog("GetFileRealPath", e);
            }
            return videoPath;
        }
        /// <summary>
        /// 获取视频播放路径，必须绝对路径
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        public static string GetFileAbsolutePath(string pathName)
        {
            string videoPath = string.Empty;
            try
            {
                string path = Application.StartupPath.Trim();
                if (path.Contains("Debug")) videoPath = path.Replace("Debug", pathName);
                else if (path.Contains("Release")) videoPath = path.Replace("Release", pathName);
                //else if (path.Contains("Bin")) videoPath = path.Replace("Bin", pathName);
                //else if (path.Contains("bin")) videoPath = path.Replace("bin", pathName);
            }
            catch (Exception e)
            {
                CalAlgorithm.AlgorithmsInLoadManager.WriteLog("GetFilePlayPath", e);
                Console.WriteLine(e.ToString());
            }
            return videoPath;
        }
        /// <summary>根据FileInfo[]获取无扩展名的文件名,完整路径字典</summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFileNamesDic(FileInfo[] files)
        {
            Dictionary<string, string> fileNamesDic = new Dictionary<string, string>();
            string[] fileNames = new string[files.Length];
            for (int i = 0; i < fileNames.Length; i++)
            {
                string fileName = GetFileName(files[i]);
                if (!fileNamesDic.ContainsKey(fileName))
                {
                    fileNamesDic.Add(fileName, files[i].FullName);
                }
                else
                {
                    if(files[i].Extension.Equals(".mp4"))
                        fileNamesDic[fileName] = files[i].FullName;
                }
                
            }
            return fileNamesDic;
        }
        /// <summary>
        /// 根据FileInfo[]获取带有扩展名的文件名,完整路径字典
        /// 解决重名但扩展名不同的文件无法添加进字典的问题
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFileNamesWithExDic(FileInfo[] files)
        {
            Dictionary<string, string> fileNamesDic = new Dictionary<string, string>();
            string[] fileNames = new string[files.Length];
            for (int i = 0; i < fileNames.Length; i++)
            {
                string fileName = files[i].Name;
                if (!fileNamesDic.ContainsKey(fileName))
                {
                    fileNamesDic.Add(fileName, files[i].FullName);
                }
            }
            return fileNamesDic;
        }
        /// <summary>
        /// 根据FileInfo获取无扩展名的文件名
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        private static string GetFileName(FileInfo fileInfo)
        {
            string file = fileInfo.Name;
            string aFirstName = file.Substring(file.LastIndexOf("\\") + 1, (file.LastIndexOf(".") - file.LastIndexOf("\\") - 1)); //文件名
            return aFirstName;
        }
        /// <summary>
        /// 获取复制到目标路径后的文件名称list
        /// </summary>
        /// <param name="filesName"></param>
        /// <returns></returns>
        public static List<string> GetCopyToFilesList(string[] filesName)
        {
            string path = string.Empty;
            string sourceVideoPath = GetFileAbsolutePath("SourceVideos");
            List<string> copyToFilesList = new List<string>();
            for (int i = 0; i < filesName.Length; i++)
            {
                path = Path.Combine(sourceVideoPath, filesName[i].Replace(" ",""));//文件名中的空格要去掉
                copyToFilesList.Add(path);
            }
            return copyToFilesList;
        }
        /// <summary>
        /// 判断文件路径是否重复
        /// </summary>
        /// <param name="filesNameList"></param>
        /// <returns></returns>
        public static bool IsExistSameNameFiles(List<string> filesNameList)
        {
            foreach (var fileName in filesNameList)
            {
                if (File.Exists(fileName))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName.Trim()))
            {
                MessageBox.Show(@"输入的场景名称为空！");
                return false;
            }
            if (fileName.Trim().Length > 255)
            {
                MessageBox.Show(@"输入的场景名称超出长度限制！");
                return false;
            }
            var opResult = Regex.IsMatch(fileName.Trim(), @"(?!((^(con)$)|^(con)\\..*|(^(prn)$)|^(prn)\\..*|(^(aux)$)|^(aux)\\..*|(^(nul)$)|^(nul)\\..*|(^(com)[1-9]$)|^(com)[1-9]\\..*|(^(lpt)[1-9]$)|^(lpt)[1-9]\\..*)|^\\s+|.*\\s$)(^[^\\\\\\/\\:\\<\\>\\*\\?\\\\\\""\\\\|]{1,255}$)");
            if (!opResult)
            {
                MessageBox.Show(@"文件名包含特殊符或系统关键字！");
                return false;
            }
            return true;
        }
    }
}
