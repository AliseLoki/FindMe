using System.Numerics;


namespace Assets.CodeBase.Infrastructure.Services.Input
{
    public class DesktopInput : IInput
    {
        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);

        public Vector2 InputAxis =>
            new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}
