cmake_minimum_required (VERSION 3.8)

project ("nmeml" CXX)

add_library (nmeml SHARED "nmeml.cpp" "nmeml.h")

target_compile_options (nmeml PRIVATE -Wall)

if (CMAKE_VERSION VERSION_GREATER 3.12)
  set_property (TARGET nmeml PROPERTY CXX_STANDARD 20)
endif()