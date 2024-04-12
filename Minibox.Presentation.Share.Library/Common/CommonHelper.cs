using Minibox.Presentation.Share.Library.Constant;
using System.Runtime.InteropServices;

namespace Minibox.Presentation.Share.Library.Common
{
    public partial class CommonHelper
    {        
        /// <summary>
        /// Retry
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="action"></param>
        /// <param name="retryInterval"></param>
        /// <param name="maxAttemptCount"></param>
        /// <returns></returns>
        /// <exception cref="AggregateException"></exception>
        public static async Task<TResult> RetryAsync<TResult>(Func<Task<TResult>> action, TimeSpan retryInterval, int maxAttemptCount = 3)
        {
            var exceptions = new List<Exception>();

            for (int attempted = 0; attempted < maxAttemptCount; attempted++)
            {
                try
                {
                    if (attempted > 0)
                    {
                        Task.Delay(retryInterval).Wait();
                    }
                    return await action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            throw new AggregateException(exceptions);
        }

        /// <summary>
        /// Generate a random activation code
        /// </summary>
        /// <returns></returns>
        public static string GenerateActivationCode()
        {
            var random = new Random();
            var number = random.Next(100000);
            return number.ToString("000000");
        }

        
        [LibraryImport("rpcrt4.dll", SetLastError = true)]
        private static partial int UuidCreateSequential(out Guid guid);
        public static Guid NewSequenceGuid()
        {
            const int RPC_S_OK = 0;
            int hr = UuidCreateSequential(out Guid g);
            if (hr != RPC_S_OK)
                throw new ApplicationException
                  ("UuidCreateSequential failed: " + hr);
            return g;
        }

        /// <summary>
        /// Check email address is valid or not
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmailAddress(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email.Trim());
                return addr.Address == email.Trim();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check timeZoneId is valid or not
        /// </summary>
        /// <param name="timeZoneId"></param>
        /// <returns></returns>
        public static bool IsValidTimeZoneId(string? timeZoneId)
        {
            if (string.IsNullOrWhiteSpace(timeZoneId))
                return false;
            return TimeZoneInfo.GetSystemTimeZones().Select(x => x.Id).Contains(timeZoneId);
        }

        /// <summary>
        /// Check languageCode is valid or not
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        public static bool IsValidLanguage(string? languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
                return false;
            return MiniboxConstants.Language.GetSupportedLanguages().Contains(languageCode);
        }
    }
}
