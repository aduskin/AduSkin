using AduSkin.Utility.AduMethod;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace AduSkin.Utility
{
   public static class HttpHelper
   {
      public static WebList Http_Get(string _url, List<TItem> _header = null, object _conmand = null, Encode _Encode = Encode.UTF8)
      {
         return Http("GET", _url, _header, _conmand, _Encode);
      }
      public static WebList Http_Post(string _url, List<TItem> _header = null, object _conmand = null, Encode _Encode = Encode.UTF8)
      {
         return Http("POST", _url, _header, _conmand, _Encode);
      }

      //public static WebList Http(string _type, string _url, List<TItem> _header, object _conmand = null, Encode _Encode = Encode.UTF8)
      static WebList Http(string _type, string _url, List<TItem> _header, object _conmand, Encode _Encode)
      {
         Encoding _encoding = Get_Encoding(_Encode);
         HttpWebRequest req = Http_Core(_type, _url, _encoding, _header, _conmand);
         if (req != null)
         {
            try
            {
               using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
               {
                  return Http_DownSteam(response, _encoding);
               }
            }
            catch (WebException err)
            {
               var rsp = err.Response as HttpWebResponse;
               if (rsp != null)
               {
                  WebList _web = Http_DownSteam(rsp, _encoding);
                  _web.Err = err.Message;
                  rsp.Close(); rsp.Dispose();
                  return _web;
               }
            }
         }
         return null;
      }

      //public static WebList Http_NoData(string _type, string _url, List<TItem> _header, object _conmand = null, Encode _Encode = Encode.UTF8)
      public static WebList Http_NoData(string _type, string _url, List<TItem> _header, object _conmand, Encode _Encode)
      {
         Encoding _encoding = Get_Encoding(_Encode);
         HttpWebRequest req = Http_Core(_type, _url, _encoding, _header, _conmand);
         if (req != null)
         {
            try
            {
               using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
               {
                  WebList _web = new WebList
                  {
                     StatusCode = (int)response.StatusCode,
                     Type = response.ContentType,
                     AbsoluteUri = response.ResponseUri.AbsoluteUri
                  };
                  string header = "";
                  foreach (string str in response.Headers.AllKeys)
                  {
                     if (str == "Set-Cookie")
                     {
                        _web.SetCookie = response.Headers[str];
                     }
                     else if (str == "Location")
                     {
                        _web.Location = response.Headers[str];
                     }
                     header = header + str + ":" + response.Headers[str] + "\r\n";
                  }
                  string cookie = "";
                  foreach (Cookie str in response.Cookies)
                  {
                     cookie = cookie + str.Name + "=" + str.Value + ";";
                  }

                  _web.Header = header;
                  _web.Cookie = cookie;
                  return _web;
               }
            }
            catch (WebException err)
            {
               var rsp = err.Response as HttpWebResponse;
               if (rsp != null)
               {
                  WebList _web = new WebList
                  {
                     StatusCode = (int)rsp.StatusCode,
                     Type = rsp.ContentType,
                     AbsoluteUri = rsp.ResponseUri.AbsoluteUri
                  };
                  string header = "";
                  foreach (string str in rsp.Headers.AllKeys)
                  {
                     if (str == "Set-Cookie")
                     {
                        _web.SetCookie = rsp.Headers[str];
                     }
                     else if (str == "Location")
                     {
                        _web.Location = rsp.Headers[str];
                     }
                     header = header + str + ":" + rsp.Headers[str] + "\r\n";
                  }
                  string cookie = "";
                  foreach (Cookie str in rsp.Cookies)
                  {
                     cookie = cookie + str.Name + "=" + str.Value + ";";
                  }

                  _web.Header = header;
                  _web.Cookie = cookie;
                  return _web;
               }
            }
         }
         return null;
      }

      #region 其他

      static HttpWebRequest Http_Core(string _type, string _url, Encoding _encoding, List<TItem> _header, object _conmand = null)
      {
         #region 启动HTTP请求之前的初始化操作
         bool isget = false;
         if (_type == "GET")
         {
            isget = true;
         }

         if (isget)
         {
            if (_conmand is List<TItem>)
            {
               List<TItem> _conmand_ = (List<TItem>)_conmand;

               string param = "";
               foreach (TItem item in _conmand_)
               {
                  if (string.IsNullOrEmpty(param))
                  {
                     if (_url.Contains("?"))
                     {
                        param += "&" + item.Name + "=" + item.Value;
                     }
                     else
                     {
                        param = "?" + item.Name + "=" + item.Value;
                     }
                  }
                  else
                  {
                     param += "&" + item.Name + "=" + item.Value;
                  }
               }
               _url += param;
            }

         }
         Uri uri = null;
         try
         {
            uri = new Uri(_url);
         }
         catch { }
         #endregion
         if (uri != null)
         {
            //string _scheme = uri.Scheme.ToUpper();
            try
            {

               HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
               req.Proxy = null;
               req.Host = uri.Host;
               req.Method = _type;
               req.AllowAutoRedirect = false;
               bool isContentType = true;
               #region 设置请求头
               if (_header != null && _header.Count > 0)
               {
                  bool isnotHeader = true;
                  System.Collections.Specialized.NameValueCollection collection = null;

                  foreach (TItem item in _header)
                  {
                     string _Lower_Name = item.Name.ToLower();
                     switch (_Lower_Name)
                     {
                        case "host":
                           req.Host = item.Value;
                           break;
                        case "accept":
                           req.Accept = item.Value;
                           break;
                        case "user-agent":
                           req.UserAgent = item.Value;
                           break;
                        case "referer":
                           req.Referer = item.Value;
                           break;
                        case "content-type":
                           isContentType = false;
                           req.ContentType = item.Value;
                           break;
                        case "cookie":
                           #region 设置COOKIE
                           string _cookie = item.Value;
                           CookieContainer cookie_container = new CookieContainer();
                           if (_cookie.IndexOf(";") >= 0)
                           {
                              string[] arrCookie = _cookie.Split(';');
                              //加载Cookie
                              //cookie_container.SetCookies(new Uri(url), cookie);
                              foreach (string sCookie in arrCookie)
                              {
                                 if (string.IsNullOrEmpty(sCookie))
                                 {
                                    continue;
                                 }
                                 if (sCookie.IndexOf("expires") > 0)
                                 {
                                    continue;
                                 }
                                 cookie_container.SetCookies(uri, sCookie);
                              }
                           }
                           else
                           {
                              cookie_container.SetCookies(uri, _cookie);
                           }
                           req.CookieContainer = cookie_container;
                           #endregion
                           break;
                        default:
                           if (isnotHeader && collection == null)
                           {
                              var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                              if (property != null)
                              {
                                 collection = property.GetValue(req.Headers, null) as System.Collections.Specialized.NameValueCollection;
                              }
                              isnotHeader = false;
                           }
                           //设置对象的Header数据
                           if (collection != null)
                           {
                              collection[item.Name] = item.Value;
                           }
                           break;

                     }
                  }
               }
               #endregion

               #region 设置POST数据 
               if (!isget)
               {
                  if (_conmand != null)
                  {
                     if (_conmand is List<TItem>)
                     {
                        List<TItem> _conmand_ = (List<TItem>)_conmand;
                        //POST参数
                        if (isContentType)
                        {
                           req.ContentType = "application/x-www-form-urlencoded";
                        }
                        string param = "";
                        foreach (TItem item in _conmand_)
                        {
                           if (string.IsNullOrEmpty(param))
                           {
                              param = item.Name + "=" + item.Value;
                           }
                           else
                           {
                              param += "&" + item.Name + "=" + item.Value;
                           }
                        }

                        byte[] bs = _encoding.GetBytes(param);

                        req.ContentLength = bs.Length;

                        using (Stream reqStream = req.GetRequestStream())
                        {
                           reqStream.Write(bs, 0, bs.Length);
                           reqStream.Close();
                        }
                     }
                     else if (_conmand is string[])
                     {
                        try
                        {
                           string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                           byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                           byte[] endbytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

                           req.ContentType = "multipart/form-data; boundary=" + boundary;


                           using (Stream reqStream = req.GetRequestStream())
                           {
                              string[] files = (string[])_conmand;

                              string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                              byte[] buff = new byte[1024];
                              for (int i = 0; i < files.Length; i++)
                              {
                                 string file = files[i];
                                 reqStream.Write(boundarybytes, 0, boundarybytes.Length);

                                 string contentType = MimeMappingProvider.Shared.GetMimeMapping(file);

                                 //string contentType = System.Web.MimeMapping.GetMimeMapping(file);

                                 //string header = string.Format(headerTemplate, "file" + i, Path.GetFileName(file), contentType);
                                 string header = string.Format(headerTemplate, "media", Path.GetFileName(file), contentType);//微信
                                 byte[] headerbytes = _encoding.GetBytes(header);
                                 reqStream.Write(headerbytes, 0, headerbytes.Length);

                                 using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                                 {

                                    int contentLen = fileStream.Read(buff, 0, buff.Length);

                                    int Value = contentLen;
                                    //文件上传开始
                                    //tProgress.Invoke(new Action(() =>
                                    //{
                                    //    tProgress.Maximum = (int)fileStream.Length;
                                    //    tProgress.Value = Value;
                                    //}));

                                    while (contentLen > 0)
                                    {
                                       //文件上传中

                                       reqStream.Write(buff, 0, contentLen);
                                       contentLen = fileStream.Read(buff, 0, buff.Length);
                                       Value += contentLen;

                                       //tProgress.Invoke(new Action(() =>
                                       //{
                                       //    tProgress.Value = Value;
                                       //}));
                                    }
                                 }
                              }

                              //文件上传结束
                              reqStream.Write(endbytes, 0, endbytes.Length);
                           }
                        }
                        catch
                        {
                           if (isContentType)
                           {
                              req.ContentType = null;
                           }
                           req.ContentLength = 0;
                        }

                     }
                     else
                     {
                        //POST参数 
                        if (isContentType)
                        {
                           req.ContentType = "application/x-www-form-urlencoded";
                        }
                        string param = _conmand.ToString();

                        byte[] bs = _encoding.GetBytes(param);

                        req.ContentLength = bs.Length;

                        using (Stream reqStream = req.GetRequestStream())
                        {
                           reqStream.Write(bs, 0, bs.Length);
                           reqStream.Close();
                        }
                     }

                  }
                  else
                  {
                     req.ContentLength = 0;
                  }
               }
               #endregion

               return req;
            }
            catch
            {
            }
         }
         return null;
      }


      /// <summary>
      /// 数据流下载
      /// </summary>
      /// <param name="response"></param>
      /// <param name="_web"></param>
      /// <param name="encoding"></param>
      static WebList Http_DownSteam(HttpWebResponse response, Encoding encoding)
      {
         WebList _web = new WebList
         {
            Encoding = encoding,
            StatusCode = (int)response.StatusCode,
            Type = response.ContentType,
            AbsoluteUri = response.ResponseUri.AbsoluteUri
         };
         string header = "";
         foreach (string str in response.Headers.AllKeys)
         {
            if (str == "Set-Cookie")
            {
               _web.SetCookie = response.Headers[str];
            }
            else if (str == "Location")
            {
               _web.Location = response.Headers[str];
            }
            header = header + str + ":" + response.Headers[str] + "\r\n";
         }
         string cookie = "";
         foreach (Cookie str in response.Cookies)
         {
            cookie = cookie + str.Name + "=" + str.Value + ";";
         }

         _web.Header = header;
         _web.Cookie = cookie;

         #region 下载流
         using (Stream stream = response.GetResponseStream())
         {
            using (MemoryStream file = new MemoryStream())
            {
               int _value = 0;
               byte[] _cache = new byte[1024];
               int osize = stream.Read(_cache, 0, 1024);

               while (osize > 0)
               {
                  _value += osize;

                  file.Write(_cache, 0, osize);
                  osize = stream.Read(_cache, 0, 1024);
               }

               file.Seek(0, SeekOrigin.Begin);
               byte[] _byte = new byte[_value];
               file.Read(_byte, 0, _value);

               file.Seek(0, SeekOrigin.Begin);
               string fileclass = GetFileClass(file);
               if (fileclass == "31139")
               {
                  //_web.OriginalSize = _byte.Length;
                  _web.Byte = Decompress(_byte);
               }
               else
               {
                  _web.Byte = _byte;
               }
            }
         }
         #endregion
         return _web;
      }

      static string GetFileClass(Stream stream)
      {
         string fileclass = "";
         try
         {
            using (BinaryReader r = new BinaryReader(stream))
            {
               byte buffer = r.ReadByte();
               fileclass = buffer.ToString();
               buffer = r.ReadByte();
               fileclass += buffer.ToString();
            }
         }
         catch { }
         return fileclass;
      }
      ///  <summary> 
      /// 解压字符串
      ///  </summary> 
      ///  <param name="data"></param> 
      ///  <returns></returns> 
      static byte[] Decompress(byte[] data)
      {
         try
         {
            var ms = new MemoryStream(data);
            var zip = new GZipStream(ms, CompressionMode.Decompress, true);
            var msreader = new MemoryStream();
            var buffer = new byte[0x1000];
            while (true)
            {
               var reader = zip.Read(buffer, 0, buffer.Length);
               if (reader <= 0)
               {
                  break;
               }
               msreader.Write(buffer, 0, reader);
            }
            zip.Close();
            ms.Close();
            msreader.Position = 0;
            buffer = msreader.ToArray();
            msreader.Close();
            return buffer;
         }
         catch (Exception e)
         {
            throw new Exception(e.Message);
         }
      }


      static Encoding Get_Encoding(Encode _Encode)
      {
         switch (_Encode)
         {
            case Encode.UTF7: return Encoding.UTF7;
            case Encode.UTF32: return Encoding.UTF32;
            case Encode.UNICODE: return Encoding.Unicode;
            case Encode.ASCII: return Encoding.ASCII;
            case Encode.GB2312:
               return Encoding.GetEncoding("GB2312");
            case Encode.GBK:
               return Encoding.GetEncoding("GBK");
            default: return Encoding.UTF8;
         }
      }


      #endregion

      #region 各类型转换

      /// <summary>
      /// 将字节转为文本类型
      /// </summary>
      /// <param name="_byte">字节</param>
      /// <returns>返回文本</returns>
      public static string ToStringX(this WebList _web)
      {
         if (_web != null && _web.Byte != null)
         {
            return _web.Encoding.GetString(_web.Byte);
         }
         return null;
      }

      /// <summary>
      /// 将字节转为json
      /// </summary>
      /// <typeparam name="T">JSON模型</typeparam>
      /// <param name="_byte">字节</param>
      /// <returns>返回json</returns>
      //public static T ToJson<T>(this WebList _web)
      //{
      //    if (_web != null && _web.Byte != null)
      //    {
      //        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(_web.Encoding.GetString(_web.Byte));
      //    }
      //    return default(T);
      //}

      /// <summary>
      /// 将字节转为图片
      /// </summary>
      /// <param name="_byte">字节</param>
      /// <returns>返回图片</returns>
      public static System.Drawing.Image ToImage(this WebList _web)
      {
         if (_web != null && _web.Byte != null)
         {
            using (MemoryStream ms = new MemoryStream(_web.Byte))
            {
               System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
               return img;
            }
         }
         return null;
      }

      #endregion

   }

   public enum Encode
   {
      UTF8,
      UTF7,
      UTF32,
      UNICODE,
      ASCII,
      GB2312,
      GBK,
   }

   public class WebList
   {
      public Encoding Encoding { set; get; }
      public int StatusCode { set; get; }
      //public string ServerHeader { set; get; }
      //public string DNS { set; get; }
      public string AbsoluteUri { set; get; }
      public string Type { set; get; }
      public string Header { set; get; }
      public string Cookie { set; get; }
      public byte[] Byte { set; get; }
      public string SetCookie { set; get; }
      public string Location { set; get; }
      //public string Html { set; get; }
      public string Err { set; get; }
      //public int OriginalSize { set; get; }
      //public string FileName { set; get; }
   }

   public class TItem
   {
      public string Name { get; set; }
      public string Value { get; set; }
   }
}
