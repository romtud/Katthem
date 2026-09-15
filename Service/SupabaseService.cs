using Supabase;

namespace WpfMVVM.Service;

public sealed class SupabaseService : ISupabaseService
{
    private readonly string _url;
    private readonly string _key;

    public Client Client { get; private set; } = null!;

    public SupabaseService()
    {
        _url = "https://zeznnyhsenqepwquyegf.supabase.co";
        _key = "sb_publishable_0Dwx-i8vs0afBld2vsB2eA_Z1jntTUO";
    }

    public async Task InitializeAsync()
    {
        if (_url.StartsWith("YOUR_", StringComparison.OrdinalIgnoreCase) ||
            _key.StartsWith("YOUR_", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                "Supabase is not configured. Set SUPABASE_URL and SUPABASE_KEY.");
        }

        var options = new SupabaseOptions
        {
            AutoConnectRealtime = false,
            AutoRefreshToken = false
        };

        Client = new Client(_url, _key, options);
        await Client.InitializeAsync();
    }
}
