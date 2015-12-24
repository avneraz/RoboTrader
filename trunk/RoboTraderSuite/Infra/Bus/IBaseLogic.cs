
namespace Infra.Bus
{
    public interface IBaseLogic
    {
        void Enqueue(IMessage message, bool duplicate=true);
    }
}
