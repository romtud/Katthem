using WpfMVVM.Models;
using Supabase.Postgrest;

namespace WpfMVVM.Service;

public sealed class AdoptionService
{
    private readonly ISupabaseService _supabase;

    public AdoptionService(ISupabaseService supabase) => _supabase = supabase;

    public async Task<IReadOnlyList<Adoption>> GetHistoryAsync(long catId)
    {
        var response = await _supabase.Client
            .From<Adoption>()
            .Where(x => x.CatId == catId)
            .Order("date_adopted", Constants.Ordering.Descending)
            .Get();

        return response.Models;
    }

    public async Task AdoptAsync(
        long catId,
        DateTime dateAdopted,
        string firstName,
        string lastName)
    {
        var parameters = new Dictionary<string, object>
        {
            ["p_cat_id"] = catId,
            ["p_date_adopted"] = dateAdopted.Date,
            ["p_first_name"] = firstName.Trim(),
            ["p_last_name"] = lastName.Trim()
        };

        await _supabase.Client.Rpc("adopt_cat", parameters);
    }

    public async Task ReturnAsync(long adoptionId, DateTime dateReturned)
    {
        var parameters = new Dictionary<string, object>
        {
            ["p_adoption_id"] = adoptionId,
            ["p_date_returned"] = dateReturned.Date
        };

        await _supabase.Client.Rpc("return_cat", parameters);
    }
}
