using Microsoft.EntityFrameworkCore.ValueGeneration;
using Minibox.Presentation.Share.Library.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibox.Presentation.Share.Library.Common
{
    public class CommonHelper
    {
        private static readonly SequentialGuidValueGenerator _generator;

        /// <summary>
        /// Initialize
        /// </summary>
        static CommonHelper()
        {
            _generator = new SequentialGuidValueGenerator();
        }

        /// <summary>
        /// New sequential GUID
        /// </summary>
        /// <returns></returns>
        public static Guid NewSequenceGuid() => _generator.Next(null);

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

        /// <summary>
        /// Reset concurrency token
        /// </summary>
        /// <returns></returns>
        public static string ResetConcurrencyToken() => NewSequenceGuid().ToString().ToUpper();

        /// <summary>
        /// Check email address is valid or not
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmailAddress(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
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
