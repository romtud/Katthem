using Supabase;

namespace WpfMVVM.Services;

public interface ISupabaseService
{
    Client Client { get; }
    Task InitializeAsync();
}
