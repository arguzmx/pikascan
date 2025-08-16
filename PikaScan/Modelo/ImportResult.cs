using System.Collections.Generic;

namespace PikaScan.Modelo
{
    public class ImportResult
    {
        public ImportResult()
        {
            DoneOK = true;
            Errors = new List<string>();
            FileCount = 0;
        }

        public bool DoneOK { get; set; }
        public int FileCount { get; set; }

        public List<string> Errors { get; set; }

    }
}
