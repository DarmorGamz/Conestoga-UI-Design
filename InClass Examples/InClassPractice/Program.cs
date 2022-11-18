string sString = "Test123abc123";
Console.WriteLine(substrings(sString, "123"));

string substrings(string sString, string sSub) {
    if(sString.IndexOf(sSub) == -1) { return sString; }

    sString = sString.Substring(0, sString.IndexOf(sSub)) + sString.Substring(sString.IndexOf(sSub)+sSub.Length);
    return substrings(sString, sSub);
}