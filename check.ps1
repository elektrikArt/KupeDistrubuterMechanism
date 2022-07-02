Get-ChildItem ./tests/ -Exclude "*.a","*.mine" | ForEach-Object {
    $_.BaseName + ":"

    $right = Get-Content ("./tests/" + $_.BaseName + ".a")
    $result = Get-Content $_ | .\bin\Debug\net6.0\F_Sistema_prodagi_biletov_na_poesde.exe`
        | Tee-Object ("./tests/" + $_.BaseName + ".mine")

    #"content:"
    #$content
    #"right:"
    #$right
    #"result:"
    #$result


    $verdict = Compare-Object -ReferenceObject $right -DifferenceObject $result
    if ($verdict -ne $null) {
        $verdict
        break;
    }
    #$verdict
}