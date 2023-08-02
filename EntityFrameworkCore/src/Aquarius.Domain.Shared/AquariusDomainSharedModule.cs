using Aquarius.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Aquarius;

[DependsOn(
    typeof(AbpLocalizationModule)
    )]
public class AquariusDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AquariusDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AquariusResource>("en")
                .AddBaseTypes(typeof(AquariusResource))
                .AddVirtualJson("/Localization/Aquarius");

            options.DefaultResourceType = typeof(AquariusResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Aquarius", typeof(AquariusResource));
        });
    }
}
