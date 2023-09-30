using UESAN.Store.CORE.Entities;
using UESAN.Store.CORE.Settings;

namespace UESAN.Store.CORE.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(User user);
    }
}