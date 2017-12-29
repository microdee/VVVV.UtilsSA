# VVVV.UtilsSA

Standalone fork of VVVV.Utils from https://github.com/vvvv/vvvv-sdk

This repository isn't a proper fork but a hard copy of VVVV.Utils because unfortunately VVVV.Utils is embedded inside the much larger vvvv-sdk, and it doesn't have its own repo. So it might be behind the "develop" branch of vvvv-sdk as changes there have to be hard-replicated here but much more ahead of what's available on nuget.org.

Original files are found at https://github.com/vvvv/vvvv-sdk/tree/develop/common/src/core/Utils

VVVV.Utils contains tremendous amounts of great helper utilities for developing interactive applications which are not necessarily tied to VVVV. Unfortunately though VVVV itself is a giant ecosystem which has a pretty slow update cycle and VVVV.Utils is not independent of that. More unfortunately the developers of VVVV chose to host pre-release nuget packages on their own server instead of on Nuget.org tagged with "pre-release". Only stable VVVV packages are pushed to nuget.org but even a year can pass between those updates.

VVVV.UtilsSA can provide a temporary solution when changes have to be implemented much faster than the update cycle of the stable VVVV releases outside of the VVVV ecosystem and without custom nuget sources.
