# Azure App Configuration Demo

This is ASP.NET Core 8 Razor Pages demo app based on the official samples for Azure App Configuration. If you are not familiar with Azure App Configuration, start [here](https://learn.microsoft.com/en-us/azure/azure-app-configuration/quickstart-aspnet-core-app).

The repo offers various branches so you can quickly switch between various usage scenarios:

- `fundamentals`: The basic getting started scenario which also supports [Key Vault references](https://learn.microsoft.com/en-us/azure/azure-app-configuration/use-key-vault-references-dotnet-core).
- `refresh`: Using [pull-based refresh](https://learn.microsoft.com/en-us/azure/azure-app-configuration/enable-dynamic-configuration-aspnet-core) to dynamically update configuration values.
- `labels`: Using [labels](https://learn.microsoft.com/en-us/azure/azure-app-configuration/howto-labels-aspnet-core) to differentiate configuration values per ASP.NET Core [environment](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-8.0).
- `snaphots`: Using [snaphots](https://learn.microsoft.com/en-us/azure/azure-app-configuration/howto-create-snapshots?tabs=dotnet).
- `featutes`: Using [feature management capabilities](https://learn.microsoft.com/en-us/azure/azure-app-configuration/quickstart-feature-flag-aspnet-core).

The repo doesn't include any infrastructure as code (yet) to create the required Azure services, but you can follow any of the examples linked above to create the required services.

The samples allow using both connection strings and passwordless access. 
- Set the environment variable `AppConfig__Endpoint` or the [user secret](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=linux) `AppConfig:Endpoint` for passwordless access. This requires that you are already logged on to Azure through your IDE, Azure CLI, Azure PowerShell etc. and [authorized accordingly](https://learn.microsoft.com/en-us/azure/azure-app-configuration/concept-enable-rbac). 
- Set the environment variable `ConnectionString__AppConfig` or the [user secret](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=linux) `ConnectionString:AppConfig` for classic authentication.

Note that either way, all samples will require to be logged on to Azure anyway, since access to Key Vault requires Entra ID.