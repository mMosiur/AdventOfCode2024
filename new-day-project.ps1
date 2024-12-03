[CmdletBinding()]
param(
    [Parameter(Mandatory = $true, HelpMessage = "In 'dayXX' or 'XX' format, later reformatted to 'DayXX'")]
    [string]$day,

    [Parameter(ValueFromRemainingArguments = $true)]
    [string]$dayTitle
)

$year = 2024

if ($day -notmatch '^(day)?(\d\d?)$')
{
    Write-Error "Invalid day number"
    exit 1
}
$dayNumber = [int]$Matches[2]
if (($dayNumber -lt 1) -or ($dayNumber -gt 25))
{
    Write-Error "Invalid day number, available days are 1 to 25 (got $dayNumber)"
    exit 1
}
$dayString = '{0:d2}' -f [int]$dayNumber
$dayString = "Day$dayString"

if (-not $dayTitle)
{
    $providedTitle = Read-Host "Title (leave empty to skip)"
    if ($providedTitle)
    {
        $dayTitle = $providedTitle
    }
}

if (-not $dayTitle)
{
    dotnet new aocday --year $year -o "$dayString"
    dotnet sln add ".\$dayString\"
    Set-Location Tests
    dotnet add reference "..\$dayString"
    Set-Location ..
}
else
{
    dotnet new aocday --year $year -o "$dayString" --title "$dayTitle"
    $folderName = "$dayString - $dayTitle"
    Rename-Item "$dayString" "$folderName"
    dotnet sln add ".\$folderName\"
    Set-Location Tests
    dotnet add reference "..\$folderName"
    Set-Location ..
}
