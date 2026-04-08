# Forme

This is a .NET Framework 4.8 fork from [AristurtleDev/Forme](https://github.com/AristurtleDev/Forme). Forme renders text directly from quadratic Bezier glyph outline data on the GPU without precomputed textures, distance fields, or rasterized atlases. At any size and any scale, text remains sharp. Forme also provides a CPU rasterization path that produces standard MonoGame `SpriteFont` objects for cases where traditional bitmap fonts are preferred.

![Example of the GPU Rendering Form Demo](./docs/screnshot-01.png)

For detailed README, refer to the [original repository](https://github.com/AristurtleDev/Forme).

## Prerequisites (changed from original)

- .NET Framework 4.8
- MonoGame 3.8.0.1641

If you are working on content pipeline extensions, test with real content and document any new processor parameters.

If you are modifying the shader, recompile the .mgfxo files using src/Forme.MonoGame/compile-shaders.sh and commit the updated binaries alongside your changes. DirectX 11 shader compilation requires Windows.

## Installation (changed from original)

Install via NuGet.

```shell
dotnet add package CnCNet.Forme.NET48
dotnet add package CnCNet.Forme.MonoGame.NET48
```

To use the content pipeline extension with MonoGame, add the reference the following NuGet package in your project and add the dll reference to your Content.mgcb file as usual.

```shell
dotnet add package CnCNet.Forme.MonoGame.Content.Pipeline.NET48
```

## Our downgrade approach
Retargets all projects from `net8.0` to `net48` and downgrades MonoGame from `3.8.4.1` to `3.8.0.1641`. Recompiles the shaders. Adds `Polyfill 10.0.0` + `System.Memory 4.6.3` to preserve full C# 14 feature usage (`ReadOnlySpan`, `init`, collection expressions, `ArgumentNullException.ThrowIfNull`, etc.) on .NET Framework 4.8.

## License

Forme is licensed under the MIT License. See [LICENSE](LICENSE) for the full license text.
