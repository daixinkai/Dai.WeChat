using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dai.WeChat
{
    public static class WeChatHelper
    {
        #region EchoPass

        /// <summary>
        /// 告知微信服务器，已通过验证
        /// </summary>
        public static void EchoPass(this HttpContext context, string echostr)
        {
            context.Response.Write(echostr);
            context.Response.Flush();
        }

        /// <summary>
        /// 告知微信服务器，已通过验证
        /// </summary>
        public static void EchoPass(this HttpContext context)
        {
            context.EchoPass(context.Request["echostr"]);
        }

        /// <summary>
        /// 告知微信服务器，已通过验证
        /// </summary>
        public static void EchoPass(string echostr)
        {
            HttpContext.Current.EchoPass(echostr);
        }

        /// <summary>
        /// 告知微信服务器，已通过验证
        /// </summary>
        public static void EchoPass()
        {
            EchoPass(HttpContext.Current.Request["echostr"]);
        }

        #endregion


        #region Internal

        static Lazy<bool> LazyIsWebApplication
        {
            get { return new Lazy<bool>(() => System.Threading.Thread.GetDomain().FriendlyName.Contains("W3SVC"), true); }
        }

        /// <summary>
        /// 获取一个值,指示当前是否是Web应用程序(托管IIS中)
        /// </summary>
        internal static bool IsWebApplication
        {
            get
            {
                return LazyIsWebApplication.Value;
            }
        }

        /// <summary>
        /// 将字符串转换为指定枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strValue"></param>
        /// <returns></returns>

        internal static T ToEnum<T>(string strValue) where T : struct
        {
            T t = default(T);
            return Enum.TryParse<T>(strValue, true, out t) ? t : default(T);
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <returns>Unix时间戳格式</returns>
        internal static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        internal static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// 确定当前 System.Type 表示的类是否是从指定的 System.Type 表示的类派生的。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static bool IsSubOf(this Type type, Type c)
        {
            return type.Equals(c) ||/*type.IsSubclassOf(t) ||*/ c.IsAssignableFrom(type) || c.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
        }

        /// <summary>
        /// 从指定程序集中获取所有派生类
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        internal static IEnumerable<T> GetInstanceFromAssembly<T>(Assembly assembly)
        {
            Type t = typeof(T);

            Type[] types = null;

            try
            {
                types = assembly.GetTypes();
            }
            catch
            {
            }
            if (types == null)
            {
                yield break;
            }

            foreach (var type in types)
            {
                if (!type.IsInterface && !type.IsAbstract && type.IsSubOf(t))
                {
                    T value;
                    try
                    {
                        value = (T)type.GetConstructor(Type.EmptyTypes).Invoke(null);
                    }
                    catch
                    {
                        continue;
                    }
                    yield return value;
                }
            }

        }

        /// <summary>
        /// 得到当前应用程序中引用指定程序集的所有程序集
        /// </summary>
        /// <returns></returns>
        internal static IEnumerable<Assembly> GetReferencedAssemblies(Assembly assembly, bool containsSelf = false)
        {

            AssemblyName assemblyName = assembly.GetName();


            //string dir = HttpContext.Current == null ? AppDomain.CurrentDomain.BaseDirectory : System.Web.Hosting.HostingEnvironment.MapPath("~/bin");
            string dir = !IsWebApplication ? AppDomain.CurrentDomain.BaseDirectory : System.Web.Hosting.HostingEnvironment.MapPath("~/bin");

            var allFiles = Directory.GetFiles(dir, "*.dll");

            foreach (var item in allFiles)
            {
                Assembly referenceAssembly = null;
                try
                {
                    referenceAssembly = Assembly.LoadFrom(item);
                    var referencedAssemblies = referenceAssembly.GetReferencedAssemblies();
                    //必须要引用指定的程序集才可以
                    if (!referencedAssemblies.Any(s => s.Name.Equals(assemblyName.Name)))
                    {
                        continue;
                    }
                }
                catch
                {
                    continue;
                }
                yield return referenceAssembly;
            }
            //最后是自己
            if (containsSelf)
            {
                yield return assembly;
            }
        }


        /// <summary>
        /// 得到当前应用程序中引用调用此方法程序集的所有程序集
        /// </summary>
        /// <returns></returns>
        internal static IEnumerable<Assembly> GetReferencedAssemblies(bool containsSelf = false)
        {
            return GetReferencedAssemblies(Assembly.GetCallingAssembly(), containsSelf);
        }

        #endregion

    }
}
