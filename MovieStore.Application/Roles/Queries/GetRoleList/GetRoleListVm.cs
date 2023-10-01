using MovieStore.Application.Roles.Queries.Dtos;

namespace MovieStore.Application.Roles.Queries.GetRoleList;

public class GetRoleListVm
{
    public List<RoleDto>? Roles { get; set; }
    public long? Count { get; set; }
}