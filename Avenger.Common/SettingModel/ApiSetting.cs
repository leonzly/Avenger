using Avenger.Common.Attributes;
using Avenger.Common.Constant;
using System.ComponentModel.DataAnnotations;

namespace Avenger.Common.SettingModel
{
    [SettingSection(AppSettingSectionConstant.CONFIG_SECTION_API)]
    public class ApiSetting
    {
        [Required]
        public string ApiKey { get; set; }
        public string ApiKeyHeaderName { get; set; }
        [Required]
        public string CorrelationIdHeaderName { get; set; }
        [Required]
        public string CorrelationIdVariableKey { get; set; }
        public string ApiBearer { get; set; }
    }
}
