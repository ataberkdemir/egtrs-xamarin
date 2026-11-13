using System;

namespace LoginPageSpeedUI
{
    /// <summary>
    /// Public repository placeholder only. Never commit real database credentials.
    /// For production, move database access behind a secured API instead of connecting
    /// directly from a mobile client.
    /// </summary>
    public static class ConnectionSettings
    {
        // Replace these placeholders only in a private local configuration.
        // Do not put production credentials in a mobile app or public repository.
        public const string SqlConnectionString =
            "Data Source=YOUR_SERVER;Initial Catalog=ToplantiDb;User ID=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=True;";
    }
}
