using WpfMVVM.Models;
using Supabase.Postgrest;
using Supabase.Postgrest.Interfaces;

namespace WpfMVVM.Service;

public sealed class ShelterService
{
    private readonly ISupabaseService _supabase;

    public ShelterService(ISupabaseService supabase) => _supabase = supabase;

    public async Task<IReadOnlyList<Shelter>> GetSheltersAsync()
    {
        var response = await _supabase.Client
            .From<Shelter>()
            .Order("name", Constants.Ordering.Ascending)
            .Get();

        return response.Models;
    }
}
