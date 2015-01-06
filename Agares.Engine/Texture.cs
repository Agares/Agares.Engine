using System;
using System.Runtime.InteropServices;
using SDL2;

namespace Agares.Engine
{
	public class Texture : IDisposable
	{
		public IntPtr Pointer { get { return _texture; } }
		public int Width { get; private set; }
		public int Height { get; private set; }

		private IntPtr _texture;

		private Texture(IntPtr renderer, string filename)
		{
			var surface = SDL.SDL_LoadBMP(filename);
			if (surface == IntPtr.Zero)
			{
				throw new Exception(string.Format("Cannot load file {0}: {1}", filename, SDL.SDL_GetError()));
			}

			LoadTextureFromSurface(renderer, surface);
			SetTextureInformation(surface);

			SDL.SDL_FreeSurface(surface);
		}

		private void LoadTextureFromSurface(IntPtr renderer, IntPtr surface)
		{
			_texture = SDL.SDL_CreateTextureFromSurface(renderer, surface);
			if (_texture == IntPtr.Zero)
			{
				throw new Exception(string.Format("Cannot create texture: {0}", SDL.SDL_GetError()));
			}
		}

		private void SetTextureInformation(IntPtr surface)
		{
			var surfaceStructure = (SDL.SDL_Surface) Marshal.PtrToStructure(surface, typeof (SDL.SDL_Surface));
			Width = surfaceStructure.w;
			Height = surfaceStructure.h;
		}

		internal static Texture FromFile(IntPtr renderer, string filename)
		{
			return new Texture(renderer, filename);
		}

		public static Texture FromFile(IRenderer renderer, string filename)
		{
			return new Texture(renderer.Pointer, filename);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_texture != IntPtr.Zero)
			{
				SDL.SDL_DestroyTexture(_texture);
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~Texture()
		{
			Dispose(false);
		}
	}
}