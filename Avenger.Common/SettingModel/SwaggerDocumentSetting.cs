using Avenger.Common.Attributes;
using Avenger.Common.Constant;
using System.ComponentModel.DataAnnotations;

namespace Avenger.Common.SettingModel
{
    [SettingSection(AppSettingSectionConstant.CONFIG_SECTION_SWAGGER_DOCUMENT)]
    public class SwaggerDocumentSetting
    {
        [Required]
        public string Version { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
