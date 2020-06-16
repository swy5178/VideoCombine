using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;

namespace VideoCombine
{
    public class VideoHelper
    {
        /// <summary>
        /// 创建视频缩略图
        /// </summary>
        /// <param name="videoPath"></param>
        /// <param name="thumbnailPath"></param>
        public static bool CreateThumbnail(string videoPath, string thumbnailPath)
        {
            try
            {
                var inputFile = new MediaFile { Filename = videoPath };
                var outputFile = new MediaFile { Filename = thumbnailPath };
                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);
                    double duration = inputFile.Metadata.Duration.TotalSeconds <= 30
                        ? Math.Round(inputFile.Metadata.Duration.TotalSeconds / 2)
                        : 15;
                    // Saves the frame located on the 15th second of the video.
                    var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(duration) };
                    engine.GetThumbnail(inputFile, outputFile, options);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>获取场景名称，图片字典</summary>
        public static Dictionary<string, Image> GetSceneNameImageDic()
        {
            bool isExistThumbnail = true;
            string itemPath = FileHelper.GetFileAbsolutePath("Resources\\") + "item.png";
            Dictionary<string, Image> videoNameImageDic = new Dictionary<string, Image>();
            string videoPath = FileHelper.GetFileAbsolutePath("CombVideos");
            DirectoryInfo root = new DirectoryInfo(videoPath);
            FileInfo[] files = root.GetFiles();
            string thumbnailPath = FileHelper.GetFileAbsolutePath("VideoThumbnails\\");
            Dictionary<string, string> fileNamesDic = FileHelper.GetFileNamesDic(files);
            foreach (var pair in fileNamesDic)
            {
                string imagePath = thumbnailPath + pair.Key + ".jpg";
                if (!File.Exists(imagePath))
                    isExistThumbnail = CreateThumbnail(pair.Value, imagePath);
                Image image = isExistThumbnail? Image.FromFile(imagePath) : Image.FromFile(itemPath);
                Bitmap bmp = new Bitmap(image);
                image.Dispose();
                videoNameImageDic.Add(pair.Key, bmp);
            }
            return videoNameImageDic;
        }
        /// <summary>从SourceVideos获取本地视频源数据</summary>
        /// <returns></returns>
        public static List<VideoInfo> GetSourceVideosData()
        {
            List<VideoInfo> videoInfoList = new List<VideoInfo>();
            string videoPath = FileHelper.GetFileAbsolutePath("SourceVideos");
            DirectoryInfo root = new DirectoryInfo(videoPath);
            FileInfo[] files = root.GetFiles();
            Dictionary<string, string> fileNamesDic = FileHelper.GetFileNamesWithExDic(files);
            foreach (KeyValuePair<string, string> pair in fileNamesDic)
            {
                VideoInfo videoInfo = GetVideoInfo(pair.Key, pair.Value);
                videoInfoList.Add(videoInfo);
            }
            return videoInfoList;
        }
        public static List<VideoInfo> GetSourceVideosList()
        {
            List<VideoInfo> videoInfoList = new List<VideoInfo>();
            string filePath = FileHelper.GetFileAbsolutePath("SourceVideos");
            string[] videoFiles = Directory.GetFiles(filePath);//读取指定目录下的视频
            string listPath = FileHelper.GetFileAbsolutePath("VideoLists\\") + "所有视频.txt";
            //TXT的文件名更新，排序用的
            if (!File.Exists(listPath)) File.Create(listPath).Dispose();
            List<string> videoTxtList = File.ReadAllLines(listPath).ToList();
            List<string> videoTxtTempList = File.ReadAllLines(listPath).ToList();
            if (videoFiles.Length > videoTxtList.Count) //添加视频,并集
            {
                videoTxtList = videoTxtTempList.Union(videoFiles).ToList();
            }
            else if (videoFiles.Length < videoTxtList.Count)//删除视频,交集
            {
                videoTxtList = videoTxtTempList.Intersect(videoFiles).ToList();
            }
            File.WriteAllLines(listPath, videoTxtList, Encoding.UTF8);
            foreach (string videoText in videoTxtList)
            {
                string videoName = Path.GetFileNameWithoutExtension(videoText);
                VideoInfo videoInfo = GetVideoInfo(videoName, videoText);
                videoInfoList.Add(videoInfo);
            }
            return videoInfoList;
        }
        /// <summary>
        /// 获取当前场景下的视频资源
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<VideoInfo> GetCurrentSceneVideosData(string item)
        {
            List<VideoInfo> videoInfoList = new List<VideoInfo>();
            string listPath = FileHelper.GetFileAbsolutePath("VideoLists\\") + item + ".txt";
            if (File.Exists(listPath))
            {
                string[] videoList = File.ReadAllLines(listPath);
                foreach (string videoText in videoList)
                {
                    string videoPath = videoText.Split('\'')[1];
                    string videoName = Path.GetFileNameWithoutExtension(videoPath);
                    VideoInfo videoInfo = GetVideoInfo(videoName, videoPath);
                    videoInfoList.Add(videoInfo);
                }
            }
            return videoInfoList;
        }
        /// <summary>
        /// 获取视频详细信息
        /// </summary>
        /// <param name="videoName"></param>
        /// <param name="pathName"></param>
        /// <returns></returns>
        private static VideoInfo GetVideoInfo(string videoName, string pathName)
        {
            bool isExistThumbnail = true;
            string itemPath = FileHelper.GetFileAbsolutePath("Resources\\") + "item.png";
            string newVideoName = videoName;
            if (!File.Exists(pathName))
                return new VideoInfo();
            string extension = Path.GetExtension(pathName);
            if (videoName.Contains(extension))
                newVideoName = videoName.Replace(extension, "");
            var inputFile = new MediaFile { Filename = pathName };
            string imagePath = FileHelper.GetFileAbsolutePath("VideoThumbnails\\") + newVideoName + ".jpg";
            if (!File.Exists(imagePath))
                isExistThumbnail = CreateThumbnail(pathName, imagePath);
            Image image = isExistThumbnail ? Image.FromFile(imagePath) : Image.FromFile(itemPath);
            Bitmap bmp = new Bitmap(image);
            image.Dispose();
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }
            VideoInfo videoInfo = new VideoInfo
            {
                VideoPath = pathName,
                VideoName = newVideoName,
                VideoImage = bmp,
                VideoFormat = extension,
                VideoDuration = inputFile.Metadata.Duration.ToString(@"hh\:mm\:ss"),
                VideoResolution = inputFile.Metadata.VideoData.FrameSize
            };
            return videoInfo;
        }
        /// <summary>
        /// 删除场景
        /// </summary>
        /// <param name="sceneName"></param>
        public static void DeleteScene(string sceneName)
        {
            if (String.IsNullOrEmpty(sceneName)) return;
            string videoPath = FileHelper.GetFileAbsolutePath("CombVideos\\") + sceneName + ".mp4";
            string thumbnailPath = FileHelper.GetFileAbsolutePath("VideoThumbnails\\") + sceneName + ".jpg";
            string videoListPath = FileHelper.GetFileAbsolutePath("VideoLists\\") + sceneName + ".txt";

            ShellFileOperation.Delete(videoPath);
            ShellFileOperation.Delete(videoListPath);
            ShellFileOperation.Delete(thumbnailPath);
        }
        /// <summary>调用FFmpeg</summary>
        /// <param name="ffmpegPath"></param>
        /// <param name="parameters"></param>
        public static bool RunFFMpeg(string ffmpegPath, string parameters)
        {
            try
            {
                var p = new Process();
                p.StartInfo.FileName = ffmpegPath;
                p.StartInfo.Arguments = parameters;
                //是否使用操作系统shell启动
                p.StartInfo.UseShellExecute = false;
                //不显示程序窗口
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.WaitForExit();
                //p.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取格式转换命令
        /// </summary>
        /// <param name="oldVideoName"></param>
        /// <param name="newVideoName"></param>
        /// <returns></returns>
        public static string ConvertToMp4Cmd(string oldVideoName, string newVideoName)
        {
            string cmdConvert = String.Format(" -i {0} -threads 10 -preset ultrafast {1} -y", oldVideoName, newVideoName);
            return cmdConvert;
        }

        public static string Mp4ToTsCmd(string mp4Path, string tsPath)
        {
            string cmdConvert = string.Format(" -i {0} -c copy -bsf:v h264_mp4toannexb -f mpegts {1}" + " -y ", mp4Path,
                tsPath);
            return cmdConvert;
        }
        /// <summary>
        /// 获取合并命令
        /// </summary>
        /// <param name="sceneVideoInfoList"></param>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        public static string GetCombineCmd(List<VideoInfo> sceneVideoInfoList, string sceneName)
        {
            string combineVideoName = FileHelper.GetFileAbsolutePath("CombVideos\\") + sceneName + ".mp4";
            string path = FileHelper.GetFileAbsolutePath("SourceVideos\\");

            //拼接指令字符串:合并视频
            StringBuilder cmdCombine = new StringBuilder();
            cmdCombine.Append(" -i \"concat:");
            for (int i = 0; i < sceneVideoInfoList.Count; i++)
            {
                cmdCombine.Append(path + sceneVideoInfoList[i].VideoName + ".ts");
                cmdCombine.Append("|");
            }
            cmdCombine.Remove(cmdCombine.Length - 1, 1);
            cmdCombine.Append("\" -c copy -bsf:a aac_adtstoasc -movflags +faststart ");
            cmdCombine.Append(combineVideoName);
            cmdCombine.Append(" -y ");
            return cmdCombine.ToString();
        }
        /// <summary>
        /// 创建或更新视频list
        /// </summary>
        /// <param name="sceneVideoInfoList"></param>
        /// <param name="sceneName"></param>
        public static void CreateOrUpdateVideoList(List<VideoInfo> sceneVideoInfoList, string sceneName)
        {
            string[] lines = new string[sceneVideoInfoList.Count];
            string combineVideoList = FileHelper.GetFileAbsolutePath("VideoLists\\") + sceneName + ".txt";
            for (int i = 0; i < sceneVideoInfoList.Count; i++)
            {
                lines[i] = "file '" + sceneVideoInfoList[i].VideoPath + "'";
            }
            System.IO.File.WriteAllLines(combineVideoList, lines, Encoding.UTF8);
        }
        /// <summary>
        /// 删除中间临时视频
        /// </summary>
        /// <param name="sceneVideoInfoList"></param>
        public static void DeleteTempVideos(List<VideoInfo> sceneVideoInfoList)
        {
            string path = FileHelper.GetFileAbsolutePath("SourceVideos\\");
            foreach (var videoInfo in sceneVideoInfoList)
            {
                string tempVideo = path + videoInfo.VideoName + ".ts";
                if (File.Exists(tempVideo))
                    File.Delete(tempVideo);
            }
        }
    }
}
