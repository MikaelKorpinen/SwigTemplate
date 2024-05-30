# SwigTemplate
A template project that integrates SWIG with minimal code, built using CMake.

## How to Verify

1. There is a console app 2 project added to the repository. Open it or run executable.
2. The CMake and Swig produced dll needs to be next to the executable.

## How to Use the Template

To adapt this template for your own code, follow these steps:

1. **Source Code:**
   - The `source_code` folder contains the C++ source code.

2. **SWIG Interface:**
   - The `swig_interface` folder contains the SWIG interface file that defines the interface between managed C++ and C#.

3. **Console Application:**
   - The `ConsoleApp2` folder contains the C# code that uses the wrapped C++ code.

4. **Build the Project:**
   - Open PowerShell and navigate to the `build` folder.
   - Run the following commands:
     ```sh
     cmake -G "Visual Studio 17 2022" -A x64 ..
     cmake --build .
     ```
   - This will generate the wrapper DLL in the `build/Debug` folder and create a project for the wrapper.

5. **Deploy the DLL:**
   - Copy `SwigWrapper.dll` to the directory containing the `ConsoleApp2` executable.

## Issues Encountered and Solved

1. **32-bit Console Application:**
   - The console app was initially set to 32-bit, causing errors when executing functions from the DLL.
   - Solution: Change the console app to target x64 in the project settings.

2. **CLR Support:**
   - To work with a CLR-supported DLL, the wrapper project must be configured with CLR support and C++ exceptions enabled (set to SEH).
   - Solution: Adjust these settings in the project's C++ settings.

3. **Unmanaged Code Support:**
   - To fully support unmanaged code, the DLL reference needs to be removed, and the DLL should be placed next to the `ConsoleApp2` executable.
   - Solution: Manually place the DLL next to the executable after building.
