using System;
using System.Collections.Generic;
using System.Text;
using WpfMVVM.Models;

namespace WpfMVVM.Service
{
    public class CatService
    {
        private readonly Supabase.Client _client;

        public CatService()
        {
            _client = new Supabase.Client(
                "https://ncsrlwznrdqowblmhbvd.supabase.co",
                "sb_publishable_2D7VZRsUz-mSjd9Q9WrAyA_-9iCkGgO");
        }

        public async Task<List<Cat>> GetCats()
        {
            var result = await _client
                .From<Cat>()
                .Get();
            return result.Models;
        }
    }
}
