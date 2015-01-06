using System;
using SDL2;

namespace Agares.Engine
{
	public class Window : IDisposable
	{
		private readonly IntPtr _window;

		internal IntPtr Pointer { get { return _window; } }

		public Window(string title, int x, int y, int width, int height, WindowFlags flags)
		{
			_window = SDL.SDL_CreateWindow(title, x, y, width, height, (SDL.SDL_WindowFlags) flags);

			if (_window == IntPtr.Zero)
			{
				var message = string.Format("Cannot create window: {0}", SDL.SDL_GetError());
				throw new Exception(message);
			}
		}

		public static Window CreateCentered(string title, int width, int height, WindowFlags flags)
		{
			return new Window(title, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, width, height, flags);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_window != IntPtr.Zero)
			{
				SDL.SDL_DestroyWindow(_window);
			}	
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~Window()
		{
			Dispose(false);
		}
	}
}