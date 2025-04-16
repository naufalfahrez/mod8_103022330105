using System.Text.Json;
using static mod8.BankTransfer;
namespace mod8
{

    public class BankTransfer
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public string[] methods { get; set; }
        public Confirmation confirmation { get; set; }

        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }
        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
        }
    }

    public class BankTransferConfig
    {
        public BankTransfer config;

        public static string file_path = Path.Combine(Directory.GetCurrentDirectory(), "bank_transfer_config.json");

        public void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(file_path);
            config = JsonSerializer.Deserialize<BankTransfer>(configJsonData);
        }


        public void WriteNewConfigFile()
        {
            JsonSerializerOptions option = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(config, option);
            File.WriteAllText(file_path, jsonString);
        }

        public void SetDefault()
        {
            config = new BankTransfer();

            config.lang = "id";
            Transfer transfer = new();
            transfer.threshold = 25000000;
            transfer.low_fee = 6500;
            transfer.high_fee = 15000;
            config.transfer = transfer;
            config.methods = new string[] { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
            Confirmation confirmation = new();
            confirmation.en = "yes";
            confirmation.id = "yes";
            config.confirmation = confirmation;
        }

        public void UIConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
    }
}