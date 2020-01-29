Param([string]$repo)

$msbuildPath = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MSBuild.exe"

# *** Test_Toolkit requires BHoM and BHoM_Engine in order to build correctly for compliance tests, so here we make sure we have BHoM and BHoM_Engine ***

# **** Preparing BHoM ****
$repo = "BHoM"

# **** Defining BHoM Paths ****
$slnPath = "$ENV:BUILD_SOURCESDIRECTORY\$repo\$repo.sln"

# **** Restore BHoM NuGet ****
Write-Output ("Restoring NuGet packages for " + $repo)
& NuGet.exe restore $slnPath

# **** Cloning BHoM_Engine ****
$repo = "BHoM_Engine"

# **** Defining BHoM_Engine Paths ****
$slnPath = "$ENV:BUILD_SOURCESDIRECTORY\$repo\$repo.sln"

# **** Cloning BHoM_Engine Repo ****
Write-Output ("Cloning " + $repo + " to " + $ENV:BUILD_SOURCESDIRECTORY + "\" + $repo)
git clone -q --branch=master https://github.com/BHoM/$repo.git  $ENV:BUILD_SOURCESDIRECTORY\$repo

# **** Restore BHoM_Engine NuGet ****
Write-Output ("Restoring NuGet packages for " + $repo)
& NuGet.exe restore $slnPath

# **** Cloning Test_Toolkit ****
$repo = "Test_Toolkit"

# **** Defining Test_Toolkit Paths ****
$slnPath = "$ENV:BUILD_SOURCESDIRECTORY\$repo\$repo.sln"

# **** Cloning Test_Toolkit Repo ****
Write-Output ("Cloning " + $repo + " to " + $ENV:BUILD_SOURCESDIRECTORY + "\" + $repo)
git clone -q --branch=master https://github.com/BHoM/$repo.git  $ENV:BUILD_SOURCESDIRECTORY\$repo

# **** Restore Test_Toolkit NuGet ****
Write-Output ("Restoring NuGet packages for " + $repo)
& NuGet.exe restore $slnPath

write-Output ("Building BHoM.sln")
& $msbuildPath -nologo "$ENV:BUILD_SOURCESDIRECTORY\BHoM\BHoM.sln" /verbosity:minimal

write-Output ("Building BHoM_Engine.sln")
& $msbuildPath -nologo "$ENV:BUILD_SOURCESDIRECTORY\BHoM_Engine\BHoM_Engine.sln" /verbosity:minimal