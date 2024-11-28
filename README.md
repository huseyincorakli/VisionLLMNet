# VisionLLMNet

VisionLLMNet is a .NET library for extracting text from images using LLMs and converting them to Markdown format.

## Features

- Process images from local files or URLs
- Support for different LLM models
- Markdown format output
- Async/await support
- .NET Standard 2.0+ compatibility

## Installation

Via NuGet Package Manager:

```bash
NuGet\Install-Package VisionLLMNet -Version 1.0.1
```

Or using .NET CLI:

```bash
dotnet add package VisionLLMNet --version 1.0.1
```

## Usage

### Basic Usage

```csharp
using VisionLLMNet.Core;
using VisionLLMNet.Core.Configurations;

//Initialize the VisionLLMProcessor with your TogetherAI API key
VisionLLMProcessor visionLLMProcessor = new("YOUR_API_KEY");

// Process from local file
var resultLocalFile = await visionLLMProcessor.OCRAsync("path/to/image.jpg", ModelType.Llama_Vision_Free);

// Process from URL
var resultUrl = await visionLLMProcessor.OCRAsync("https://example.com/image.jpg", ModelType.Llama_Vision_Free);

Console.WriteLine(resultLocalFile.content);
Console.WriteLine(resultUrl.content);
```

### Available Models

The library supports the following models:

```csharp
public enum ModelType
{
    Llama_Vision_Free,  /*"meta-llama/Llama-Vision-Free";*/
    Llama_3_2_90B_Vision_Instruct_Turbo /*"meta-llama/Llama-3.2-90B-Vision-Instruct-Turbo";*/
}
```
## Requirements
- [TogetherAI API KEY](https://www.together.ai)
- System.Text.Json
- System.Net.Http

## License

This project is licensed under the MIT License

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request
