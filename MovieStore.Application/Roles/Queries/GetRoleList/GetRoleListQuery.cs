using MediatR;

namespace MovieStore.Application.Roles.Queries.GetRoleList;

public class GetRoleListQuery : IRequest<GetRoleListVm>
{
    public string RoleName { get; set; }
}