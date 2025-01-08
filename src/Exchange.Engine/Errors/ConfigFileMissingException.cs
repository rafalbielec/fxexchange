namespace Exchange.Engine.Errors;

[Serializable]
public class ConfigFileMissingException(string configFileName)
    : Exception($"The {configFileName} file needs to be in the same directory as the program file.")
{
}