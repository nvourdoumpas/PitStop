using PitStop.Core.Helpers;

Console.WriteLine("=== Encrypt - Decrypt Project ===");

while (true)
{
    try
    {
        var selection = GetSelection();

        switch (selection)
        {
            case "0":
                Console.WriteLine("Exiting the program...");
                return;

            case "1":
                Console.WriteLine("Type the plain text to encrypt:");
                var textToEncrypt = Console.ReadLine();
                textToEncrypt = Util.Encrypt(textToEncrypt);
                Console.WriteLine();
                Console.WriteLine($"Encrypted: {textToEncrypt}");
                break;

            case "2":
                Console.WriteLine("Type the encrypted text to decrypt:");
                var textToDecrypt = Console.ReadLine();
                textToDecrypt = Util.Decrypt(textToDecrypt);
                Console.WriteLine();
                Console.WriteLine($"Decrypted: {textToDecrypt}");
                break;

            default:
                throw new Exception("Unsupported selection!");
        }

        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"-- ERROR: {ex.Message} --");
        Console.WriteLine();
    }
}

string? GetSelection()
{
    Console.WriteLine("What do you want?");
    Console.WriteLine("[0] To Exit");
    Console.WriteLine("[1] To Encrypt text");
    Console.WriteLine("[2] To Decrypt text");
    Console.WriteLine("Press (0-2): ");
    return Console.ReadLine();
}
