## Thorn examples

Minimal examples demonstrating the use of Thorn, also shown on its wiki.

## Build & install

1. Create a `libs/` folder and put in these DLLs
  - `Assembly-CSharp.dll` and `UnityEngine.CoreModule.dll` from `PATH_TO_YOUR_ULTRAKILL_INSTALLATION/ULTRAKILL_Data/Managed`
  - `ThornClient.dll` and `ThornClient.xml` from the Thorn package on [Thunderstore](https://thunderstore.io/c/ultrakill/p/end_4/Thorn) or [GitHub](https://github.com/end-4/ultrakill-thorn-client)
2. Compile: `dotnet build -c Release`
3. The resulting binary is in `bin/Release/netstandard2.1/ThornExamples.dll`

## License

The Unlicense. You can reuse these examples without any permission or attribution whatsoever.
