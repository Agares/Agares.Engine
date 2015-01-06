using System;
using Agares.Engine.Geometry;
using SDL2;

namespace Agares.Engine
{
	public class Renderer : IRenderer
	{
		private readonly IntPtr _renderer;

		public IntPtr Pointer { get { return _renderer; } }

		private Renderer(IntPtr window)
		{
			_renderer = SDL.SDL_CreateRenderer(window, -1, 0);

			if (_renderer == IntPtr.Zero)
			{
				throw new Exception(string.Format("Cannot create renderer: {0}", SDL.SDL_GetError()));
			}
		}

		public Renderer(Window window) : this(window.Pointer)
		{
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_renderer != IntPtr.Zero)
			{
				SDL.SDL_DestroyRenderer(_renderer);
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~Renderer()
		{
			Dispose(false);
		}

		public void DrawTexture(Texture texture)
		{
			SDL.SDL_RenderCopy(_renderer, texture.Pointer, IntPtr.Zero, IntPtr.Zero);
		}

		public void DrawTexture(Texture texture, Rectangle source, Rectangle destination)
		{
			SDL.SDL_Rect sourceRect = new SDL.SDL_Rect { x = source.Left, y = source.Top, w = source.Width, h = source.Height };
			SDL.SDL_Rect destinationRect = new SDL.SDL_Rect { x = destination.Left, y = destination.Top, w = destination.Width, h = destination.Height };

			SDL.SDL_RenderCopy(_renderer, texture.Pointer, ref sourceRect, ref destinationRect);
		}

		public void Clear()
		{
			SDL.SDL_RenderClear(_renderer);
		}

		public void Present()
		{
			SDL.SDL_RenderPresent(_renderer);
		}
	}
}