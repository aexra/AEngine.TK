namespace AEngine.TK.Core.Rendering.Buffers
{
    public interface IBuffer
    {
        int BufferId { get; }
        void Bind();
        void Unbind();
    }
}
