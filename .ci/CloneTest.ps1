Param([string]$repo)

# **** Cloning BHoM ****
$repo = "BHoM"

# **** Defining Paths ****
$slnPath = "$ENV:BUILD_SOURCESDIRECTORY\$repo\$repo.sln"

# **** Cloning Repo ****
Write-Output ("Cloning " + $repo + " to " + $ENV:BUILD_SOURCESDIRECTORY + "\" + $repo)
git clone -q --branch=master https://github.com/BHoM/$repo.git  $ENV:BUILD_SOURCESDIRECTORY\$repo

# **** Restore NuGet ****
Write-Output ("Restoring NuGet packages for " + $repo)
& NuGet.exe restore $slnPath

# **** Cloning BHoM_Engine ****
$repo = "BHoM_Engine"

# **** Defining Paths ****
$slnPath = "$ENV:BUILD_SOURCESDIRECTORY\$repo\$repo.sln"

# **** Cloning Repo ****
Write-Output ("Cloning " + $repo + " to " + $ENV:BUILD_SOURCESDIRECTORY + "\" + $repo)
git clone -q --branch=master https://github.com/BHoM/$repo.git  $ENV:BUILD_SOURCESDIRECTORY\$repo

# **** Restore NuGet ****
Write-Output ("Restoring NuGet packages for " + $repo)
& NuGet.exe restore $slnPath

# **** Cloning BHoM Test_Toolkit ****
$repo = "Test_Toolkit"

# **** Defining Paths ****
$slnPath = "$ENV:BUILD_SOURCESDIRECTORY\$repo\$repo.sln"

# **** Cloning Repo ****
Write-Output ("Cloning " + $repo + " to " + $ENV:BUILD_SOURCESDIRECTORY + "\" + $repo)
git clone -q --branch=master https://github.com/BHoM/$repo.git  $ENV:BUILD_SOURCESDIRECTORY\$repo

# **** Restore NuGet ****
Write-Output ("Restoring NuGet packages for " + $repo)
& NuGet.exe restore $slnPath

write-Output ("Building BHoM.sln")
$msbuildPath -nologo "$ENV:BUILD_SOURCESDIRECTORY\BHoM\BHoM.sln" /verbosity:minimal

write-Output ("Building BHoM_Engine.sln")
& $msbuildPath -nologo "$ENV:BUILD_SOURCESDIRECTORY\BHoM_Engine\BHoM_Engine.sln" /verbosity:minimal