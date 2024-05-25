# SwigTemplate
 Template project that has swig with minimal code and is build with CMAKE

#How to verify

1. Open SwigTemplate.sln
2. Make sure console app2 is selected as startup application
3. Hit play. Console should appear giving a number.

# How to use the template

In case of using your own code some or a lot of changes need to be done.
1. Source code project folder contains the source code
2. Swig interface contains the swig interfacce file that is used to define the interface from managed c++ to C#
3. Console app 2 contain the code using the wrapped c++ code.
4. cd to build folder on powershell and run "cmake -G "Visual Studio 17 2022" -A x64 .." after that run "cmake --build ."
This will generate the wrapper dll in build/Debug folder

# Issues encountered and solved
1. Console app was defaulted to 32 bits. This caused the function execution from the dll to throw error.
2. To work with clr supported dll the wrapper project had to be set to have common language runtime support (clr) and Enable c++ exceptions to Yes with SEH from project c++ settings.
There might have been 1 other but it was easy to solve. Similarly just change the setting in the build error to supported format.
3. To support fully unmanaged the dll reference neededto be removed and the dll to be moved next to console app executable

# Future Improvements
It is possible to run unmanaged code aswell (no clr).