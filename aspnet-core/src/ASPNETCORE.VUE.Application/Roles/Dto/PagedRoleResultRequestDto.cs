using Abp.Application.Services.Dto;

namespace ASPNETCORE.VUE.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

