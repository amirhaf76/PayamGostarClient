using System;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels
{
    public class CrmTicketModel : BaseCRMModel
    {
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Ticket;

        public Guid ListenLineId { get; set; }

        public string ResponseTemplate { get; set; }

        public PriorityMatrixModel PriorityMatrix { get; set; }
    }
    public class PriorityMatrixModel
    {
        public PriorityMatrixDetailModel[] Details { get; set; }
    }

    public class PriorityMatrixDetailModel
    {
        public int SeverityIndex { get; set; }

        public int ImpactIndex { get; set; }

        public int PriorityIndex { get; set; }
    }


}
