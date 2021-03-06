namespace CapsuleCorp.Traffic.Transit.Application.Dto
{
    using System.Collections.Generic;
    public class LevantarMultaBatchResult
    {
        public List<LevantarMultaInfoBatch> multasValidas { get; set; }
        public List<LevantarMultaInfoBatch> multasInvalidas { get; set; }

        public LevantarMultaBatchResult()
        {
            multasValidas = new List<LevantarMultaInfoBatch>();
            multasInvalidas = new List<LevantarMultaInfoBatch>();
        }
    }

    public class LevantarMultaInfoBatch
    {
        public string Matricula { get; set; }
        public LevantarMultaResult Info { get; set; }
        public LevantarMultaInfoBatch()
        {
            Info = new LevantarMultaResult();
        }
    }
}
