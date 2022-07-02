Get-ChildItem ./tests/ -Exclude "*.a","*.mine" | ForEach-Object {
    $content = Get-Content $_

    $right = Get-Content ("./tests/" + $_.BaseName + ".a")
    $result = $content | .\bin\Debug\net6.0\F_Sistema_prodagi_biletov_na_poesde.exe

    $result | Tee-Object ("./tests/" + $_.BaseName + ".mine") | Out-Null

    $_.BaseName + ":"
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
}