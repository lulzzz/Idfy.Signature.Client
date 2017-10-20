using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Idfy.Signature.Client
{
    public static class Extensions
    {
        private static readonly JavaScriptSerializer Serializer;
        private static readonly JsonFormatter Formatter;

        private static readonly TaskFactory _myTaskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None,
            TaskContinuationOptions.None, TaskScheduler.Default);

        static Extensions()
        {
            Serializer = new JavaScriptSerializer
            {
                MaxJsonLength = int.MaxValue
            };
            Formatter = new JsonFormatter();
        }

        // Microsoft.AspNet.Identity.AsyncHelper
        public static TResult RunSync<TResult>(this Func<Task<TResult>> func)
        {
            CultureInfo cultureUi = CultureInfo.CurrentUICulture;
            CultureInfo culture = CultureInfo.CurrentCulture;
            return Extensions._myTaskFactory.StartNew<Task<TResult>>(delegate
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;
                return func();
            }).Unwrap<TResult>().GetAwaiter().GetResult();
        }

        public static void RunSync(this Func<Task> func)
        {
            Extensions._myTaskFactory
                .StartNew<Task>(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

        public static string Serialize<T>(this T obj)
        {
            var json = Serializer.Serialize(obj);
            return json;
        }

        public static string SerializeAndFormat<T>(this T obj)
        {
            var json = Serializer.Serialize(obj);
            return Formatter.Format(json);
        }

        public static T Deserialize<T>(this string json)
        {
            var obj = Serializer.Deserialize<T>(json);
            return obj;
        }

        internal static SecureString ToSecureString(this string value)
        {
            var secure = new SecureString();
            foreach (var c in value)
            {
                secure.AppendChar(c);
            }
            return secure;
        }

        internal static string SecureStringToString(this SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
