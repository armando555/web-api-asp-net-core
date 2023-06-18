using Application.Issue;
using Domain.Issue;
using Domain.Issue.Repositories;
using Infrastructure.Repositories;
using Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IssueContext>(
            o => o.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        services.AddScoped<IIssueRepository, IssueRepository>();
        services.AddDbContext<IssueContext>();
        services.AddScoped<IIssueProcess, IssueProcess>();
        return services;
    }
}