using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels
{
    public class CrmTicketModel : BaseCRMModel
    {
        public CrmTicketModel()
        {
            PriorityMatrix = new PriorityMatrixModel();
        }
        public override Gp_CrmObjectType Type => Gp_CrmObjectType.Ticket;

        public Guid ListenLineId { get; set; }

        public string ResponseTemplate { get; set; }

        public PriorityMatrixModel PriorityMatrix { get; set; }
    }

    public class PriorityMatrixModel
    {
        public PriorityMatrixModel()
        {
            Details = Array.Empty<PriorityMatrixDetailModel>();
        }

        public PriorityMatrixDetailModel[] Details { get; set; }
    }

    public class PriorityMatrixDetailModel
    {
        public Gp_Matrix_Severity SeverityIndex { get; set; }

        public Gp_Matrix_Impact ImpactIndex { get; set; }

        public Gp_Matrix_Priority PriorityIndex { get; set; }
    }


}
