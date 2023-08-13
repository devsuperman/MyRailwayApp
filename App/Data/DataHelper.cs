using Microsoft.EntityFrameworkCore;

public static class DataHelper
{
    public static async Task ManageDataAsync(IServiceProvider svcProvider)
    {
        var dbContextSvc = svcProvider.GetRequiredService<Contexto>();
        await dbContextSvc.Database.MigrateAsync();
    }
}