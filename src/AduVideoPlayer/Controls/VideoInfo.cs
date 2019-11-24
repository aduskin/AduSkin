using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AduVideoPlayer.Controls
{
    /// <summary>
    /// 视频播放信息
    /// </summary>
    public class VideoInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        private string Key { get; set; }
        /// <summary>
        /// 视频名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 视频播放路径
        /// </summary>
        public string PlayUrl { get; set; }
        /// <summary>
        /// 视频播放类型
        /// </summary>
        public EnumVideoType VideoType { get; set; }
    }

    public enum EnumVideoType
    {
        LocalVideo = 0,
        Stream = 1,
        Mrl = 2,
        Uri = 3,
    }
}
