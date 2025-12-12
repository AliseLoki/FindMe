using System.Numerics;

namespace Assets.CodeBase.Infrastructure.Services.Input
{
    public interface IInput : IService
    {
        Vector2 InputAxis {  get; }
    }
}
