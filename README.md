# .NET Windows App for Cloud Foundry

This is an ASP.NET Core application configured to run on Windows Cloud Foundry stemcells without requiring IIS or pre-building on Windows infrastructure.

## How It Works

- **ASP.NET Core** application (not .NET Framework)
- **Self-contained deployment** - includes .NET runtime
- **Binary buildpack** - runs the pre-built executable
- **No IIS required** - runs standalone with Kestrel
- **Cross-platform build** - can be built on Mac, Linux, or Windows

## Building the Application

You can build this application on **any platform** (Mac, Linux, or Windows) since .NET Core is cross-platform:

```bash
# Restore dependencies
dotnet restore

# Build and publish as self-contained Windows executable
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

# The output will be in: bin/Release/net8.0/win-x64/publish/
```

## Deploying to Cloud Foundry

1. **Build the application** (see above)
2. **Navigate to the publish directory**:
   ```bash
   cd bin/Release/net8.0/win-x64/publish
   ```
3. **Push to Cloud Foundry**:
   ```bash
   cf push
   ```

Or, if pushing from the project root, update `manifest.yml` to specify the path:
```yaml
path: bin/Release/net8.0/win-x64/publish
```

## Key Differences from .NET Framework

- ✅ **No pre-build on Windows required** - build on any platform
- ✅ **No IIS/HWC required** - runs standalone
- ✅ **No web.config required** - uses appsettings.json instead
- ✅ **Modern .NET** - uses latest .NET 8.0

## References

Based on the approach from: https://github.com/MarcialRosales/dot-net-core-pcf-workshop

