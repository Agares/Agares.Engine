using System;
using System.IO;

namespace Agares.Engine
{
	public class FilesystemResourceManager : IResourceManager
	{
		private readonly IRenderer _renderer;
		private const string ResourceDirectory = "App_Data";
		private const string TextureExtension = ".bmp";
		private readonly string _basePath;

		public FilesystemResourceManager(IRenderer renderer, string basePath = null)
		{
			_renderer = renderer;
			_basePath = basePath ?? Path.Combine(Environment.CurrentDirectory, ResourceDirectory);
		}

		public Texture LoadTexture(string id)
		{
			return Texture.FromFile(_renderer, Path.Combine(_basePath, id) + TextureExtension);
		}
	}
}