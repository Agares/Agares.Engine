using System;
using Agares.Engine.Geometry;

namespace Agares.Engine
{
	public interface IRenderer : IDisposable
	{
		IntPtr Pointer { get; }

		void DrawTexture(Texture texture);
		void DrawTexture(Texture texture, Rectangle source, Rectangle destination);
		void Clear();
		void Present();
	}
}