using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AduSkin.Demo.Data.Enum
{
   public enum DemoType
   {
      Demo,
      Tool
   }

   public enum ControlState
   {
      New,
      InDev,
      Nor
   }

   public enum SupportType
   {
      //技术
      Skill,
      //打赏
      Money,
      //推荐
      Recommend,
      //推广
      Extension
   }
}
