namespace Minimal.API;

public class LoadDynamically
{
    public string Explain => "This class will not be loaded dynamically when using AoT compilation, because there are no direct references pointing to it.";
}