using SDL2;

public static class ModuleInitializer
{
    public static void Initialize()
    {
	    SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
    }
}