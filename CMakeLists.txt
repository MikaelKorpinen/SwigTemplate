cmake_minimum_required(VERSION 3.10)
project(SwigTemplate)

# Set policies for SWIG
if(POLICY CMP0078)
    cmake_policy(SET CMP0078 NEW)
endif()

if(POLICY CMP0086)
    cmake_policy(SET CMP0086 NEW)
endif()

if(POLICY CMP0122)
    cmake_policy(SET CMP0122 NEW)
endif()

set(INTERFACE_FILE "service_interface.i")
set(SOURCE_FILE_NAME "source_code")
set(INTERFACE_NAMESPACE "MyNameSpace")
set(MY_PROJECT_NAME "SourceCodeProject")

# Variables for C# project
set(CSHARP_PROJECT_NAME "SwigWrapper")
set(CSHARP_PROJECT_DIR "${CMAKE_SOURCE_DIR}/Build/CSharp")

# Set the path to SWIG
set(SWIG_EXECUTABLE "${CMAKE_SOURCE_DIR}/3rdParty/swigwin-4.2.1/swig.exe")

# Check if the specified SWIG executable exists
if(NOT EXISTS "${SWIG_EXECUTABLE}")
    message(FATAL_ERROR "SWIG executable not found at ${SWIG_EXECUTABLE}")
endif()

# Find SWIG using the specified executable
find_package(SWIG REQUIRED)
include(${SWIG_USE_FILE})

# Set C# as the target language
set_property(SOURCE "${CMAKE_SOURCE_DIR}/SwigInterface/${INTERFACE_FILE}" PROPERTY CPLUSPLUS ON)
set_property(SOURCE "${CMAKE_SOURCE_DIR}/SwigInterface/${INTERFACE_FILE}" PROPERTY SWIG_FLAGS -namespace "${INTERFACE_NAMESPACE}")

# Add source files
set(SOURCE_FILES
    "${CMAKE_SOURCE_DIR}/${MY_PROJECT_NAME}/${SOURCE_FILE_NAME}.cpp"
)

# Include directories
include_directories("${CMAKE_SOURCE_DIR}/${MY_PROJECT_NAME}")

# SWIG add module
set(CMAKE_SWIG_OUTDIR "${CMAKE_BINARY_DIR}/CSharpWrapper")

swig_add_library(${CSHARP_PROJECT_NAME}
  TYPE MODULE
  LANGUAGE CSharp
  SOURCES "${CMAKE_SOURCE_DIR}/SwigInterface/${INTERFACE_FILE}" ${SOURCE_FILES}
  OUTPUT_DIR ${CMAKE_SWIG_OUTDIR}
  OUTFILE_DIR ${CMAKE_SWIG_OUTDIR}
)

# Set C# output directory
set_target_properties(${CSHARP_PROJECT_NAME} PROPERTIES OUTPUT_NAME ${CSHARP_PROJECT_NAME})

# Ensure SWIG generates C# files
add_custom_command(TARGET ${CSHARP_PROJECT_NAME} POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E make_directory "${CSHARP_PROJECT_DIR}"
    COMMAND ${CMAKE_COMMAND} -E copy_directory "${CMAKE_SWIG_OUTDIR}" "${CSHARP_PROJECT_DIR}"
    COMMAND ${CMAKE_COMMAND} -E copy "${CMAKE_SOURCE_DIR}/Program/Program.cs" "${CSHARP_PROJECT_DIR}/Program.cs"
)

