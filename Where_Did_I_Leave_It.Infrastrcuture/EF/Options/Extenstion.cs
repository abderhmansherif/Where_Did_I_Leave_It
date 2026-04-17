using Microsoft.Extensions.Configuration;

namespace Where_Did_I_Leave_It.Infrastrcuture.EF.Options
{
    public static class Extension
    {
        public static TOption GetOption<TOption>(this IConfiguration configuration, string sectionName) where TOption : new()
        {
            var option = new TOption();
            configuration.GetSection(sectionName).Bind(option);
            return option;
        }
    }
}
