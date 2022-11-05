using EntityLayer.AIMEntity;

/// <summary>
/// Summary description for IAIMDAL
/// </summary>

namespace DataAcessLayer.AIMDAL
{
    public interface IAIMDAL
    {
        AIMStatusResponse UpdateEinPc(AIMEntity objDATA);
    }
}