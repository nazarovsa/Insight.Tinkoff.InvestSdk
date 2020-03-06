using System;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace Insight.Tinkoff.InvestSdk.Infrastructure.Extensions
{
    internal static class EnumExtensions
    {
        public static string GetEnumMemberAttributeValue<T>(this T e) where T : IConvertible
        {
            var type = e.GetType();
            if (e is Enum)
            {
                var values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val) ??
                                                     throw new InvalidOperationException(
                                                         $"Failed to get enum name of value: {val}"));
                        var enumMemberAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                            .FirstOrDefault() as EnumMemberAttribute;

                        if (enumMemberAttribute != null)
                            return enumMemberAttribute.Value;

                        throw new InvalidOperationException(
                            $"EnumMemberAttribute not defined on member {val} of type {type.FullName}");
                    }
                }
            }

            throw new InvalidOperationException($"Type {type.FullName} isn't enum");
        }
    }
}