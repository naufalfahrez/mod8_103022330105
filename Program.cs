using mod8;

class Program
{
    static void Main(string[] args)
    {

        BankTransferConfig configApp = new BankTransferConfig();

        configApp.ReadConfigFile();
        configApp.SetDefault();

        if (configApp.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }
        else if (configApp.config.lang == "id")
        {
            Console.WriteLine("Masukan jumlah uang yang akan di-transfer:");
        }

        int nominal_transfer = int.Parse(Console.ReadLine());

        int biaya_transfer =
            (nominal_transfer > configApp.config.transfer.threshold)
            ? configApp.config.transfer.high_fee
            : configApp.config.transfer.low_fee;

        if (configApp.config.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {biaya_transfer}");
            Console.WriteLine($"Total amount = {nominal_transfer + biaya_transfer}");
            Console.WriteLine("\nSelect transfer method:");
        }
        else if (configApp.config.lang == "id")
        {
            Console.WriteLine($"Biaya transfer = {biaya_transfer}");
            Console.WriteLine($"Total biaya = {nominal_transfer + biaya_transfer}");
            Console.WriteLine("\nPilih metode transfer:");
        }

        for (int i = 0; i < configApp.config.methods.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + configApp.config.methods[i]);
        }

        if (configApp.config.lang == "en")
        {
            Console.WriteLine("Please enter your selection(number):");
        }
        else if (configApp.config.lang == "id")
        {
            Console.WriteLine("Mohon masukkan pilihan anda(angka):");
        }
        Console.ReadLine();

        Console.WriteLine();
        if (configApp.config.lang == "en")
        {
            Console.WriteLine($"Please type {configApp.config.confirmation.en} to confirm the transaction:");
        }
        else if (configApp.config.lang == "id")
        {
            Console.WriteLine($"Ketik {configApp.config.confirmation.id} untuk mengonfirmasi transaksi:");
        }
        string konfirmasi = Console.ReadLine();

        if (configApp.config.lang == "en")
        {
            Console.WriteLine(
                (konfirmasi == configApp.config.confirmation.en)
                ? "The transfer is completed"
                : "Transfer is cancelled");
        }
        else if (configApp.config.lang == "id")
        {
            Console.WriteLine(
                    (konfirmasi == configApp.config.confirmation.id)
                    ? "Proses transfer berhasil"
                    : "Transfer dibatalkan"
            );
        }
    }
}