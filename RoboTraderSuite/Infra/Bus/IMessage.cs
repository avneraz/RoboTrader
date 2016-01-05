using Infra.Enum;

namespace Infra.Bus
{
    public interface IMessage
    {

        EapiDataTypes APIDataType { get;  }

    }
}
