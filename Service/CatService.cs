using WpfMVVM.Models;
using Supabase.Postgrest;

namespace WpfMVVM.Service;

public sealed class CatService
{
    private readonly ISupabaseService _supabase;
    
    public CatService(ISupabaseService supabase) => _supabase = supabase;

    public async Task<IReadOnlyList<Cat>> GetCatsByShelterAsync(long shelterId)
    {
        var response = await _supabase.Client
            .From<Cat>()
            .Where(x => x.ShelterId == shelterId)
            .Order("name", Constants.Ordering.Ascending)
            .Get();

        return response.Models;
    }

    public async Task<IReadOnlyList<Cat>> GetAvailableCatsAsync(string? search = null)
    {
        var query = _supabase.Client
            .From<Cat>()
            .Where(x => x.Adopted == false);

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Filter("name", Constants.Operator.ILike, $"%{search.Trim()}%");

        var response = await query
            .Order("name", Constants.Ordering.Ascending)
            .Get();

        return response.Models;
    }

    public async Task<Cat?> GetCatAsync(long catId)
    {
        var response = await _supabase.Client
            .From<Cat>()
            .Where(x => x.Id == catId)
            .Single();

        return response;
    }
}
