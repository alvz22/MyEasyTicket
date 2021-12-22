using MyEasyTicket.Domain.Validations.Resource;
using System.ComponentModel;

namespace MyEasyTicket.Domain.Extentions
{
    public static class ValidationExtention
    {
        public static string Description(this Message message)
        {
            var type = message.GetType();
            var memberInfo = type.GetMember(message.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
