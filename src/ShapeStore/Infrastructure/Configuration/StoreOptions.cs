namespace ShapeStore.Infrastructure.Configuration
{
    public class StoreOptions
    {
        public const string StoreSettignsSection = "StoreSettings";
        public string StoreType { get; set; } = "sql"; // sql, cosmos, postgresql
        public string DatabaseName { get; set; } = ""; // if needed and not contained in connection string
    }
}
