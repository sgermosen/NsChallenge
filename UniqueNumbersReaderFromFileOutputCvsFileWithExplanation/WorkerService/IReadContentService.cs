namespace WorkerService
{
    public interface IReadContentService
    {
        void Run(string inputFile, string fileName);
    }

    public class ReadContentService : IReadContentService
    {
        private readonly ILogger<ReadContentService> _logger;

        public ReadContentService(ILogger<ReadContentService> logger )
        {
            _logger = logger; 
        }

        public void Run(string inputFile, string fileName)
        {
            _logger.LogInformation($"Start to Read file content: {fileName}");
            StreamReader sStreamReader = new StreamReader($"{inputFile}");
            string AllData = sStreamReader.ReadToEnd();
            string[] strArray = AllData.Split(",".ToCharArray());
            int[] rows = Array.ConvertAll(strArray, int.Parse);
            _logger.LogInformation("End of Read file content");

            var differents = rows.Select(p => p.ToString()).Distinct();
            if (differents.Count() != rows.Count() && differents.Count() == 1)
                Console.WriteLine($"All the values are the same, therefore, there is only one unique input value: {string.Join(",", differents)}");
            else if (differents.Count() != rows.Count())
                Console.WriteLine($"The only unique values are: {string.Join(",", differents)} and the output order does not matter");
            else
                Console.WriteLine($"Entire input file is unique, therefore the output will be the same: {string.Join(",", differents)}");
 
        }
    }
}
