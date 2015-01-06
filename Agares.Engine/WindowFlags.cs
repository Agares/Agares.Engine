using System;
using SDL2;

namespace Agares.Engine
{
	[Flags]
	public enum WindowFlags
	{
		FullScreen = SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN,
		OpenGL = SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL,
		Shown = SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN,
		Hidden = SDL.SDL_WindowFlags.SDL_WINDOW_HIDDEN,
		Borderless = SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS,
		Resizable = SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE,
		Minimized = SDL.SDL_WindowFlags.SDL_WINDOW_MINIMIZED,
		Maximized = SDL.SDL_WindowFlags.SDL_WINDOW_MAXIMIZED,
		InputGrabbed = SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED,
		InputFocus = SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS,
		MouseFocus = SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS,
		FullscreenDesktop = SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP,
		Foreign = SDL.SDL_WindowFlags.SDL_WINDOW_FOREIGN,
		AllowHighDPI = SDL.SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI,
	}
}